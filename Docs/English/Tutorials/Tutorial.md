# Soft2D-Tutorial

> This is a tutorial for Soft2D for Unity, which can help you quickly get started with it.

## Basic Settings

> In this tutorial, we will introduce how to import Soft2D for Unity into a Unity project and complete the basic setup.

You can import Soft2D for Unity through Unity Asset Store and Github.

- Unity Asset Store
   - Visit Soft2D for Unity in Unity Asset Store: [Soft2D for Unity](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041);
   - Click the **Add to My Assets** to add the plugin to your Unity account;
   - Return to the Unity Editor and open the **PackageManager** window by selecting Windows->Package Manager.
   - Select the **My Assets** tab in the **PackageManager** window, locate the Soft2D plugin, and click the **Download** button.

- Github 
   - Visit Soft2D for Unity in Github: [Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity);
   - Get the appropriate version of the plugin on the **Release** page and download it;
   - Unzip it anywhere in your Unity Assets folder (except the Editor, Plugins or Resources directories).

After the import is complete, the plugin will automatically display a startup window. Please follow the window process to set up the current project.

Video: [BasicSetup]()

## Quick Start

> In this tutorial, we will introduce how to create a simple scene by Soft2D for Unity and implement Soft2D simulation features.

- Create a new Unity scene. Right-click in the Hierarchy window and create a **Soft2DManager** object through Soft2D->Soft2DManager. Soft2DManager is a script used to control and render Soft2D particles in the current scene. You can [click here](../BasicComponents/Soft2DManager.md) to view its detailed introduction. 
- Create a **Body** object through Soft2D->Body->Body. A body is a continuum to be simulated, which is composed of a group of particles. You can [click here](../BasicComponents/Body.md) to see its detailed introduction.
- Finally, since the created Body object is not within the simulation range of Soft2D (the initial setting is a 1x1 square with the bottom left corner at the origin), we need to move the object into the simulation range. (e.g.: (0.5,0.8)).
- To have a better visual experience after running, you can adjust the camera to the appropriate size and position.

Video: [QuickStart](../../GIFs/Body.mp4)

## CustomBody

> In this tutorial, we will introduce how to create a CustomBody, as well as its features and functions.

Both CustomBody and Body are belong to the `S2Body` type in Soft2D. However, Body can only be set to fixed shapes (e.g.: Box/Circle/Capsule), while in CustomBody, users can customize the number of particles and the position of each particle. You can [click here](../BasicComponents/Body.md) to view its detailed introduction.

The following is the process of creating and using **CustomBody**:
- Create a **Soft2DManager** object through Soft2D->Soft2DManager in a new Unity scene;
- Create a **CustomBody** object through Soft2D->Body->CustomBody;
- Modify the quantity and position of particles within the **Inspector** window of the **CustomBody** object:
  - Locate the **Points Positions** option and input three `Vector2` into it: (0,0), (0.05,0), (0.025,0.05).
- Move the **CustomBody** object into the simulation range. (e.g.: (0.5,0.8)).

Video: [CustomBody](../../GIFs/CustomBody.mp4)

## MeshBody

> In this tutorial, we will introduce how to create a MeshBody, as well as its features and functions.

MeshBody also belongs to the S2Body type of Soft2D. We can input a 2D texture with a mesh into MeshBody. MeshBody will generate a particle for each vertex, and the particles will have the same topology as the mesh. You can [click here](../BasicComponents/Body.md) to view its detailed introduction.

The following is the process of creating and using **MeshBody**:
- Create a **Soft2DManager** object through Soft2D->Soft2DManager in a new Unity scene;
- Create a **MeshBody** object through Soft2D->Body->CustomBody;
- Then we need to generate mesh for the 2D texture:
  - Click **Sprite Editor** button 
  - Click the **Sprite Editor** button in the Inspector window of the preset 2D texture to enter the **Sprite Editor** window.
  - Change Sprite Editor to Skinning Editor in the top left corner, and select **Auto Weights** in the newly generated window on the left to make Unity automatically generate the mesh;
  - Click **Generate All** button, and click **Apply** button above to save settings;
  - At this point, the mesh has been generated completely.
- Find the E Mesh Body script under the MeshBody object and attach the 2D texture to the **Mesh Sprite**. Adjust its scale by **Mesh Scale**;
- Move the **MeshBody** object into the simulation range. (e.g.: (0.5,0.8)).

Video: [MeshBody](../../GIFs/MeshBody.mp4)

## Emitter

> In this tutorial, we will introduce how to create an Emitter, as well as its features and functions.

An emitter is an object that can continuously emit bodies. You can [click here](../BasicComponents/Emitter.md) to view its detailed introduction.

The following is the process of creating and using **Emitter**:
- Create a **Soft2DManager** object through Soft2D->Soft2DManager in a new Unity scene;
- Create an **Emitter** object through Soft2D->Emitter；
- Move the **Emitter** object into the simulation range. (e.g.: (0.5,0.8)).
- Toggle **Emit On Awake** in `E Emitter` script.In this way, the **Emitter** will start emitting preset bodies at the beginning of the scene's execution;
- At this point, we can change the style of the Body emitted by **Emitter**:
  - Change the Material Type to **Elastic**;
  - Change the Shape Type to **Box**;
  - Change Half Width and Half Height to 0.05;
  - Change **Base Color** (such as orange).

Video: [Emitter](../../GIFs/Emitter.mp4)

## Collider

> In this tutorial, we will introduce how to create a Collider, as well as its features and functions.

A collider is an obstacle within the world that blocks the motion of bodies. Since **Collider** in Soft2D cannot interact with Unity objects, we have bound Soft2D's Collider with Unity's Collider2D. You can [click here](../BasicComponents/Collider.md) to view its detailed introduction.

We will use the scene from the Emitter chapter to introduce the process of creating and using Collider:
- Create a **Collider** object through Soft2D->Collider;
- Move the **Collider** object into the simulation range. (e.g.: (0.5,0.8)).

> You can use [Debug Tools](../Advance/DebugTools.md) to check Collider's position in Soft2D.

Video: [Collider](../../GIFs/Collider.mp4)

## Trigger

> In this tutorial, we will introduce how to create a Trigger, as well as its features and functions.

A trigger is a spatial area with a specific shape, which is able to detect particles passing through it. You can [click here](../BasicComponents/Trigger.md) to view its detailed introduction.

We will use the scene from the Collider chapter to introduce the process of creating and using Trigger:
- Remove the **Collider** object.
- Create a **Trigger** object through Soft2D->Trigger;
- Move the **Trigger** object into the simulation range. (e.g.: (0.5,0.8)).
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

- Create an empty GameObject, load `TriggerExample.cs` into this GameObject;
- Attach the **Trigger** object to the variable named "Trigger" in the `TriggerExample.cs` script.

> You can use [Debug Tools](../Advance/DebugTools.md) to check Trigger's position in Soft2D.

> You can [click here](../Advance/CustomTrigger.md) to view the tutorial about the Soft2D custom shader.

Video: [Trigger](../../GIFs/Trigger.mp4)
