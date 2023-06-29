# Collider
Collider 是一个障碍物，会阻挡 body 的运动。对应代码中的 ECollider 类型。

> 除非特殊指定，本文中提到的 `Collider` 均指代 Soft2D 内的 Collider 而非 Unity 自带的 Collider。

## 参数面板
- Unity 2D 碰撞体
  - Collider 的 Unity 2D Collider 组件，目前支持Box / Circle / Capsule / Polygon / Composite 类型。
  - Collider 的类型和大小均由它的 Collider2D 组件控制。
- 是否动态
  - 否：静态。不运动。
  - 是：动态。按照用户指定的速度进行运动或者自动模拟。
- 线速度
  - 用户指定的线速度。单位为`米每秒`。
- 角速度
  - 用户指定的角速度。单位为`角度每秒`。
- 自动模拟
  - 为真时，unity将自动模拟collider，并将位置和速度同步到 Soft2D 。用户指定的速度将无效。
- 碰撞类型
  - `Separate`：粒子与 Collider 碰撞后会分开。
  - `Slip`：粒子与 Collider 碰撞后会沿其边缘滑行。
  - `Sticky`：粒子与 Collider 碰撞后会黏附在 Collider 上。
- 摩擦系数：粒子沿 Collider 边缘运动时的摩擦系数。
- 反弹系数：粒子碰撞到 Collider 上的反弹系数。

