# 用户文档

> 这是 Soft2D-for-Unity 的用戶文档，它可以帮助你快速上手 Soft2D 插件。

## 介绍

Soft2D 是一个实时 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

### 环境要求

|       Unity 版本    |   图形 API    |       渲染管线            | 脚本后端 |
|--------------------|---------------|-------------------------|---------|
|2021.3.22f1 或更高   |Vulkan 或 Metal|2D built-in 或 3D URP     |IL2CPP   |

### 使用方法
用户可以通过两种方法使用 Soft2D-for-Unity：
1. 下载本仓库到本地，并在 Unity 中作为一个项目打开。
2. 在 Asset Store 中下载插件文件，导入到用户自己的项目中。

#### 使用 Github 上的 Unity 项目
如果用户使用 `git` 克隆本项目，注意需要使用 `git-lfs` 来正确获取项目中的二进制文件。

#### 从 Asset Store 下载插件并导入已有项目
从 [Unity Asset Store](https://assetstore.unity.com/packages/slug/256549)下载 Soft2D-for-Unity 插件并导入到一个已存在的项目中。当导入完成后，插件会自动弹出一个启动窗口。点击“Run and Restart”会执行以下操作：
- 项目的 `Graphics API` 设置会被修改为 `Vulkan` 或 `Metal`。
- 项目的 `Scripting Backend` 设置会被修改为 `IL2CPP`。
- 如果当前渲染管线不是 URP 管线，插件中与 URP 相关的文件会自动被删除。

## 用户教程
本章节介绍如何创建各种物体。本章节用到的所有教程场景均可以在 `Soft2D/Samples/Tutorial/` 中找到。

## 使用 Soft2DManager 并创建一个 Body
Soft2DManager 是核心的场景管理器，它负责管理场景的参数配置、渲染和管理各个物体（Body, Collider, Trigger）。场景里必须放置一个 Soft2DManager 才能使用插件的相关功能。详细介绍见 [Soft2DManager](./Soft2DManager.md)。

Body 是一个可以被模拟的连续体，由一组粒子组成。是 Soft2D-for-Unity 最基础的模拟单位。详细介绍见 [Body](./Body.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/6922f3a3-71bb-4118-97e9-0baa2d80e945


## 创建 Custom Body
CustomBody 是用户指定采样点的 Body。详细介绍见 [Body](./Body.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/bcb8d860-8435-4a33-832a-618c5eb4dff6


## 创建 Mesh Body
MeshBody 是带有拓扑关系的 Body。每个传入网格的顶点位置会生成一个 Soft2D 粒子，它们之间遵循网格内三角形的拓扑关系。详细介绍见 [Body](./Body.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a9a608d9-a5b5-4927-96e4-c20d4e9b1d6c

## 创建 Emitter
Emitter 是一个能自由控制发射 Body 的发射器。详细介绍见 [Emitter](./Emitter.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/444ce93b-6727-4edb-80c2-81954cc613da

## 创建 Collider
Collider 是一个障碍物，会阻挡 body 的运动。详细介绍见 [Collider](./Collider.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/24fb1448-2bc7-49ed-915d-3ca825e6ef97

## 创建 Trigger

Trigger 是一个拥有特定形状的空间区域，可以检测到经过它的粒子。详细介绍见 [Trigger](./Trigger.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/5a1e835a-df52-4302-96a5-02fbfcff12fa

## 使用调试工具
使用调试工具，可以对场景中的 collider 或者 trigger 进行可视化。详细介绍见 [调试工具](./DebugTools.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/026ecf9b-a9bd-4b98-847d-d41d1d371671


## 自定义渲染效果

见 [自定义着色器](./CustomShader.md)。

## 示例场景
我们提供了数个示例场景用于展示 Soft2D-for-Unity 在游戏中的使用方法。这些示例场景可以在 `Soft2D/Samples/`中找到。目前示例场景只支持 3D URP 管线。
### SandBox
### WaterWheel
### Gear
### Maze

## 打包
目前默认打包的项目是 SandBox 中的所有场景。支持 Windows/Linux/MacOS/iOS/Android 平台。
