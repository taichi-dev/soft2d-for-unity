# 概述

## 介绍

- Soft2D 是一个实时 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

## 环境要求

|       Unity 版本    |   图形 API    |       渲染管线            | 脚本后端 |
|--------------------|---------------|-------------------------|---------|
|2021.3.22f1 或更高   |Vulkan 或 Metal|2D built-in 或 3D URP     |IL2CPP   |

## 教程

[详细教程](./Tutorial.md)

## 核心概念

* Soft2DManager：负责 Soft2D 物体创建和调整模拟环境参数。详细介绍见 [Soft2DManger](./Soft2DManager.md)。

* Body：一个可以进行模拟的物体。它可以由一组粒子组成，也可以是一个 2D 网格。详细介绍见 [Body](./Body.md)。

* Collider：场景中的障碍物。详细介绍见 [Collider](./Collider.md)。

* Trigger：可以检测、操作粒子的区域。详细介绍见 [Trigger](./Trigger.md)。

* Emitter：可以持续发射 Body 的物体。详细介绍见 [Emitter](./Emitter.md)。

## 高级用法

[自定义 Soft2D 着色器](./CustomShader.md)

[测试工具](./DebugTools.md)
