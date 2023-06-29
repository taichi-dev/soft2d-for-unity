# Debug Tools

> The terms "Collider" and "Trigger" used in this article refer to the collision bodies and triggers within Soft2D. Unity's collision bodies and triggers will be indicated specifically.

> Debug tools provide a way for users to visualize the positions and motion states of Colliders and Triggers within Soft2D during runtime.


## Parameter Panel

- Enable Debug Tools: activate Debug Tools.
- Collider Color: represents the color of colliders in Debug Tools.
- Trigger Color: represents the color of triggers in Debug Tools.

Effect without Debug Tools:
![](../images/disable_debugging_tools.png)

Effect with Debug Tools:
![](../images/enable_debugging_tools.png)

## Important Notes

- Debug Tools can only be enabled in Unity Editor mode.
- Enabling Debug Tools will generate a Quad in the scene with the same position and size as the simulation area. Its Z-axis is set to -0.2, and users can freely drag and view it in the Scene window.
