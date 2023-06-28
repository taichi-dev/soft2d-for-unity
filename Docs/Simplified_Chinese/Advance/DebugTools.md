# Debug Tools

> 本文中出现的 Collider 和 Trigger 均表示 Soft2D 内的碰撞体和触发器。Unity 的碰撞体和触发器会在前面标明。

> 测试工具可以让用户在场景运行时看到 Collider 和 Trigger 在 Soft2D 内的位置和运动状态。

## 视频链接

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/026ecf9b-a9bd-4b98-847d-d41d1d371671


## 参数面板

- 开启测试工具：打开 Debug Tools 窗口。
- 碰撞体颜色：在测试工具里表示碰撞体的颜色。
- 触发器颜色：在测试工具里表示触发器的颜色。

未开启测试工具的效果：
![img_2.png](img_2.png)

开启测试工具的效果：
![img_1.png](img_1.png)

## 注意事项
- 测试工具只能在 Unity 编辑器模式下开启。
- 测试工具开启后会在场景内生成一个与模拟范围位置大小相同的 Quad。它的z轴被设置为 -0.2，用户可以在场景内自由拖动查看。