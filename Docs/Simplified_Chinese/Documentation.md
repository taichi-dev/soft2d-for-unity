# 用户文档
这是 Soft2D-for-Unity 的用戶文档。

## 介绍
Soft2D 是一个实时 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D-for-Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

### 环境要求

|       Unity 版本    |   图形 API    |       渲染管线            | 脚本后端 |
|--------------------|---------------|-------------------------|---------|
|2021.3.22f1 或更高   |Vulkan 或 Metal|Built-in 或 URP           |IL2CPP   |

> 注意：MacOS 目前只支持 M1 芯片。

### 使用方法
用户可以通过两种方法使用 Soft2D-for-Unity：
1. 下载本仓库到本地，并在 Unity 中作为一个新项目打开。
2. 在 Asset Store 中下载插件文件，导入到用户已有的项目中。

#### 使用 Github 上的 Unity 项目
如果用户使用 `git` 克隆本项目，注意需要使用 `git-lfs` 来正确获取项目中的二进制文件。

#### 从 Asset Store 下载插件并导入已有项目
从 [Unity Asset Store](https://assetstore.unity.com/packages/slug/256549)下载 Soft2D-for-Unity 插件并导入到一个已存在的项目中。当导入完成后，插件会自动弹出一个启动窗口。点击“Run and Restart”会执行以下操作：
- 项目的 `Graphics API` 设置会被修改为 `Vulkan` 或 `Metal`。
- 项目的 `Scripting Backend` 设置会被修改为 `IL2CPP`。
- 如果当前管线是 URP，一个名为 `SOFT2D_URP_PIPELINE` 的宏会被添加到项目设置中。

## 用户教程
本章节介绍如何在 Unity 编辑器中使用 Soft2D-for-Unity 插件。本章节用到的所有教程场景均可以在 `Soft2D/Tutorial/` 中找到。

### 使用 Soft2DManager 并创建一个 Body
Soft2DManager 是核心的场景管理器，它负责管理场景的参数配置、渲染和管理各个物体（body、 collider 和 trigger）。场景里必须放置一个 Soft2DManager 才能使用插件的相关功能。详细介绍见 [Soft2DManager](./Soft2DManager.md)。

Body 是一个可以被模拟的连续体，由一组粒子组成。是 Soft2D-for-Unity 中最常用的类型。详细介绍见 [Body](./Body.md)。下面的视频展示了如何在编辑器中创建一个 body：

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/bed8b185-2467-4f34-be2a-81f29e271d50

[Video on YouTube](https://www.youtube.com/watch?v=gtEt04JAwVQ).


### 创建 Custom Body
Custom body 是用户指定采样点的 body。用户可以自定义 body 内部的粒子位置。详细介绍见 [Custom Body](./Body.md#custom-body)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/6954b318-e5dd-4799-b847-c89024a10ad2

[Video on YouTube](https://www.youtube.com/watch?v=-rc05NdN4jM).

### 创建 Mesh Body
Mesh body 是带有拓扑关系的 Body。每个传入网格的顶点位置会生成一个粒子，它们之间遵循网格内三角形的拓扑关系。详细介绍见 [Mesh Body](./Body.md#mesh-body)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/86027852-9290-4cf9-97d3-791f50ccc8b4

[Video on YouTube](https://www.youtube.com/watch?v=6OEG7QIWqjw).


### 创建 Emitter
Emitter 是一个能自由控制发射 body 的发射器。详细介绍见 [Emitter](./Emitter.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/7a7e637f-d03f-4057-808f-0308f2e645f1

[Video on YouTube](https://www.youtube.com/watch?v=9FR2j3EZRdE).


### 创建 Collider
Collider 是一个障碍物，会阻挡 body 的运动。详细介绍见 [Collider](./Collider.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/2ad1d54d-3126-4d91-a7b5-bc7b4512f876

[Video on YouTube](https://www.youtube.com/watch?v=e1W54tDIijg).


### 创建 Trigger
> 用户必须启用 Soft2DManager 中的`世界查询`选项，trigger 才能正常工作。见 [世界查询设置](Soft2DManager.md#世界查询设置)。

Trigger 是一个拥有特定形状的空间区域，可以检测到经过它的粒子。详细介绍见 [Trigger](./Trigger.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/025a7644-3bcf-46a0-989b-a81ce02d8dde

[Video on YouTube](https://www.youtube.com/watch?v=W67fbAGPOjU).


### 使用调试工具
使用调试工具可以对场景中的 collider 或者 trigger 进行可视化。详细介绍见 [调试工具](./DebuggingTools.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/82208770/bfe01ab7-8819-4392-a05f-3762314952f3

[Video on YouTube](https://www.youtube.com/watch?v=ECFgvXIuv4o).


### 自定义渲染效果
见 [自定义着色器](./CustomShader.md)。

## 示例场景
我们提供了数个示例场景用于展示 Soft2D-for-Unity 在游戏中的使用方法。这些示例场景可以在 `Soft2D/Samples/` 中找到。

### Sandbox
这是一个包含多个关卡的小游戏，用户可以通过鼠标、手指或者重力陀螺仪对场景中的内容进行交互。本仓库中的 unity 项目默认的打包内容是这个小游戏的所有关卡。支持 Windows/Linux/MacOS/iOS/Android 平台。

> 本场景的后处理效果只在 URP 管线中支持，Built-in 管线不支持后处理效果。

|带有后处理效果（URP 管线）|没有后处理效果（built-in 管线）|
|----------------|----------------|
|<img src="../images/sandbox.png" alt="sandbox" width="300px"> |<img src="../images/sandbox_no_postprocessing.png" alt="sandbox_no_postprocessing" width="300px"> |

### WaterWheel
> 本场景的后处理效果只在 URP 管线中支持，Built-in 管线不支持后处理效果。

|带有后处理效果（URP 管线）|没有后处理效果（built-in 管线）|
|----------------|----------------|
|<img src="../images/waterwheel.png" alt="waterwheel" width="300px"> |<img src="../images/waterwheel_no_postprocessing.png" alt="waterwheel_no_postprocessing" width="300px">  |


### Gear
该场景只支持 URP 管线。并且请使用 `3D URP` 管线以获取正确的光照效果。

<img src="../images/gear.png" alt="gear" width="300px"> 

### Maze
该场景只支持 URP 管线。并且请使用 `3D URP` 管线以获取正确的光照效果。

<img src="../images/maze.png" alt="maze" width="300px"> 


## FAQ
教程场景在 `2D URP` 管线中渲染效果表现不正常。
- 请将相机的背景设置从 `Skybox` 修改为 `Solid Color`。

<img src="../images/camera_background.png" alt="skybox_background" width="300px">

|修改前|修改后|
|----------------|----------------|
|<img src="../images/skybox_background.png" alt="skybox_background" width="300px"> |<img src="../images/solidcolor_background.png" alt="solidcolor_background" width="300px"> |

如何在一个大规模的世界中模拟很小的物体？

- 在 Soft2D-for-Unity 中，body 中粒子的采样密度会根据世界的大小来自动调整，更大的世界会导致更稀疏的粒子采样。因此，在一个较大的世界中可能没有足够的精度来模拟非常小的物体。

是否可以为不同的粒子设置不同的渲染材质。

- 目前粒子通过 `Graphics.DrawMeshInstancedIndirect()` 方法绘制，暂时不支持为不同的粒子设置不同的材质。
