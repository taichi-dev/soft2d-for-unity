# User Documentation

> This is the user documentation for Soft2D for Unity, which can help you quickly get started with it.

## Introduction

Soft2D is a 2D multi-material continuum physics engine designed for real-time applications. Soft2D for Unity provides a high-level encapsulation for Soft2D and offers users a range of easy-to-use interfaces, enabling users to easily implement various physical simulations and rendering effects in Unity.

## Prerequisites

|     Unity Version    |Graphics API    | Rendering Pipeline   | Scripting Backend |
|----------------------|----------------|----------------------|-------------------|
|2021.3.22f1 or higher |Vulkan or Metal |2D built-in or 3D URP |IL2CPP             |


## Installation

Users can have 2 ways to use Soft2D: 1. Download this github repository and open as a Unity project. 2. Download Soft2D-for-Unity Plugin from Unity Asset Store and import it into existing projects.

### Use Github Project
If users are using `git` to clone this project, please use `git-lfs` to ensure pulling binary files correctly.
### Import Soft2D-for-Unity plugin into existing projects
Download this plugin from [Unity Asset Store](https://assetstore.unity.com/packages/slug/256549) and import it into an existing project. After the import is completed, the plugin will automatically display a startup window. Click `Run and Restart` will perform the following operations:
- The project's `Graphics API` setting will be changed to `Vulkan` or `Metal`.
- The `Scripting Backend` setting will be changed to `IL2CPP`.
- If the current pipeline is not Universal Render Pipeline, URP-related files in the plugin will be automatically removed.


## Using Soft2DManager && Creating a Body

> In this tutorial, we will introduce how to create a simple scene by Soft2D for Unity and implement Soft2D simulation features.

- Create a new Unity scene. Right-click in the Hierarchy window and create a **Soft2DManager** object through Soft2D -> Soft2DManager. Soft2DManager is a script used to control and render Soft2D particles in the current scene. You can [click here](./Soft2DManager.md) to view its detailed introduction. 
- Create a **Body** object through Soft2D -> Body -> Body. A body is a continuum to be simulated, which is composed of a group of particles. You can [click here](./Body.md) to see its detailed introduction.
- Finally, since the created Body object is not within the simulation range of Soft2D (the initial setting is a 1x1 square with the bottom left corner at the origin), we need to move the object into the simulation range (e.g., (0.5, 0.8)).
- To have a better visual experience after running, you can adjust the camera to the appropriate size and position.

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/6922f3a3-71bb-4118-97e9-0baa2d80e945


## Creating a Custom Body

> In this tutorial, we will introduce how to create a CustomBody, as well as its features and functions.

Both CustomBody and Body belong to the `S2Body` type in Soft2D. However, Body can only be set to fixed shapes (e.g., Box/Circle/Capsule), while in CustomBody, users can customize the number of particles and the position of each particle. You can [click here](./Body.md) to view its detailed introduction.

The following is the process of creating and using **CustomBody**:
- Create a **Soft2DManager** object through Soft2D -> Soft2DManager in a new Unity scene.
- Create a **CustomBody** object through Soft2D -> Body -> CustomBody.
- Modify the quantity and position of particles within the **Inspector** window of the **CustomBody** object:
  - Locate the **Points Positions** option and input three `Vector2` into it: (0,0), (0.05,0), (0.025,0.05).
- Move the **CustomBody** object into the simulation range (e.g., (0.5,0.8)).


https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/bcb8d860-8435-4a33-832a-618c5eb4dff6


## Creating a Mesh Body

> In this tutorial, we will introduce how to create a MeshBody, as well as its features and functions.

MeshBody also belongs to the S2Body type of Soft2D. We can input a 2D texture with a mesh into MeshBody. MeshBody will generate a particle for each vertex, and the particles will have the same topology as the mesh. You can [click here](./Body.md) to view its detailed introduction.

The following is the process of creating and using **MeshBody**:
- Create a **Soft2DManager** object through Soft2D -> Soft2DManager in a new Unity scene.
- Create a **MeshBody** object through Soft2D -> Body -> CustomBody.
- Then we need to generate mesh for the 2D texture:
  - Click the **Sprite Editor** button.
  - Click the **Sprite Editor** button in the Inspector window of the preset 2D texture to enter the **Sprite Editor** window.
  - Change Sprite Editor to Skinning Editor in the top left corner, and select **Auto Weights** in the newly generated window on the left to make Unity automatically generate the mesh.
  - Click the **Generate All** button, and click the **Apply** button above to save settings.
  - At this point, the mesh has been generated completely.
- Find the EMeshBody script under the MeshBody object and attach the 2D texture to the **Mesh Sprite**. Adjust its scale by **Mesh Scale**.
- Move the **MeshBody** object into the simulation range (e.g., (0.5,0.8)).


https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a9a608d9-a5b5-4927-96e4-c20d4e9b1d6c


## Creating an Emitter

> In this tutorial, we will introduce how to create an Emitter, as well as its features and functions.

An emitter is an object that can continuously emit bodies. You can [click here](./Emitter.md) to view its detailed introduction.

The following is the process of creating and using **Emitter**:
- Create a **Soft2DManager** object through Soft2D -> Soft2DManager in a new Unity scene.
- Create an **Emitter** object through Soft2D -> Emitter.
- Move the **Emitter** object into the simulation range (e.g., (0.5,0.8)).
- Toggle **Emit On Awake** in `EEmitter` script. In this way, the **Emitter** will start emitting preset bodies at the beginning of the scene's execution.
- At this point, we can change the style of the Body emitted by **Emitter**:
  - Change the Material Type to **Elastic**.
  - Change the Shape Type to **Box**.
  - Change Half Width and Half Height to 0.05.
  - Change **Base Color** (such as orange).

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/444ce93b-6727-4edb-80c2-81954cc613da


## Creating a Collider

> In this tutorial, we will introduce how to create a Collider, as well as its features and functions.

A collider is an obstacle within the world that blocks the motion of bodies. Since **Collider** in Soft2D cannot interact with Unity objects, we have bound Soft2D's Collider with Unity's Collider2D. You can [click here](./Collider.md) to view its detailed introduction.

We will use the scene from the Emitter chapter to introduce the process of creating and using Collider:
- Create a **Collider** object through Soft2D -> Collider.
- Move the **Collider** object into the simulation range (e.g., (0.5,0.8)).

> You can use [Debug Tools](./DebugTools.md) to check Collider's position in Soft2D.

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/24fb1448-2bc7-49ed-915d-3ca825e6ef97

## Creating a Trigger

> In this tutorial, we will introduce how to create a Trigger, as well as its features and functions.

A trigger is a spatial area with a specific shape, which is able to detect particles passing through it. You can [click here](./Trigger.md) to view its detailed introduction.

We will use the scene from the Collider chapter to introduce the process of creating and using Trigger:
- Remove the **Collider** object.
- Create a **Trigger** object through Soft2D -> Trigger.
- Move the **Trigger** object into the simulation range (e.g., (0.5,0.8)).
- Create a new script and name it `TriggerExample.cs`, copy the following code into the script:

```csharp
using System;
using Taichi.Soft2D.Generated;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public ETrigger trigger;

    [AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateTrigger1(IntPtr particles, uint size)
    {
        if(size > 0)
            Debug.Log("Trigger activated");
    }

    public void Update()
    {
        trigger.InvokeCallbackAsync(ManipulateTrigger1);
    }
}
```

- Create an empty GameObject, load `TriggerExample.cs` into this GameObject.
- Attach the **Trigger** object to the variable named "Trigger" in the `TriggerExample.cs` script.

> You can use [Debug Tools](./DebugTools.md) to check Trigger's position in Soft2D.

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/5a1e835a-df52-4302-96a5-02fbfcff12fa


## Using Debugging Tools
[Debug Tools](./DebugTools.md)

## Custom Rendering Effects
[Custom Soft2D Shader](./CustomShader.md)

