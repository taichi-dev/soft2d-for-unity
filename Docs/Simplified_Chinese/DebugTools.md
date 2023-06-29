# 调试工具
调试工具可以可视化场景中的 Soft2D Collider 和 Trigger 的位置。

> 本文中出现的 Collider 和 Trigger 均表示 Soft2D 内的碰撞体和触发器。Unity 的碰撞体和触发器会在前面标明。

## 参数面板
- 开启测试工具：打开 Debug Tools 窗口。
- Collider 颜色：Collider 显示的颜色。
- Trigger 颜色：Trigger 显示的颜色。

未开启调试工具的效果：
![](../images/disable_debugging_tools.png)

开启调试工具之后的效果：
![](../images/enable_debugging_tools.png)

## 注意事项
- 测试工具只能在 Unity 编辑器模式下开启。
- 测试工具开启后会在场景内生成一个与模拟范围位置大小相同的 Quad。它的z轴被设置为 -0.2，用户可以在场景内自由拖动查看。