# Collider

> Collider 是一个障碍物，会阻挡 body 的运动。对应代码中的 ECollider 类型。

> 本文中 Collider 均表示 Soft2D 内的 Collider 组件。

## 使用 Collider GameObject 的方法

![gif](../../GIFs/Collider.gif)

## 参数面板

- Unity 2D 碰撞体
  - Collider 的 Unity 2D Collider 组件，目前支持Box / Circle / Capsule / Polygon / Composite 类型。
  - Collider 的类型和大小均由它的 Collider2D 组件控制。
- 运动状态
  - Collider 为静态还是动态，为真时物体为动态。
- 线速度
  - Collider 的线速度。单位为 m/s。
- 角速度
  - Collider 的角速度。单位为角度/s。
- 自动更新位置和角度
  - 是否自动更新碰撞体的位置和角度。为真时插件会每帧将碰撞体在 Unity 的状态与 Soft2D 同步。
  - > 由于 Soft2D 与 Unity 间的时间间隔存在差别，Collider 可能在两边的运动状态并不一致。开启这项功能的碰撞体过多可能导致模拟出现卡顿。
- 碰撞类型
  - Soft2D 粒子与 Collider 碰撞后的类型，主要有三种类型可选：
  - **Separate**：粒子与 Collider 碰撞后会直接分开
  - **Slip**：粒子与 Collider 碰撞后会在上面滑行一会儿
  - **Sticky**：粒子与 Collider 碰撞后会黏附在 Collider 上
- 摩擦系数：Soft2D 粒子在 Collider 上的摩擦系数
- 反弹系数：Soft2D 粒子在 Collider 上的反弹系数

