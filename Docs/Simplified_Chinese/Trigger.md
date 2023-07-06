# Trigger
> 用户必须启用 Soft2DManager 中的`世界查询`选项，trigger 才能正常工作。见 [世界查询设置](Soft2DManager.md#世界查询设置)。

> 本文中提及的 `trigger` 均表示 Soft2D 内的 trigger，而非 Unity 自带的 trigger。

Trigger 是一个拥有特定形状的空间区域，可以检测到经过它的粒子。对应代码中的 `ETrigger` 类型。 Trigger 的作用范围由它的 Collider2D 组件控制。


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

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/06a510b0-b248-42a6-8607-ee4e02b7c43a

[Video on YouTube](https://www.youtube.com/watch?v=ja-Spz0sJTg).

> 目前自定义回调函数支持对粒子数据进行两种的操作：删除粒子和修改粒子tag。

### 回调函数要求
在 c# 中，用户需要定义一个 `S2ParticleManipulationCallback` 类型的回调函数。一个满足要求的回调函数示例如下：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticlesInTrigger(IntPtr particles, int size) { 

}
```
此回调函数接受两个参数：
- `particles`：Soft2D 提供的一个数组指针，这个数组包含了所有 trigger 内的粒子数据。
- `size`：数组中粒子的数量。

> 目前 trigger delegate 不支持使用多播委托作为回调函数，使用多播委托可能会导致项目崩溃。


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
- `id`：粒子在 Soft2D 内部的 ID。一个粒子的 ID 在整个模拟过程中不会改变。
- `position`：粒子当前的位置。
- `velocity`：粒子当前的速度。
- `tag`：粒子的tag。
- `is_remove`：表示是否（在下一个 step 之前）删除当前粒子。大于0则粒子将被删除。该值默认为0。

### 回调函数的编写

如果想对单个粒子进行操作，我们需要获取当前粒子信息所在的数组位置，并把它转换为 S2Particle 结构体：
```csharp
IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
```
操作结束后，把结构体释放为非委托内存：
```csharp
Marshal.StructureToPtr(particle, particlePtr, false);
```
整体的代码如下：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size)
{
    int particleSize = Marshal.SizeOf<S2Particle>();
    for (int i = 0; i < size; i++) {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        // 对粒子进行操作...
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```
一个能够删除 trigger 中所有粒子的回调函数如下所示：
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size) {
    int particleSize = Marshal.SizeOf<S2Particle>();
    for (int i = 0; i < size; i++) {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        particle.is_removed = 1;
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```

### 传入回调函数到 Soft2D 

用户需要使用 `ETrigger` 中的 `InvokeCallbackAsync()` 将自己编写的回调函数传入 Soft2D 并自动执行：

```csharp
private ETrigger trigger;
private void Update() {
    trigger.InvokeCallbackAsync(ManipulateParticles);
}
```

### 线程安全
`InvokeCallbackAsync()`会将用户自定义的回调函数传入 Soft2D 并在渲染线程上执行。因此回调函数会和逻辑线程（`Update()`）异步执行。下面是一个方法在逻辑线程中确保回调函数执行完毕：
```csharp
private ETrigger trigger;
private static int callback_finished = 0;

[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size) {
    // ...
    callback_finished = 1;
}

private void Update() {
    trigger.InvokeCallbackAsync(ManipulateParticles);
    if (callback_finished) {
        // ...
    }
}
```
