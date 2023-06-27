# Collider

> A Collider is an obstacle that obstructs the movement of a body. It corresponds to the `ECollider` type in the code.

> In this article, Collider refers to the collider component within Soft2D.

## How to Use Collider GameObject

![gif](../../GIFs/Collider.gif)

## Parameter Panel

- Unity 2D Collider
  - The Unity 2D Collider component of the Collider, currently supporting Box / Circle / Capsule / Polygon / Composite types.
  - The type and size of the Collider are controlled by its Collider2D component.
- Motion State
  - Whether the Collider is static or dynamic. When true, the object is dynamic.
- Linear Velocity
  - The linear velocity of the Collider. Measured in m/s.
- Angular Velocity
  - The angular velocity of the Collider. Measured in s^-1.
- Update Position and Rotation Automatically
  - Whether to automatically update the position and rotation of the collider. When true, the plugin synchronizes the collider's state with Soft2D every frame.
  - > Due to the time interval difference between Soft2D and Unity, the Collider's motion state may not be consistent on both sides. Enabling this feature for too many colliders may cause simulation lag.
- Collision Type
  - The collision type between Soft2D particles and the Collider. There are three types:
  - **Separate**: Particles separate from the Collider immediately after collision.
  - **Slip**: Particles slide on the Collider for a while after collision.
  - **Sticky**: Particles stick to the Collider after collision.
- Friction Coefficient: The friction coefficient between Soft2D particles and the Collider.
- Restitution Coefficient: The restitution coefficient (bounciness) of Soft2D particles on the Collider.

