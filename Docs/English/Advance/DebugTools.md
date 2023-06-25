# Debug Tools

> The terms "Collider" and "Trigger" used in this article refer to the collision bodies and triggers within Soft2D. Unity's collision bodies and triggers will be indicated specifically.

> Debug tools provide a way for users to visualize the positions and motion states of Colliders and Triggers within Soft2D during runtime.

## Video

[Video](../../GIFs/DebugTools.mp4) 

## Parameter Panel

- Enable Debug Tools: open the Debug Tools window.
- Collider Color: represents the color of colliders in the Debug Tools.
- Trigger Color: represents the color of triggers in the Debug Tools.

Effect without Debug Tools:
![img_2.png](img_2.png)

Effect with Debug Tools:
![img_1.png](img_1.png)

## Important Notes

- The Debug Tools can only be enabled in Unity Editor mode.
- Enabling the Debug Tools will generate a Quad in the scene with the same position and size as the simulation area. Its z-axis is set to -0.2, and users can freely drag and view it in the scene.