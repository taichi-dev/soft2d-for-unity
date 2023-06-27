# Custom Trigger

> Users can customize the events triggered by Triggers to manipulate Soft2D particles. We will introduce two methods: using built-in functions and custom delegates.

> The term "Trigger" used in this article refers to the triggers within Soft2D.

## Built-in Functions

We can use the built-in functions of Triggers to manipulate particles.

## Custom Delegates

> Video: [Tutorial](../../images/TriggerCallback.mp4)

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a5d525dd-c056-4340-b6b4-3f31c86c3918



### Basic Structure

Users can write their own method and pass it to Soft2D for invocation. The basic structure of this method is as follow:
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticlesInTrigger(IntPtr particles, int size)
{ 

}
```
In this function:
- `particles` is a pointer to an array which contains information about all particles entered the Trigger's range.
- `size` is the total number of particles that entered the Trigger's range.

The particle information is encapsulated in a structure called **S2Particle**:
```csharp
public struct S2Particle {
    public uint id;
    public S2Vec2 position;
    public S2Vec2 velocity;
    public uint tag;
    public uint is_removed;
}
```
- `id` represents the particle's ID within Soft2D. The particle's ID remains unchanged even if particles are added or removed.
- `position` represents the current position of the particle.
- `velocity` represents the current velocity of the particle.
- `tag` represents the tag buffer of the particle.
- `is_removed` indicates whether the particle has been removed. A value greater than 0 indicates that the particle has been removed.

### Function Implementation

To manipulate individual particle, we need to first retrieve the memory information of the current particle and convert it into the `S2Particle` structure:
```csharp
IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
```
After the manipulation is completed, we need to pack the structure and return it to the original memory:
```csharp
Marshal.StructureToPtr(particle, particlePtr, false);
```
In this way, we have completed the function structure for per-particle manipulation:
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size)
{
     int particleSize = Marshal.SizeOf<S2Particle>();
     for (int i = 0; i < size; i++)
     {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        // Manipulation on particles...
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```
In the commented section of the code above, we can modify the content of the `S2Particle` structure to manipulate particles, such as removing particles that entered the Trigger:
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
If you want to modify external variables within this function, make sure those variables are static.

### Function Invocation

You can call `void InvokeCallbackAsync(S2ParticleManipulationCallback callback)` in order to let Soft2D execute the code within the callback.

For example, to have a Trigger delete all particles that enter its range:
```csharp
private ETrigger trigger;
...
private void Update(){
    trigger.InvokeCallbackAsync(ManipulateParticles);
    ...
    }
```
- **Do not** use multicast delegates (loading multiple functions) as the callback when calling `void InvokeCallbackAsync(S2ParticleManipulationCallback callback)`, which can cause the Soft2D program to crash.
- After invoking the function, the callback runs **synchronously** with the subsequent code. To ensure asynchronous execution, you can add a signal flag within the callback:
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
- Calling this function only executes the callback once. Make sure to call this function every frame within the Trigger's working cycle to ensure its execution.
