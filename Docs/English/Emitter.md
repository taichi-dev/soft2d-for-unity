# Emitter

> The Emitter is a emitter that allows for the controlled emission of Bodies. It corresponds to the EEmitter class in the code.

## How to Use Emitter GameObject

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/444ce93b-6727-4edb-80c2-81954cc613da

## Parameter Panel

The EEmitter parameter panel is divided into four sections: Emitter Settings, Material Settings, Color Settings, and Event Settings.

### Emitter Settings

- Emit on Start
  - When set to true, the Emitter will start emitting preset Bodies as soon as the World is generated.
- Initial Linear Velocity
  - The initial linear velocity of the emitted Bodies. Measured in m/s.
- Initial Angular Velocity
  - The initial angular velocity of the emitted Bodies. Measured in s^-1.
- Emitting Frequency
  - The frequency at which the Bodies are emitted. Measured in s^-1.
- Life Cycle
  - The duration from the moment the Body is emitted until it is automatically destroyed. Measured in seconds. A value less than or equal to 0 means they will never be automatically destroyed.
- Use MeshBody
  - Determines whether the Emitter emits the MeshBody. When set to true, the Emitter will emit the MeshBody.
- Body Shape
  - See [Shape.md](./Shape.md) for detailed information.
- MeshBody Settings
  - See [Body.md](Body.md) for detailed information.

### Material Settings

[Detailed Content](./Material.md)

### Color Settings

- Base Color
  - The color of the particles inside the emitted Bodies. Only available when Random Color is turned off.
- Random Color
  - Determines whether colors are randomly selected from the random color list.
- Random Color List
  - The collection of all colors that can be randomly selected. Available when Random Color is turned on.
- Rainbow Mode
  - Determines whether RGB values are randomly generated as particle colors.

### Event Settings

- OnEmitterOut
  - Automatically called when particles are emitted.
