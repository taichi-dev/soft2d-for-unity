# Trigger
Trigger 是一个拥有特定形状的空间区域，可以检测到经过它的粒子。对应代码中的 `ETrigger` 类型。 Trigger 的作用范围由它的 BoxCollider2D 组件控制。

> 本文中 Trigger 均表示 Soft2D 内的 Trigger，而非 unity 自带的 Trigger。

## Trigger 事件
Trigger 提供了多个接口允许用户对 trigger 内的粒子进行查询和操作。
* `QueryParticleOverlapping()`: 查询是否有粒子在 trigger 区域内。
* `QueryParticleOverlappingByTag()`：查询是否有满足 tag 条件的粒子的 trigger 在区域内。
* `QueryParticleNum()`：查询 trigger 区域内粒子的数量。
* `QueryParticleNumByTag()`：查询 trigger 区域内满足 tag 条件的粒子的数量。
* `DestroyParticles()`：移除 trigger 区域内的所有粒子。
* `DestroyParticlesByTag()`：移除 trigger 区域内的所有粒子。

## 自定义回调函数
除了 trigger 事件以外，用户还可以传入自定义的回调函数来查询和操作 trigger 中的粒子。本章节将会介绍自定义回调函数的用法。下面的视频对其用法进行了一个直观展示：

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a5d525dd-c056-4340-b6b4-3f31c86c3918


### 回调函数要求
在 c# 中，用户需要定义一个 `S2ParticleManipulationCallback` 类型的回调函数。一个满足要求的回调函数示例如下：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticlesInTrigger(IntPtr particles, int size)
{ 

}
```
此回调函数接受两个参数：
- particles： Soft2D 提供的一个数组指针，这个数组包含了所有 trigger 内的粒子数据。
- size：数组中粒子的数量。

### 粒子结构体
每个粒子的数据以 `S2Particle` 结构体的形式保存：
```csharp
public struct S2Particle {
    public uint id;
    public S2Vec2 position;
    public S2Vec2 velocity;
    public uint tag;
    public uint is_removed;
}
```
- `id`：粒子在 Soft2D 内部的 ID。粒子的 ID 不会随着粒子的增减发生变化。
- `position`：粒子当前的位置。
- `velocity`：粒子当前的速度。
- `tag`：粒子的tag。
- `is_remove`：表示粒子是否被移除。大于0表示粒子被移除。该值默认为0。

### 回调函数的编写

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