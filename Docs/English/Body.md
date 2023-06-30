# Body
A body is a continuum that can be simulated, composed of a group of particles. A body has attributes such as `shape`, `center` and `material`. In the code, it corresponds to the `EBody` class.


## Parameter Panel

### Body Settings
- Shape
  - The initial shape of the body. According to the specific shape, Soft2D will automatically generate particles inside it. Currently, it supports rectangle, circle, ellipse, capsule, and polygon types. Detailed documentation on shapes can be found in [Shape](./Shape.md).
- Linear Velocity
  - The initial linear velocity of the body, measured in `meters per second`.
- Angular Velocity
  - The initial angular velocity of the body, measured in `degrees per second`.
- Lifetime
  - The duration after which the Body is automatically destroyed, measured in `seconds`. A value less than or equal to 0 indicates that it will never be automatically destroyed.
- Particle Tag
  - In Soft2D, every particle can have its own tag. The body assigns this value to all its contained particles during initialization, which means that each particle contained in the body has this tag value.
  
  > The particle tag is mainly used for trigger logic events and rendering, which can be accessed through `S2Particle.tag` (CPU) or `GetParticleTagBuffer()` (GPU).
  
### Material Settings
Refer to [Material](./Material.md).

### Color Settings
- Base Color
  - Provides the particles inside the body with a same color.
- Random Color
  - Provides the particles inside the body with randomly generated colors.

# Other Body Types

## Custom Body
A custom body is a body with user-specified sample points. Users can customize the particle positions within the body. In the code, it corresponds to the `ECustomBody` type.

### Parameter Panel

- Particle Local Position
  - The position of particles inside the custom body in local space.

## Mesh Body
A mesh body is a body with topological relationships. Each vertex position of the input mesh will generate a particle, and they follow the topology of the triangles within the mesh. In the code, it corresponds to the `EMeshBody` type.

### Parameter Panel
- Mesh
  - The 2D mesh used to generate the mesh body.
- Mesh Scale
  - The scale factor of the mesh.