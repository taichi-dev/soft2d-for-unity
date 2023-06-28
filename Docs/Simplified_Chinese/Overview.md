# 概述

## 介绍

- Soft2D 是一个实时 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

## 环境要求

|       Unity 版本    |   图形 API    |       渲染管线            | 脚本后端 |
|--------------------|---------------|-------------------------|---------|
|2021.3.22f1 或更高   |Vulkan 或 Metal|3D built-in 或 3D URP 管线|IL2CPP   |

## 安装

- [下载 Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity/releases/download/v0.1.0/Soft2D.v0.1.0.7z) 并在 Unity Assets 文件夹下的任何位置打开它 (除了 Editor, Plugins 或 Resources 文件夹下)；
- 点击弹出的启动窗口中的 **Run and Restart** 按钮，此时启动窗口会执行以下操作：
  - 将图形 API 修改为 Vulkan 或 Metal；
  - 将脚本后端修改为 IL2CPP；
  - 如果当前渲染管线不是 URP 管线，删除和 URP 有关的后处理文件；
  - 重启当前项目。


- 当你导入的项目的渲染管线是 URP 时：因为 02_2DGame 场景采用了 Renderer Feature 的方式实现后处理效果，你还需要以下步骤以正常运行场景：
  - 在 Project Settings -> Rendering -> Render Pipeline Asset 下找到当前项目使用的 **Render Pipeline Asset**；
  - 在 **Render Pipeline Asset** 下的 RendererList 下点击 “+” 新增一个 Renderer Data，选择 **Kawase Blur Data** 作为新增的 Renderer Data.


## 教程

[详细教程](./Tutorial.md)

## 核心概念

### Soft2DManager

Soft2DManager 负责 Soft2D 物体创建和调整模拟环境参数。

[详细介绍](./Soft2DManager.md)

### Body

Body 是一个可以进行模拟的物体。它可以由一组粒子组成，也可以是一个 2D 网格。

[详细介绍](./Body.md)

### Collider

Collider 是场景中的障碍物。

[详细介绍](./Collider.md)

### Trigger

Trigger 是可以检测、操作粒子的区域。

[详细介绍](./Trigger.md)

### Emitter

Emitter 是可以持续发射 Body 的物体。

[详细介绍](./Emitter.md)

## 高级用法

[自定义 Soft2D 着色器](./CustomShader.md)

[自定义 Trigger 功能](./CustomTrigger.md)

[测试工具](./DebugTools.md)
