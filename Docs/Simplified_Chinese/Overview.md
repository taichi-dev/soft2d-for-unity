# Overview

# 介绍

Soft2D 是一个基于 Taichi AOT 系统的 2D 实时多材料物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟和渲染效果。

# 前置要求

图形 API: Vulkan 或 Metal

Unity 版本：2021.3.15 或更高

图形管线：built-in 或 URP 管线

# 教程

[详细教程](Tutorials/Tutorial.md)

# 核心概念

## Soft2DManager

Soft2DManager 负责 Soft2D 物体创建和调整模拟环境参数。

[详细介绍](BasicComponents/Soft2DManager.md)

## Body

Body 是一个可以进行模拟的物体。它可以由一组粒子组成，也可以是一个 2D 网格。

[详细介绍](BasicComponents/Body.md)

## Collider

Collider 是场景中的障碍物。

[详细介绍](BasicComponents/Collider.md)

## Trigger

Trigger 是可以检测、操作粒子的区域。

[详细介绍](BasicComponents/Trigger.md)

## Emitter

Emitter 是可以持续发射 Body 的物体。

[详细介绍](BasicComponents/Emitter.md)

# 高级用法

[自定义 Soft2D 着色器](Advance/CustomShader.md)

[自定义 Trigger 功能](Advance/CustomTrigger.md)

[测试工具](Advance/DebugTools.md)

# API References

[Soft2DManager]()

[Body]()

[Collider]()

[Trigger]()

[Emitter]()