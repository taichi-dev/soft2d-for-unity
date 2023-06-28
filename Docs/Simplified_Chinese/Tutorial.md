# Soft2D-for-Unity's Tutorial

> 这是 Soft2D-for-Unity 的教程，它可以帮助你快速上手 Soft2D 插件。

## 介绍

- Soft2D 是一个实时 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

## 环境要求

|       Unity 版本    |   图形 API    |       渲染管线            | 脚本后端 |
|--------------------|---------------|-------------------------|---------|
|2021.3.22f1 或更高   |Vulkan 或 Metal|2D built-in 或 3D URP     |IL2CPP   |



## 基础设置

### 使用 Github Unity 项目
下载使用即可。

### 安装插件
> 在本节教程中，我们会介绍如何导入 Soft2D 插件至 Unity 项目中，并完成 Soft2D 的基础设置。

Soft2D 插件支持两种方式导入 Unity 项目中，它们分别是 Unity Asset Store 和 Github 页面。

- Unity Asset Store
   - 在 [Unity Asset Store 页面](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)访问 Soft2D 插件；
   - 点击 **Add to My Assets** 将插件添加到你的Unity账号中；
   - 返回 Unity 编辑器，通过 Windows->Package Manager 打开 **Package Manager** 窗口;
   - 在 Package Manager 窗口选择 **My Assets** 选项卡，找到 Soft2D 插件，并点击 **Download** 按钮将其下载到本地。

当你导入完成后，插件会自动弹出一个启动窗口。启动窗口会执行以下操作：

- 将图形 API 修改为 Vulkan 或 Metal；
- 将脚本后端修改为 IL2CPP；
- 如果当前渲染管线不是 URP 管线，删除和 URP 有关的后处理文件。

- 当你导入的项目的渲染管线是 URP 时：因为 02_2DGame 场景采用了 Renderer Feature 的方式实现后处理效果，你还需要以下步骤以正常运行场景：
  - 在 Project Settings -> Rendering -> Render Pipeline Asset 下找到当前项目使用的 **Render Pipeline Asset**；
  - 在 **Render Pipeline Asset** 下的 RendererList 下点击 “+” 新增一个 Renderer Data，选择 **Kawase Blur Data** 作为新增的 Renderer Data.


## 核心概念

* Soft2DManager：Soft2D 的核心管理器。负责 Soft2D 物体创建和调整模拟环境参数。
* Body：一个可以进行模拟的物体。它可以由一组粒子组成，也可以是一个 2D 网格。
* Collider：场景中的障碍物。
* Trigger：可以检测、操作粒子的区域。
* Emitter：可以持续发射 Body 的物体。

## 使用 Soft2DManager 并创建一个 Body

- 创建一个新的场景。在 Hierarchy 窗口右键，通过 Soft2D->Soft2DManager 创建一个 **Soft2DManager** 物体。Soft2DManager 是用来控制并渲染
当前场景的 Soft2D 粒子的脚本。 它的具体介绍和参数内容可以[点击这里](./Soft2DManager.md)查看。
- 通过 Soft2D->Body->Body 创建一个 **Body** 物体。Body 是用由一组内部粒子组成的一个物体。它的具体介绍和参数内容可以[点击这里](./Body.md)查看。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/6922f3a3-71bb-4118-97e9-0baa2d80e945


## 创建 Custom Body

它的具体介绍和参数内容可以[点击这里](./Body.md)查看。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/bcb8d860-8435-4a33-832a-618c5eb4dff6


## 创建 Mesh Body

MeshBody 也属于 Soft2D 的 `S2Body` 类型。我们可以将一张带有网格的 2D 贴图输入至 MeshBody 内，而 MeshBody 会为网格上的每个顶点生成一个粒子，
而且粒子之间也有着网格那样的拓扑关系。它的具体介绍和参数内容可以[点击这里](./Body.md)查看。下面是 MeshBody 的创建和使用流程：

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/a9a608d9-a5b5-4927-96e4-c20d4e9b1d6c

## 创建 Emitter

Emitter 是一个能自由控制发射 Body 的发射器。它的具体介绍和参数内容可以[点击这里](./Emitter.md)查看。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/444ce93b-6727-4edb-80c2-81954cc613da

## 创建 Collider

Collider 是一个可以与 Soft2D 粒子产生碰撞的物体。因为在 Soft2D 内创建的 Collider 无法与 Unity 的物体发生交互，所以我们将 Soft2D 的 Collider 与 Unity 的 Collider2D 绑定在了一起。它的具体介绍和参数内容可以[点击这里](./Collider.md)查看。


> 你可以使用 [测试工具](./DebugTools.md) 来查看 Collider 在 Soft2D 内的位置和状态。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/24fb1448-2bc7-49ed-915d-3ca825e6ef97

## 创建 Trigger

Trigger 是一个可以与 Soft2D 粒子产生交互的触发器。它可以被进入 Trigger 作用范围的粒子触发，并对粒子做出相应修改。它的具体介绍和参数内容可以[点击这里](./Trigger.md)查看。

> 你可以使用 [Debug Tools 工具](./DebugTools.md) 来查看 Trigger 在 Soft2D 内的位置和状态。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/5a1e835a-df52-4302-96a5-02fbfcff12fa



## 使用调试工具
见 [测试工具](./DebugTools.md)。

https://github.com/taichi-dev/soft2d-for-unity/assets/8120108/026ecf9b-a9bd-4b98-847d-d41d1d371671


## 使用自定义 shader

见 [自定义 Soft2D 着色器](./CustomShader.md)。
