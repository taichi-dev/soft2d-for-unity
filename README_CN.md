
<h1 align="center">Soft2D for Unity</h1>

<div align="center">
  <a href="https://assetstore.unity.com/packages/slug/256549">
    <img src="http://img.shields.io/badge/-Unity%20Asset%20Store-feefff?style=for-the-badge&logo=unity&logoColor=000" height="25px" alt="unity logo" />
  </a>
  <a href="https://www.youtube.com/channel/UCUweEINecpOaM8HAKLvfBJA">
    <img src="https://img.shields.io/static/v1?message=Youtube&logo=youtube&label=&color=FF0000&logoColor=white&labelColor=&style=for-the-badge" height="25px" alt="youtube logo"  />
  </a>
  <a href=" https://twitter.com/soft2d_official">
    <img src="https://img.shields.io/static/v1?message=Twitter&logo=twitter&label=&color=1DA1F2&logoColor=white&labelColor=&style=for-the-badge" height="25px" alt="twitter logo"  />
  </a>
  <a href="https://discord.gg/JZwFWsuqKV">
    <img src="https://img.shields.io/static/v1?message=Discord&logo=discord&label=&color=5865F2&logoColor=white&labelColor=&style=for-the-badge" height="25px" alt="discord logo"  />
  </a>
  <a href="https://www.soft2d.tech/">
    <img src="https://img.shields.io/static/v1?message=Official%20Website&label=&color=FFC93C&style=for-the-badge" height="25px" alt="taichi logo" />
  </a>
</div>

<h4 align="center">
    <p>
        <a href="https://github.com/taichi-dev/soft2d-for-unity/#readme">English</a> |
        <b>简体中文</b> 
    </p>
</h4>

## Soft2D for Unity 是什么？

[Soft2D](https://www.soft2d.tech/) 是一个实时的 2D 多材料连续体物理引擎，可以模拟流体、弹性体、雪和沙子等材料。Soft2D for Unity 插件为 Soft2D 提供了高层封装，并为用户提供了一系列易用的的接口，可以让用户方便地在 Unity 中实现各种物理模拟与渲染效果。

<div align="center">
<img src="images/WaterWheel.gif" alt="WaterWheel" width="300px"> <img src="images/Maze.gif" alt="Maze" width="300px">
</div>
<div align="center">
<img src="images/android.gif" alt="FluidRendering" width="300px"> <img src="images/ipad.gif" alt="Maze" width="300px">
</div>


## 为什么使用 Soft2D for Unity？

- 功能强大且易用：
  - 支持多材料模拟：弹性体、流体、沙子、雪。
  - 高层次抽象：world, body, emitter, collider, trigger。
- 全平台部署：Linux, Windows, MacOS/iOS, Android
  ![Windows](http://img.shields.io/badge/-Windows-0078D6?style=flat-square&logo=windows&logoColor=fff)
  ![Linux](http://img.shields.io/badge/-Linux-FCC624?style=flat-square&logo=linux&logoColor=000)
  ![Android](http://img.shields.io/badge/-Android-3DDC84?style=flat-square&logo=android&logoColor=fff)
  ![macOS](http://img.shields.io/badge/-macOS-15171a?style=flat-square&logo=macos&logoColor=fff)
  ![iOS](http://img.shields.io/badge/-iOS-1f1f1f?style=flat-square&logo=ios&logoColor=fff)
- 基于 [Taichi 语言](https://github.com/taichi-dev/taichi)的**真实**物理模拟。
- 适用于**3D场景**，并同时针对2D与3D场景编写了相关材质着色器。
- 包含了**很多教程和展示场景**供用户了解插件的强劲功能。
- 与 Unity 内组件**深度绑定**，Soft2D 的粒子可以与 Unity 的碰撞体和触发器产生交互。

## 开始使用 Soft2D for Unity

### 环境要求

- 图形 API: Vulkan 或 Metal
- Unity 版本：2021.3.22f1 或更高
- 渲染管线：built-in 或 URP 管线
- 脚本后端：IL2CPP

### 安装

- [下载 Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity/releases/download/v0.1.0/Soft2D.v0.1.0.7z) 并在 Unity Assets 文件夹下的任何位置打开它 (除了 Editor, Plugins 或 Resources 文件夹下)；
- 点击弹出的启动窗口中的 **Run and Restart** 按钮，此时启动窗口会执行以下操作：
  - 将图形 API 修改为 Vulkan 或 Metal；
  - 将脚本后端修改为 IL2CPP；
  - 如果当前渲染管线不是 URP 管线，删除和 URP 有关的后处理文件；
  - 重启当前项目。


- 当你导入的项目的渲染管线是 URP 时：因为 02_2DGame 场景采用了 Renderer Feature 的方式实现后处理效果，你还需要以下步骤以正常运行场景：
  - 在 Project Settings -> Rendering -> Render Pipeline Asset 下找到当前项目使用的 **Render Pipeline Asset**；
  - 在 **Render Pipeline Asset** 下的 RendererList 下点击 “+” 新增一个 Renderer Data，选择 **Kawase Blur Data** 作为新增的 Renderer Data.

## 文档

- [概述](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/Simplified_Chinese/Overview.md)
- [教程](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/Simplified_Chinese/Tutorials/Tutorial.md)

## 联系我们

- 如果你在文档和使用过程中发现了困难或错误，欢迎在 [Github Issues](https://github.com/taichi-dev/soft2d-for-unity/issues) 提出 issue。
- 如果你愿意参与 Soft2D for Unity 的开发，欢迎给我们提出 Pull Request。

