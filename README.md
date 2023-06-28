
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
    <img src="https://img.shields.io/static/v1?message=Official%20Website&label=&color=FFC93C&style=for-the-badge" height="25px" alt="logo" />
  </a>
</div>

<h4 align="center">
    <p>
        <b>English</b> |
        <a href="https://github.com/taichi-dev/soft2d-for-unity/blob/main/README_CN.md">简体中文</a> 
    </p>
</h4>

## What is Soft2D for Unity?
[Soft2D](https://www.soft2d.tech/) is a 2D multi-material continuum physics engine designed for real-time applications. Soft2D for Unity provides a high-level encapsulation for Soft2D and offers users a range of easy-to-use interfaces, enabling them to easily implement various physical simulations and rendering effects in Unity.

<div align="center">
<img src="images/WaterWheel.gif" alt="WaterWheel" width="300px"> <img src="images/Maze.gif" alt="Maze" width="300px">
</div>
<div align="center">
<img src="images/android.gif" alt="Android" width="300px"> <img src="images/ipad.gif" alt="ipad" width="300px">
</div>

## Why Soft2D for Unity?

- Powerful and Easy-to-Use:
  - Multi-material: Elastic bodies, fluid, sand, snow.
  - High-level abstraction: world, body, emitter, collider, trigger.
- Universal Deployment: Linux, Windows, MacOS/iOS, Android.
  ![Windows](http://img.shields.io/badge/-Windows-0078D6?style=flat-square&logo=windows&logoColor=fff)
  ![Linux](http://img.shields.io/badge/-Linux-FCC624?style=flat-square&logo=linux&logoColor=000)
  ![Android](http://img.shields.io/badge/-Android-3DDC84?style=flat-square&logo=android&logoColor=fff)
  ![macOS](http://img.shields.io/badge/-macOS-15171a?style=flat-square&logo=macos&logoColor=fff)
  ![iOS](http://img.shields.io/badge/-iOS-1f1f1f?style=flat-square&logo=ios&logoColor=fff)
- Suitable for 3D scenes, relevant material shaders have been written for both 2D and 3D scenes.
- Includes **many tutorials and showcase scenes** for users to understand the powerful features of the plugin.
- **Deeply bound** with Unity's internal components, Soft2D's particles can interact with Unity's components.

## Getting Started

### Environment Requirements

- Graphics API: Vulkan or Metal
- Unity version: 2021.3.22f1 or higher
- Render Pipeline: built-in or URP 
- Scripting Backend: IL2CPP

### Installation

- [Download Soft2D for Unity](https://github.com/taichi-dev/soft2d-for-unity/releases/download/v0.1.0/Soft2D.v0.1.0.7z) and unzip it anywhere in your Unity Assets folder (just not inside the Editor, Plugins or Resources directories);
- Click **Run and Restart** button, meanwhile the program will perform the following procedures:
  - Change graphics API to Vulkan or Metal;
  - Change scripting backend to IL2CPP;
  - If the current pipeline is not Universal Render Pipeline, delete files related to it (URP);
  - Restart this project.


- When the rendering pipeline of the imported project is URP: Since the 02_2DGame scene uses Renderer Feature to achieve post-processing effects, you also need the following steps to run the scene normally:
  - Find the **Render Pipeline Asset** currently used by the project under Project Settings -> Rendering -> Render Pipeline Asset.
  - Find RendererList under **Render Pipeline Asset's** Inspector window, click “+” to add a Renderer Data，select **Kawase Blur Data** as new Renderer Data.

## Documentation

- [Overview](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/English/Overview.md)
- [Tutorial](https://github.com/taichi-dev/soft2d-for-unity/blob/main/Docs/English/Tutorials/Tutorial.md)

## Contact Us

- If you spot an technical or documentation issue, please file an issue at [Github Issues](https://github.com/taichi-dev/soft2d-for-unity/issues).
- If you want to contribute to Soft2D for Unity, please file a Pull Request.
