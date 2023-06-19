# Soft2DManager

Soft2DManager is a script used to control and render Soft2D particles in the current scene. You can use Soft2DManager to:

- Modify the rendering method of a single Soft2D particle.

- Adjust the current physical environment configuration.

- Enable or disable the testing tool, which displays the position, size, and status of collision bodies and triggers within Soft2D.

In addition to the three user-editable options above, Soft2DManager also obtains relevant information about Soft2D particles internally. If you want to use Soft2D in a Unity scene, Soft2DManager is essential.

Since Soft2DManager is set as a singleton, you can easily access and adjust its parameters in both the Inspector and other scripts! We will introduce Soft2DManager's parameters and functions from the three types mentioned above.

## Rendering method

We can adjust the size, shape, and material of Soft2D particles through Soft2DManager. These parameters are integrated into the **Render Settings** section of the Inspector window:

### Instance Mesh

The current shape of a single Soft2D particle. In the previous Quick Start tutorial, we set it as a sphere, but it can actually be designed as any Mesh shape.

### Particle Sorting Layer

The rendering layer of Soft2D particles. You can render particles to a dedicated layer for post-processing and other operations.

### Particle Render Mode

The rendering material of a single Soft2D particle. We have written three types of materials for users, but users can also write their own shaders to render particles. We currently support the following rendering modes:

    **Unlit**: displays only color without lighting or other factors.

    **Blinn-Phong**: a simple lighting model based on the Blinn-Phong formula.

    **PBR**: a simple physical rendering model based on PBR.

    **Custom**: a user-defined material, which we will introduce in the following chapters on shader writing.

In the three materials we wrote, in addition to the parameters specific to the materials themselves, there is a parameter named **Instance Size**, which is used to control the size of a single Soft2D particle.

## Physical environment configuration

We can adjust the gravity, size, and step of the current Soft2D simulation environment through Soft2DManager. These parameters are integrated into the **World Settings** section of the Inspector window:

### World Extent

A Vector2 type variable used to set the size of the Soft2D simulation area. Soft2D supports simulation within a rectangle, with the lower left corner of the rectangle at the coordinate (0,0) and the upper right corner represented by the World Extent variable. If there are problems with particle motion when running the scene in the previous Quick Start tutorial, it may be due to an error in the World Extent setting.

#### Note

Soft2D particles can only be simulated within the simulation area. Particles outside this area may produce unexpected errors, possibly causing explosions or remaining stationary. Therefore, please set the size and position of the simulation area before simulation and ensure that all generated particles are within the simulation area.

A simulation area that is too large may cause problems with the simulation results. It is recommended to set the maximum size of the simulation area to (4, 4).

### Gravity

A Vector2 type variable used to set the size and direction of Soft2D gravity. This variable is only effective when the gyro is turned off. When the gyro is turned on, this parameter is hidden in the Inspector panel.

### Gyro

#### Enable Gyro

A boolean variable used to enable gyro-controlled gravity. When enabled, the gravity direction in the simulation environment changes as the device rotates, resulting in a more realistic physics simulation.

##### Note

Before using Enable Gyro, make sure that the device's gyroscope sensor is available. The plugin will throw an error if the gyroscope is enabled but not supported by the device.

#### Gyro Scale

A Vector2 variable used to set the size of Soft2D gyro gravity. This parameter is only effective when the gyro is enabled. When the gyro is disabled, this parameter is hidden in the Inspector panel.

### World Step

A float variable used to set the update frequency of the current physics simulation. Changing this parameter may cause synchronization errors between Unity and Soft2D, so it is recommended not to modify it.

### Force Field

#### Enable Force Field

A boolean variable used to enable force fields. When enabled, the user can slide their finger or mouse in a certain area to generate a force in a direction that affects the direction and speed of particles. When using this feature, the user can adjust the parameters of the force field to achieve the desired motion effect.

#### Force Field Scale

A float variable used to set the size of the forces within the force field.

##### Note

Setting too large of a parameter may cause errors in the movement of related particles, so please adjust with caution.

## Testing Tools

Since Soft2D operates independently of the Unity engine, the Soft2D-Unity plugin needs to pass collision and trigger information to Soft2D's internals for re-generation. To ensure that Soft2D correctly creates collisions and triggers, we provide a testing tool that allows users to view their positions and triggering status in Unity. The process of passing collision and trigger information and creating them will be discussed in detail in later chapters.

### Enable Debug Tools

A boolean variable used to enable testing tools. When enabled, a Quad is dynamically generated in the scene that displays the positions of the collision and trigger and provides real-time feedback on the triggering status.

#### Note

The testing tool can only be used when the scene is running. The Quad generated during runtime has a fixed z-axis position of -0.2. You can modify the position of the Quad object on the z-axis during runtime as needed to achieve better testing results.

### Collider Color

A Color variable used to set the color of the collision on the testing tool.

### Trigger Color

A Color variable used to set the color of the trigger on the testing tool.

### Active Trigger Color

A Color variable used to set the color of the trigger when it is triggered on the testing tool.

## QA

### These three preset materials don't really meet my needs...

In the future, we may add several cartoon materials that support 2D. In fact, we have already created them. If you want to write your own material to render each Soft2D particle, please be sure to read the subsequent Shader chapter to achieve the desired rendering effect.

### The 4x4 simulation range still seems too small. I want to use this plugin for a large-scale scene.

In fact, this is indeed a difficult problem because if the physical simulation range of Soft2D is too large, the gravity and interaction forces of particles will have significant deviations, which will affect the accuracy and stability of the simulation. We have two alternative solutions to this problem:

1. Adjust the position of the simulation area by using the WorldOffset method. If your camera only needs to display a small area of a large scene, you can dynamically adjust the position of the simulation range to move with the camera. However, this method can only adjust the position of the simulation and not its size.

2. Scale down the current scene to fit within the simulation range. This method can solve the simulation problem, but it may be cumbersome to build the scene because object movement and scaling may need to be precise to several decimal places.

### When I enable the gyro function, does the Gravity variable still control the current gravity level?

No, it doesn't. When you enable the gyro function, the gravity level of the current scene is controlled by the Gyro Scale variable, and it is not related to the Gravity variable's size. Conversely, if you disable the gyro function, the current scene's gravity level is controlled by the Gravity variable, and it is not related to the Gyro Scale variable's size. These two variables are independent of each other and control different physical characteristics.

### I can set the rendering material for the particles, but how can I set the color of the particles? / Can I set different rendering materials for different particles?

Setting multiple rendering materials for particles in the Soft2D-Unity plugin can cause severe system lag, as the particles are not rendered as GameObjects, but rather with the `Graphics.DrawMeshInstancedIndirect` method. Therefore, we only allow particles to use a single rendering material, and their color can be specified within the Body and Emitter components, which we will cover in detail in the following chapters.
