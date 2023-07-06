# Trigger
> Users must enable the `World Query` option in Soft2DManager for the trigger to function properly. See [World Query Settings](./Soft2DManager.md#world-query-settings).

> In this document, 'trigger' refers to the trigger within Soft2D, not the built-in trigger in Unity.

A Trigger is a spatial region with a specific shape that can detect particles passing through it. It corresponds to the `ETrigger` type in the code. The scope of the Trigger is controlled by its Collider2D component.

## Trigger Events
Trigger provides multiple interfaces that allow users to query and operate on the particles within the trigger.

* `QueryParticleOverlapping()`: Check if there are any particles within the trigger area.
* `QueryParticleOverlappingByTag()`: Check if there are particles that meet the tag conditions within the trigger area.
* `QueryParticleNum()`: Check the number of particles in the trigger area.
* `QueryParticleNumByTag()`: Check the number of particles that meet the tag conditions in the trigger area.
* `DestroyParticles()`: Remove all particles in the trigger area.
* `DestroyParticlesByTag()`: Remove all particles that meet the tag conditions in the trigger area.

## Custom Callback Functions
In addition to trigger events, users can also pass in custom callback functions to query and operate on the particles within the trigger. This section will introduce how to use custom callback functions. The video below provides an intuitive demonstration of using a callback function:

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/06a510b0-b248-42a6-8607-ee4e02b7c43a

[Video on YouTube](https://www.youtube.com/watch?v=ja-Spz0sJTg).


> Currently, custom callback functions support two types of operations on particle data: deleting particles and modifying particle tags.


### Callback Function Requirements
In C#, users need to define a callback function of type `S2ParticleManipulationCallback`. An example of a valid callback function is as follows:
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticlesInTrigger(IntPtr particles, int size) { 

}
```
This callback function accepts two parameters:
* `particles`: An array pointer provided by Soft2D, this array contains all the particle data within the trigger.
* `size`: The number of particles in the array.

> Currently, the trigger delegate does not support using multicast delegates as callback functions. Using multicast delegates may cause the project to crash.


### Particle Structure

The data of each particle is stored in the form of the `S2Particle` structure:
```csharp
public struct S2Particle {
    public uint id;
    public S2Vec2 position;
    public S2Vec2 velocity;
    public uint tag;
    public uint is_removed;
}
```
- `id`: The internal ID of the particle in Soft2D. The ID of a particle is persistent during the whole simulation.
- `position`: The current position of the particle.
- `velocity`: The current velocity of the particle.
- `tag`: The tag of the particle.
- `is_remove`: Indicates whether the particle will be removed (before the next step). A value greater than 0 indicates that the particle will be removed. This value defaults to 0.

### Writing Callback Functions
If you want to operate on a single particle, you need to get the array position of the current particle information and convert it to an `S2Particle` structure:

```csharp
IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
```
After the operation is completed, release the structure into non-managed memory:
```csharp
Marshal.StructureToPtr(particle, particlePtr, false);
```
The overall code is as follows:
```csharp
[AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
public static void ManipulateParticles(IntPtr particles, int size)
{
    int particleSize = Marshal.SizeOf<S2Particle>();
    for (int i = 0; i < size; i++) {
        IntPtr particlePtr = IntPtr.Add(particles, i * particleSize);
        S2Particle particle = Marshal.PtrToStructure<S2Particle>(particlePtr);
        // Operating on particles ...
        Marshal.StructureToPtr(particle, particlePtr, false);
    }
}
```
A callback function that removes all particles in the trigger is shown below:

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

### Passing Callback Function to Soft2D
Users need to use `InvokeCallbackAsync()` in `ETrigger` class to pass their own callback function to Soft2D (and the callback will be executed automatically):

```csharp
private ETrigger trigger;
private void Update() {
    trigger.InvokeCallbackAsync(ManipulateParticles);
}
```

### Thread Safety
`InvokeCallbackAsync()` will pass the user-defined callback function into Soft2D and execute it on the rendering thread. Therefore, the callback function will be executed asynchronously with the logic thread (`Update()`). Below shows an example to ensure the completion of the callback function in the logic thread:

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
