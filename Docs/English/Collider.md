# Collider
> Unless specifically stated, the term 'collider' in this document refers to the collider within Soft2D, not the Unity built-in collider.

A collider is an obstacle that blocks the movement of bodies. In the code, it corresponds to the `ECollider` type.

## Parameter Panel
- 2D Collider
  - The Unity 2D collider component of the Collider, currently supports Box / Circle / Capsule / Polygon / Composite types.
  - The type and size of the Collider are controlled by its Collider2D component.
- Dynamic
  - No: Static. Not moving.
  - Yes: Dynamic. Moves at the user-specified speed or simulates automatically.
- Linear Velocity
  - The user-specified linear velocity, measured in `meters per second`.
- Angular Velocity
  - The user-specified angular velocity, measured in `degrees per second`.
- Auto correction
  - When set to true, it will automatically synchronize the position and speed of the Unity collider to Soft2D every frame.
- Collision Type
  - `Separate`: Particles will leave the collider after colliding with the collider.
  - `Slip`: Particles will slide along the edge after colliding with the collider.
  - `Sticky`:  Particles will stick to the collider after collision.
- Friction Coefficient
  - The friction coefficient when particles move along the edge of the collider.
- Restitution Coefficient
  - The bounce coefficient when particles collide with the collider.

