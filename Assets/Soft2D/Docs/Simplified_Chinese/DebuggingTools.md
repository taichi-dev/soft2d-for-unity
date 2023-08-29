# 调试工具
> 除非特殊指定，本文中提及的 `collider` 和 `trigger` 均表示 Soft2D 内的 collider 和 trigger ，而不是 Unity 自带的 collider 和 trigger 。

调试工具可以可视化场景中的 collider 和 trigger 的位置。


## 参数面板
- 开启调试工具
  - 打开 Debugging Tools 窗口。
- Collider 颜色
  - Collider 显示的颜色。
- Trigger 颜色
  - Trigger 显示的颜色。

未开启调试工具的效果：
![](../images/disable_debugging_tools.png)

开启调试工具之后的效果：
![](../images/enable_debugging_tools.png)

## 注意事项
- 调试工具只能在 Unity 编辑器模式下开启。
- 调试工具开启后会在场景内生成一个与模拟区域位置大小相同的 Quad。它的z轴被设置为 -0.2，用户可以在场景内自由拖动查看。