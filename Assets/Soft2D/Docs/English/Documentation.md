# User Documentation
This is the user documentation for Soft2D-for-Unity.

## Introduction
Soft2D is a 2D multi-material continuum physics engine designed for real-time applications. Soft2D for Unity provides a high-level encapsulation for Soft2D and offers users a range of easy-to-use interfaces, enabling users to easily implement various physical simulations and rendering effects in Unity.

### Environment Requirements

|     Unity Version    |Graphics API    | Rendering Pipeline   | Scripting Backend |
|----------------------|----------------|----------------------|-------------------|
|2021.3.22f1 or higher |Vulkan or Metal |Built-in or URP       |IL2CPP             |

> Note: MacOS currently only supports M1 chips.

### How to Use
Users can use Soft2D-for-Unity in two ways:
1. Download this repository and open it as a new project in Unity.
2. Download the plugin package file from the Asset Store and import it into an existing project.

#### Using the Unity Project on Github
If you clone this project using `git`, make sure to use `git-lfs` to correctly pull the binary files in the project.

#### Download Plugin from Asset Store and Import into Existing Project
Download the Soft2D-for-Unity plugin from the [Unity Asset Store](https://assetstore.unity.com/packages/slug/256549) and import it into an existing project. Once the import is complete, the plugin will automatically pop up a start-up window. Clicking "Run and Restart" will perform the following actions:
- The project's `Graphics API` setting will be modified to `Vulkan` or `Metal`.
- The project's `Scripting Backend` setting will be modified to `IL2CPP`.
- If the current rendering pipeline is the URP, a macro `SOFT2D_URP_PIPELINE` will be added into the project settings.

## User Tutorial
This section introduces how to use the Soft2D-for-Unity plugin in the Unity editor. All tutorial scenes used in this section can be found in `Soft2D/Tutorial/`.

### Using Soft2DManager and Creating a Body
`Soft2DManager` is the core scene manager, responsible for managing scene parameter configuration, rendering, and managing objects (bodies, colliders, and triggers). A Soft2DManager must be placed in the scene to use the related functions of the plugin. For more details, see [Soft2DManager](./Soft2DManager.md).

A body is a continuum that can be simulated, composed of a group of particles. It is the most common object in Soft2D-for-Unity. For more details, see [Body](./Body.md). The following video shows how to create a body in the editor:

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/bed8b185-2467-4f34-be2a-81f29e271d50

[Video on YouTube](https://www.youtube.com/watch?v=gtEt04JAwVQ).

### Creating a Custom Body
A custom body is a body with user-specified sample points. Users can customize the particle positions within the body. For more details, see [Custom Body](./Body.md#custom-body).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/6954b318-e5dd-4799-b847-c89024a10ad2

[Video on YouTube](https://www.youtube.com/watch?v=-rc05NdN4jM).


### Creating a Mesh Body
A mesh body is a body with topological relationships. Each vertex position of the input mesh will generate a particle, and they follow the topology of the triangles within the mesh. For more details, see [Mesh Body](./Body.md#mesh-body).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/86027852-9290-4cf9-97d3-791f50ccc8b4

[Video on YouTube](https://www.youtube.com/watch?v=6OEG7QIWqjw).


### Creating an Emitter
An emitter is an object that can freely control the emission of bodies. For more details, see [Emitter](./Emitter.md).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/7a7e637f-d03f-4057-808f-0308f2e645f1

[Video on YouTube](https://www.youtube.com/watch?v=9FR2j3EZRdE).


### Creating a Collider
A collider is an obstacle that blocks the movement of bodies. For more details, see [Collider](./Collider.md).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/2ad1d54d-3126-4d91-a7b5-bc7b4512f876

[Video on YouTube](https://www.youtube.com/watch?v=e1W54tDIijg).


### Creating a Trigger
> Users must enable the `World Query` option in `Soft2DManager` for the trigger to work properly. See [World Query Settings](./Soft2DManager.md#world-query-settings).

A trigger is a spatial region with a specific shape that can detect particles passing through it. For more details, see [Trigger](./Trigger.md).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/025a7644-3bcf-46a0-989b-a81ce02d8dde

[Video on YouTube](https://www.youtube.com/watch?v=W67fbAGPOjU).


### Using Debugging Tools
Debugging tools can be used to visualize colliders or triggers in the scene. For more details, see [Debugging Tools](./DebuggingTools.md).

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/bfe01ab7-8819-4392-a05f-3762314952f3

[Video on YouTube](https://www.youtube.com/watch?v=ECFgvXIuv4o).


### Customizing Rendering Effects
See [Custom Shaders](./CustomShader.md).

## Sample Scenes
We provide several sample scenes to demonstrate how to use Soft2D-for-Unity in games. These sample scenes can be found in `Soft2D/Samples/`.

### Sandbox
This is a game with multiple levels. Users can interact with the content in the scene through the mouse, fingers, or a gyroscope. The default building content of the Unity project in this repository is all the levels of this game. Supports Windows/Linux/MacOS/iOS/Android platforms.

> In this scene, the post-processing effect is only supported in the URP pipeline. The built-in pipeline does not support the post-processing effect.

|With Post-processing (URP)|Without Post-processing (Built-in)|
|----------------|----------------|
|<img src="../images/sandbox.png" alt="sandbox" width="300px"> |<img src="../images/sandbox_no_postprocessing.png" alt="sandbox_no_postprocessing" width="300px"> |

### WaterWheel
> In this scene, the post-processing effect is only supported in the URP pipeline. The built-in pipeline does not support the post-processing effect.

|With Post-processing (URP)|Without Post-processing (Built-in)|
|----------------|----------------|
|<img src="../images/waterwheel.png" alt="waterwheel" width="300px"> |<img src="../images/waterwheel_no_postprocessing.png" alt="waterwheel_no_postprocessing" width="300px">  |


### Gear
> This scene only supports the URP pipeline. And please use `3D URP` pipeline to ensure correct lighting effects.


<img src="../images/gear.png" alt="gear" width="300px"> 

### Maze
> This scene only supports the URP pipeline. And please use `3D URP` pipeline to ensure correct lighting effects.

<img src="../images/maze.png" alt="maze" width="300px">

## FAQ
The tutorial scenes does not render correctly in the `2D URP` pipeline.
- Please change the background of camera from `Skybox` to `Solid Color`.

<img src="../images/camera_background.png" alt="skybox_background" width="300px">

|Skybox          |Solid Color     |
|----------------|----------------|
|<img src="../images/skybox_background.png" alt="skybox_background" width="300px"> |<img src="../images/solidcolor_background.png" alt="solidcolor_background" width="300px"> |

How to simulate very small objects in a large-scale world?

 - In Soft2D-for-Unity, the sampling density of the particles in a body is automatically adjusted based on the size of the world. A larger world will lead to sparser particle sampling. Therefore, there may not be enough precision to simulate very small objects in a larger world.

Can different rendering materials be set for different particles?

 - Currently, particles are drawn using the `Graphics.DrawMeshInstancedIndirect()`method, which temporarily does not support setting different materials for different particles.
