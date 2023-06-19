# Quick Start

To ensure that some of the basic functionalities of the Soft2D-Unity plugin work properly in your project, we can create a simple scene. It can serve as a great starting point for you to understand how to use this plugin.

## Steps

0. Before starting, make sure that the Graphics API for your current platform is Vulkan, as using other Graphics APIs may cause errors or crashes:

0a. Check the Unity window's title bar; if the angle brackets at the end show Vulkan, it means that the Graphics API has been correctly set to Vulkan. If it shows a different Graphics API (such as DX11/OpenGL), follow the steps below to change the Graphics API to Vulkan:

0b. In the Unity Editor, click on the top menu bar **Edit** > **Project Settings**, and scroll down to **Other Settings** in the Player settings page;

0c. Select your current platform, uncheck **Auto Graphics API**, click the "+" button in the Graphics API list, add the Vulkan Graphics API, and drag Vulkan to the top of the current list to change its priority to the highest. This way, Unity will try to use the Graphics APIs in the list in order until it finds one that is compatible with the target device;

0d. Restart Unity and repeat step 0a; you should find that the Graphics API for the current project has been correctly changed. If not, repeat the steps or search online for solutions.

1. Create a new scene, right-click in the Hierarchy window, and click on **Soft 2D** > **Soft2DManager** to create a GameObject with the Soft2DManager script attached;

2. Soft2DManager can control the rendering and hierarchy of particles, and configure the physical environment, but for now, we only need to set the **Instance Mesh** to Sphere (which should be included with Unity);

3. Continue to right-click in the Hierarchy window, and click on **Soft 2D** > **Body** to create a Soft2D Body object;

4. A Body is a collection of Soft2D particles with a specific shape, for now, we only need to set its position to (2,2), and change both Width and Height in the **Shape Settings** to 0.3;

4a. With this, a simple scene is set up, but to display the results correctly in the Game window, we need to adjust the parameters of the Main Camera (however, it is not necessary, you can also see the results in the Scene window after running the scene):

I. Set the position of the Main Camera to (2,2);

II. Set the Main Camera's Projection to Orthographic, and adjust the Size to 2;

III. Set the Main Camera's Background Type to Solid Color, and change the Background color to pure black (RGB(0,0,0)).

5. Finally, click the Play button, and you can see the result of our scene:

### QA

1. My Body particle simulation doesn't seem quite right...

This may be due to incorrect settings of some parameters in your Soft2DManager or Body. Make sure you haven't modified any other parameters in Soft2DManager and Body. If the problem persists, delete Soft2DManager and Body and repeat the above steps.

2. My Unity throws the following error: *ArgumentNullException: Value cannot be null.
   Parameter name: mesh*

This is because no Mesh has been attached to the Instance Mesh parameter on your Soft2DManager. Make sure it is correctly attached to a Sphere or other Mesh.

3. After setting up the scene and clicking Play, Unity crashes...

This is likely because the Graphics API of your current project has not been correctly set to Vulkan. Please follow step 0 to ensure that the Graphics API for your current Unity project's platform has been correctly set to Vulkan.

4. I've carefully checked all the issues mentioned above and made sure they are correctly set, but the scene still has problems...

Please gather your error messages and scene performance information and contact us. You can open an issue in our GitHub repository or contact us directly on Discord!

In the next section, we will introduce the functionality and usage of each component of the Soft2D-Unity plugin, starting with Soft2DManager.
