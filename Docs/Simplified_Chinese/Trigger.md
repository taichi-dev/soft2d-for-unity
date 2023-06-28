# Trigger

> Trigger 是一个拥有特定形状的空间区域。它可以检测到经过它的粒子。对应代码中的 ETrigger 类型。 Trigger 的作用范围由它的 BoxCollider2D 组件控制。

> 本文中 Trigger 均表示 Soft2D 内的触发器组件。

## 使用 Trigger GameObject 的方法

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/5a1e835a-df52-4302-96a5-02fbfcff12fa

## 自定义委托

> 用户可以自定义 Trigger 触发的事件来操作 Soft2D 粒子。我们将展开介绍固定函数和自定义委托两种方法。

> 本文出现的 Trigger 均表示 Soft2D 内的触发器。

## 固定函数

我们可以使用 Trigger 的内置函数来对粒子进行操作。

## 自定义委托

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a5d525dd-c056-4340-b6b4-3f31c86c3918


### 基本结构

用户可以自己编写一个方法，并将它传至 Soft2D 内调用。这个方法的基本结构如下：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticlesInTrigger(IntPtr particles, int size)
{ 

}
```
在这个函数中：
- particles 是一个指针，它指向一个记录了进入 Trigger 范围的所有粒子信息的数组。
- size 是进入 Trigger 范围粒子的总数。

粒子信息被包装在一个叫 **S2Particle** 的结构体内：
```csharp
public struct S2Particle {
    public uint id;
    public S2Vec2 position;
    public S2Vec2 velocity;
    public uint tag;
    public uint is_removed;
}
```
- id 为粒子在 Soft2D 内部的 ID。粒子的 ID 不会随着粒子的增减发生变化。
- position 为粒子当前所在的位置。
- velocity 为粒子当前的线速度。
- tag 为粒子的 tagbuffer 。
- is_removed 表示粒子是否被移除。大于0表示粒子被移除。

### 函数编写

如果想对单个粒子进行操作，我们需要先获取当前粒子信息所在的内存信息，并把它转换为 S2Particle 结构体：
```csharp
IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
```
在操作结束后，我们还需要把结构体打包送回原有内存：
```csharp
Marshal.StructureToPtr(particle, particlePtr, false);
```
这样我们就完成了逐粒子操作的函数结构：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size)
{
     int particleSize = Marshal.SizeOf<S2Particle>();
     for (int i = 0; i < size; i++)
     {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        // 对粒子进行操作...
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```
在上述代码的注释部分，我们可以通过修改 S2Particle 内容来操作粒子，比如将进入 Trigger 的粒子移除：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size)
{
     int particleSize = Marshal.SizeOf<S2Particle>();
     for (int i = 0; i < size; i++)
     {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        particle.is_removed = 1;
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```
如果想在该函数内修改外部的一些变量，请确保变量是静态的。

### 调用函数

通过调用 `void InvokeCallbackAsync(S2ParticleManipulationCallback callback)` 让 Soft2D 执行一次 callback 内的函数。

比如让 Trigger 删除进入其范围内的所有粒子：
```csharp
private ETrigger trigger;
...
private void Update(){
    trigger.InvokeCallbackAsync(ManipulateParticles);
    ...
    }
```
- **禁止**使用多播委托（装载多个函数）作为 callback 调用`void InvokeCallbackAsync(S2ParticleManipulationCallback callback)`，这样会导致 Soft2D 程序崩溃。
- 调用函数后， callback是与后面的代码**同步运行**的。你可以在 callback 函数内部加入一个信号标保证它们的异步进行：
```csharp
private ETrigger trigger;
private static bool locked = true;
...
private void Update(){
    trigger.InvokeCallbackAsync(ManipulateParticles);
    if (!locked){
        ...
        }
    }

[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateParticles(IntPtr particles, int size)
    {
        ...
        locked = false;
    }
```
- 调用该函数只会让 Soft2D 执行一次 callback，确保在 Trigger 的工作周期内每帧调用一次该函数。