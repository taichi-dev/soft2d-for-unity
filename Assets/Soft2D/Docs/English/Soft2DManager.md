# Soft2DManager
Soft2DManager is the core scene manager, responsible for managing the scene parameters, rendering, and managing objects (body, collider, and trigger). To use the features of the plugin, it is necessary to have a Soft2DManager in the scene. Corresponds to the `Soft2DManager` type in the code.

## Parameter Panel
### World Settings
World is a container that includes all the objects in the scene related to simulation, and performs physical simulation on these objects according to physical rules.

- World Extent
  - The size of the area for physical simulation.
- World Offset
  - The position coordinates of the bottom left corner of the physical simulation area.
- Gravity
  - The size and direction of gravity in the scene. This is only effective when the gyroscope is off.
- Enable Gyro
  - Whether to turn on the gyroscope.
- Gyro Scale
  - The scaling factor for the gyroscope gravity. Only effective when the gyroscope is on.
- Enable Force Field
  - Whether to enable the force field. When the user drags the cursor on the screen, a force that affects particles is applied around the cursor, and the direction of the force is the direction of cursor movement.
- Force Field Scale
  - The magnitude of the force within the force field. Only effective when the force field is enabled.
- World Boundary
  - Whether to enable the world boundary. Turning on world boundaries will automatically generate colliders on the boundary of the simulation area to prevent particles from leaving the simulation area.

### Debugging Tools Settings
- Enable Debugging Tools
  - Whether to enable debugging tools. Enabling this option can visualize the location of the collider and trigger during runtime.
- Collider Color
  - The visualization color of the collider.
- Trigger Color
  - The visualization color of the trigger.

### Render Settings
- Instance Mesh
  - The mesh model used to render each particle.
- Particle Sorting Layer
  - The rendering layer of the particles.
- Particle Rendering Mode. The rendering material used for rendering particles. Soft2D-for-Unity has 3 built-in rendering modes and supports user-defined rendering modes. We currently support the following rendering modes:
  - `Unlit`: Only displays color, without lighting effects.
  - `Blinn-Phong`: Blinn-Phong lighting model, only supports URP pipeline.
  - `PBR`: PBR lighting model, only supports URP pipeline.
  - `Custom`: User-defined rendering mode. For a detailed introduction, see [Custom Shaders](./CustomShader.md).

### Time Settings
- Time Step
  - The time step of physical simulation.
- SubStep
  - The time step of the internal sub-steps.

### Maximum Value Settings
- Max Particle Number
  - The maximum number of particles allowed in the current scene.
- Max Body Number
  - The maximum number of bodies allowed in the current scene.
- Max Trigger Number
  - The maximum number of triggers allowed in the current scene.

### Resolution Settings
- Grid Resolution
  - The resolution size of the world background grid. This value affects the precision of physical simulation.
- Fine Grid Scale
  - The ratio of the resolution of the fine grid to the world background grid. This value affects the precision of the collider and trigger.

### Collision Settings
- Normal Force Scale
  - The collision coefficient of the particles along the collider normal direction.
- Velocity Force Scale
  - The collision coefficient of the particles along the particle velocity direction.
- MeshBody Force Scale
  - The scaling factor of the mesh body's internal force.

### World Query Settings
- Enable World Query
  - Enable the world querying. Only when this option is enabled, the trigger can detect the particles passing through its area. If users close this option, the trigger will not work, but the simulation performance can be improved.