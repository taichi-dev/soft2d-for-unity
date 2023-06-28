# Soft2DManager

> Soft2DManager is a script used to control and render Soft2D particles in the current scene. You need to place a Soft2DManager GameObject in the scene to use the functionalities related to Soft2D. It corresponds to the Soft2DManager class in the code.

## How to Use Soft2DManager GameObject

![gif](../../images/Soft2DManager.gif)

## Parameter Panel

The parameter panel of Soft2DManager is divided into six sections: World Settings, Debug Tool Settings, Render Settings, Time Settings, Maximum Value Settings, Resolution Settings, and Collision Settings.

### World Settings

> World is a container that includes all the objects in the scene related to simulation, and performs physical simulation on these objects according to physical rules.

- World Area Size
  - The size of the area simulated by Soft2D.
- World Offset Coordinates
  - The position of the Soft2D simulation area, where the coordinates represent the bottom-left corner of the simulation area.
- Gravity
  - The magnitude and direction of gravity in Soft2D. Only effective when gyro is turned off.
- Gyro
  - Whether to enable the gyroscope.
- Gyro Gravity
  - The magnitude of Soft2D gravity when the gyroscope is enabled. Only effective when the gyroscope is turned on.
- Force Field
  - Whether to enable the force field. When enabled, users can slide their finger or mouse in a specific area to generate a directional force that affects the movement direction and speed of particles.
- Force Field Magnitude
  - The magnitude of the force within the force field. Only effective when the force field is enabled.
- World Boundary
  - Whether to enable the boundary. When enabled, Soft2DManager automatically generates colliders at the boundaries of the simulation range to prevent particles from exceeding the simulation range.

### Debug Tool Settings

- Enable Debug Tool
  - Whether to enable the debug tool. When enabled, Soft2DManager generates a dynamic Quad that displays the colliders and triggers at their Soft2D positions when the user runs the scene.
- Collider Color
  - The color used to display colliders in the debug tool.
- Trigger Color
  - The color used to display triggers in the debug tool.

### Render Settings

- Particle Mesh Model
  - The model used for individual Soft2D particles.
- Particle Rendering Layer
  - The rendering layer of Soft2D particles.
- Particle Rendering Mode
  - The rendering material for individual Soft2D particles. We have provided three types of materials for users to choose from, while users can also write their own shaders for particle rendering. The following rendering modes are currently supported:
  - **Unlit**: Displays only color without lighting or other factors.
  - **Blinn-Phong**: A simple lighting model based on the Blinn-Phong formula, only supports URP pipeline.
  - **PBR**: A simple physically-based rendering model, only supports URP pipeline.
  - **Custom**: User-defined material. You can find relevant tutorials [here](./CustomShader.md).

### Time Settings

- Time Step
  - The time step used for Soft2D simulation.
- Substep Time
  - The internal substep time for the current time step.

### Maximum Value Settings

- Maximum Particle Count
  - The maximum number of particles allowed in the current scene.
- Maximum Body Count
  - The maximum number of bodies allowed in the current scene.
- Maximum Trigger Count
  - The maximum number of triggers allowed in the current scene.

### Resolution Settings

- Grid Resolution: The size of the grid provided by Soft2D (such as the grid in the debug tool).
- Precise Grid Resolution: The size of the precise grid provided by Soft2D.

### Collision Settings

- Normal Collision Magnitude: The magnitude of collisions along the normal direction of Soft2D particles.
- Velocity Collision Magnitude: The magnitude of collisions along the velocity direction of Soft2D particles.
- MeshBody Magnitude: The magnitude of collisions for MeshBody.

## FAQ

How can I simulate very small objects in a large-scale world?

- In Soft2D, the sampling density of particles within a body automatically adjusts based on the size of the world. A larger world may result in sparser particle sampling. Therefore, in a larger world, there may not be enough precision to simulate extremely small objects.

Is it possible to set different rendering materials for different particles?

- Currently, particles are rendered using the `Graphics.DrawMeshInstancedIndirect` method, which does not support assigning different materials to individual particles at the moment.