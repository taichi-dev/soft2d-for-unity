# Collider
> 除非特殊指定，本文中提到的 `collider` 均指代 Soft2D 内的 collider 而非 Unity 自带的 collider。

Collider 是一个障碍物，会阻挡 body 的运动。对应代码中的 `ECollider` 类型。


## 参数面板
- Unity 2D 碰撞体
  - Collider 的 Unity 2D collider 组件，目前支持 Box / Circle / Capsule / Polygon / Composite 类型。
  - Collider 的类型和大小均由它的 Collider2D 组件控制。
- 是否动态
  - 否：静态。不运动。
  - 是：动态。按照用户指定的速度进行运动或者自动模拟。
- 线速度
  - 用户指定的线速度。单位为`米每秒`。
- 角速度
  - 用户指定的角速度。单位为`角度每秒`。
- 自动校正
  - 为真时每帧会把 Unity collider 的位置和速度自动同步到 Soft2D。
- 碰撞类型
  - `Separate`：粒子与 collider 碰撞后会分开。
  - `Slip`：粒子与 collider 碰撞后会沿其边缘滑行。
  - `Sticky`：粒子与 collider 碰撞后会黏附在 collider 上。
- 摩擦系数
  - 粒子沿 collider 边缘运动时的摩擦系数。
- 反弹系数：
  - 粒子碰撞到 collider 上的反弹系数。

