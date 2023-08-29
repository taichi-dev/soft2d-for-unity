# Emitter
An emitter is an object that can freely control the emission of bodies. Corresponds to the `EEmitter` type in the code.

## Parameter Panel

### Emitter Settings
- Emit on Start
  - If true, the emitter will start emitting preset bodies after the world is generated.
- Initial Linear Velocity
  - The initial linear velocity of the emitted body. The unit is `meters per second`.
- Initial Angular Velocity
  - The initial angular velocity of the emitted body. The unit is `degrees per second`.
- Emitting Frequency
  - The frequency of body emission. The unit is `quantity per second`.
- Lifetime
  - The duration for which a body is automatically destroyed after being emitted. The unit is `seconds`. Less than or equal to 0 means it will never be automatically destroyed.
- Use MeshBody
  - Whether to let the emitter emit mesh bodies. When true, the emitter will emit mesh bodies.
- Body Shape
  - See [Shape](./Shape.md).
- MeshBody Settings
  - See [Mesh Body](Body.md#Mesh-Body).
  
### Material Settings
See [Material](./Material.md).

### Color Settings
- Base Color
  - The color of the particles inside the emitted bodies. Only available when `Support Random Color` is turned off.
- Support Random Color
  - Determines whether colors are randomly selected from the random color list.
- Random Colors
  - The collection of all colors that can be randomly selected. Available when `Support Random Color` is turned on.
- Rainbow Mode
  - Determines whether RGB values are randomly generated as particle colors.

### Event Settings
- OnEmitterOut
  - This event is automatically called when particles are emitted.
