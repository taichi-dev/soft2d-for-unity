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
        <a href="https://github.com/taichi-dev/soft2d-for-unity/#readme">English</a> |
        <b>简体中文</b> 
    </p>
</h4>

## Soft2D for Unity 是什么？
Soft2D 是一个基于 Taichi AOT 系统的 2D 实时多材料物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟与渲染效果。

<div align="center">
<img src="Presentation/FluidRendering.gif" alt="FluidRendering"> <img src="Presentation/Maze.gif" alt="Maze">
</div>

## 为什么使用 Soft2D for Unity？

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

## 开始使用 Soft2D for Unity

### 环境要求

- 图形 API: Vulkan 或 Metal
- Unity 版本：2021.3.15 或更高
- 渲染管线：built-in 或 URP 管线

### 安装

[下载 Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity/releases/download/v0.1.0/Soft2D.v0.1.0.7z) 并在 Unity Assets 文件夹下的任何位置打开它 (除了 Editor, Plugins 或 Resources 文件夹下)。

## 内容结构

Soft2D for Unity 插件内的结构如下：

```
.
├── Core          // Soft2D 和 Taichi 的库文件与包装脚本
├── Materials     // Soft2D 粒子的着色器和材质
├── Prefabs       // Soft2D for Unity 插件的预制体
├── Samples       // Soft2D for Unity 插件的教程与效果演示场景
└── Scripts       // Soft2D for Unity 插件的脚本
```

## 文档

- [概述](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/Simplified_Chinese/Overview.md)
- [教程](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/Simplified_Chinese/Tutorials/Tutorial.md)

## 许可证

Soft2D 是根据 Apache 许可证（版本2.0）分发的。

查看 [Apache License](https://github.com/taichi-dev/soft2d-for-unity/blob/main/LICENSE) 以获取细节。

## 联系我们

- 如果你在文档和使用过程中发现了困难或错误，欢迎在 [Github Issues](https://github.com/taichi-dev/soft2d-for-unity/issues) 提出 issue。
- 如果你愿意参与 Soft2D for Unity 的开发，欢迎给我们提出 Pull Request。

