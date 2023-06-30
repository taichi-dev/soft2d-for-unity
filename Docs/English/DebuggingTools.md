# Debugging Tools
> Unless specifically stated, the terms 'collider' and 'trigger' in this document refer to the collider and trigger within Soft2D, not the built-in collider and trigger in Unity.

Debugging tools can visualize the colliders and triggers in the scene.


## Parameter Panel
- Enable Debugging Tools
  - Enable the Debugging Tools.
- Collider Color
  - The color of colliders.
- Trigger Color
  - The color of triggers.


The effect without enabling the debugging tools:
![](../images/disable_debugging_tools.png)

The effect after enabling the debugging tools:
![](../images/enable_debugging_tools.png)

## Notes
- Debugging tools can only be enabled in Unity Editor mode.
- After the debugging tools are enabled, a `Quad` with the same position and size as the simulation area will be generated in the scene. Its z-axis is set to -0.2, which users can freely drag to view within the scene.