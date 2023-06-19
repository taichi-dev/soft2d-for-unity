<div align="center">
  <!-- <img height="150" src="https://github.com/taichi-dev/soft2d/blob/main/docs/images/logo_large.png"  /> -->
</div>

<h1 align="center">Soft2D for Unity</h1>

<div align="center">
  <a href="https://assetstore.unity.com/">
    <img src="http://img.shields.io/badge/-Unity%20Asset%20Store-feefff?style=for-the-badge&logo=unity&logoColor=000" height="25px" alt="unity logo" />
  </a>
  <a href="https://www.taichi-lang.org/">
    <img src="http://img.shields.io/badge/-Official%20Website-feefff?style=for-the-badge&logo=taichigraphics&logoColor=000" height="25px" alt="taichi logo" />
  </a>
  <img src="https://img.shields.io/static/v1?message=Youtube&logo=youtube&label=&color=FF0000&logoColor=white&labelColor=&style=for-the-badge" height="25" alt="youtube logo"  />
  <img src="https://img.shields.io/static/v1?message=Twitter&logo=twitter&label=&color=1DA1F2&logoColor=white&labelColor=&style=for-the-badge" height="25" alt="twitter logo"  />
</div>

<h4 align="center">
    <p>
        <b>English</b> |
        <a href="https://github.com/taichi-dev/soft2d-unity-urp/blob/main/README_CN.md">简体中文</a> 
    <p>
</h4>

## What is Soft2D for Unity？
Soft2D 是一个基于 Taichi AOT 系统的 2D 实时多材料物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟与渲染效果。

<div align="center">
<img src="Presentation/FluidRendering.gif" alt="FluidRendering"> <img src="Presentation/Maze.gif" alt="Maze">
</div>

## Why Soft2D for Unity？

- 支持**五大主流平台**的运行，全设备覆盖无死角:

  ![Windows](http://img.shields.io/badge/-Windows-0078D6?style=flat-square&logo=windows&logoColor=fff)
  ![Linux](http://img.shields.io/badge/-Linux-FCC624?style=flat-square&logo=linux&logoColor=000)
  ![Android](http://img.shields.io/badge/-Android-3DDC84?style=flat-square&logo=android&logoColor=fff)
  ![macOS](http://img.shields.io/badge/-macOS-15171a?style=flat-square&logo=macos&logoColor=fff)
  ![iOS](http://img.shields.io/badge/-iOS-1f1f1f?style=flat-square&logo=ios&logoColor=fff)

- 支持多种材料多种形状的物理模拟：
  - 流体
  - 沙子
  - 雪
  - 弹性体
- 基于 [Taichi 语言](https://github.com/taichi-dev/taichi)的**真实**物理模拟。
- 适用于**3D场景**，并同时针对2D与3D场景编写了相关材质着色器。
- 包含了**很多教程和展示场景**供用户了解插件的强劲功能。
- 与 Unity 内组件**深度绑定**，Soft2D 的粒子可以与 Unity 的碰撞体和触发器产生交互。

## Getting Started

### Environment Requirements

- Graphics API: Vulkan or Metal
- Unity version：2021.3.22f1 or higher
- Render Pipeline：built-in or URP 

### Installation

[Download Soft2D for Unity](https://github.com/taichi-dev/soft2d-unity-urp/releases/download/v0.1.0/Soft2D.v0.1.0.7z) and unzip it anywhere in your Unity Assets folder (just not inside the Editor, Plugins or Resources directories).

## Documentation

- [Overview](https://github.com/taichi-dev/soft2d-unity-urp/blob/main/Docs/Simplified_Chinese/Overview.md)
- [Tutorial](https://github.com/taichi-dev/soft2d-unity-urp/blob/main/Docs/Simplified_Chinese/Tutorials/Tutorial.md)


## Contact Us

- If you spot an technical or documentation issue, please file an issue at  [Github Issues](https://github.com/taichi-dev/soft2d-unity-urp/issues).
- If you are willing to participate in Soft2D for Unity，please file a Pull Request.
