# Soft2D-Tutorial

> 这是 Soft2D for Unity 的教程，它可以帮助你快速上手 Soft2D 插件。

## 基础设置

> 在本节教程中，我们会介绍如何导入 Soft2D 插件至 Unity 项目中，并完成 Soft2D 的基础设置。

Soft2D 插件支持两种方式导入 Unity 项目中，它们分别是 Unity Asset Store 和 Github 页面。

- Unity Asset Store
   - 在 Unity Asset Store 页面访问 Soft2D 插件： [Soft2D for Unity](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)；
   - 点击 **Add to My Assets** 将插件添加到你的Unity账号中；
   - 返回 Unity 编辑器，通过 Windows->Package Manager 打开 **Package Manager** 窗口;
   - 在 Package Manager 窗口选择 **My Assets** 选项卡，找到 Soft2D 插件，并点击 **Download** 按钮将其下载到本地。

- Github 
   - 在 Github 仓库页面访问 Soft2D 插件： [Soft2D for Unity](https://github.com/taichi-dev/soft2d-unity-urp)；
   - 在 **Releases** 页面获取适当版本的插件文件并下载下来；
   - 直接将下载下来的 **Soft2D.unitypackage** 文件拖拽到编辑器的 **Project** 视图中；
   - Unity 编辑器会弹出一个导入设置窗口，确认无误后点击 **Import** 按钮。

当你导入完成后，插件会自动弹出一个启动窗口。由于当前插件只支持 Vulkan 和 Metal 图形 API，请按照窗口流程设置当前项目使用的图形 API。 

视频链接：[BasicSetup]()

## 快速开始

> 在本节教程中，我们会介绍如何使用 Soft2D 插件创建一个简单的场景，实现 Soft2D 的模拟功能。

- 创建一个新的场景。在 Hierarchy 窗口右键，通过 Soft2D->Soft2DManager 创建一个 **Soft2DManager** 物体。Soft2DManager 是用来控制并渲染
当前场景的 Soft2D 粒子的脚本。 它的具体介绍和参数内容可以[点击这里](../BasicComponents/Soft2DManager.md)查看。
- 通过 Soft2D->Body->Body 创建一个 **Body** 物体。Body 是用由一组内部粒子组成的一个物体。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Body.md)查看。
- 最后，因为创建的 Body 物体并不在 Soft2D 的模拟范围内（初始设置是左下角在原点的 1x1 正方形），我们需要把物体移动到模拟范围内（比如(0.5,0.8)）。
- 为了在运行后有较好的视觉体验，你可以调整摄像头至相应的大小和位置。

完成上述操作后运行当前场景，你就能看到一个长方形的水的模拟效果了：

[img.png]()

视频链接：[QuickStart](../../GIFs/Body.mp4)

## CustomBody

> 在本节教程中，我们会介绍如何创建一个 CustomBody，以及它的特性和功能。

CustomBody 和上一章的 Body 都属于 Soft2D 的 `S2Body` 类型。但 Body 只能设置成 Box/Circle/Capsule 等固定的形状，而在 CustomBody 中，
用户可以自定义粒子的数量和每个粒子的位置。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Body.md)查看。下面是 CustomBody 的创建和使用流程：

- 创建一个新的场景并通过 Soft2D->Soft2DManager 创建一个 **Soft2DManager** 物体；
- 通过 Soft2D->Body->CustomBody 创建一个 **CustomBody** 物体；
- 在 CustomBody 物体的 Inspector 窗口内修改粒子的数量和位置：
  - 在 `E Custom Body` 脚本下找到 Particles Local Positions 选项，向里面输入三个粒子位置数据：(0,0),(0.05,0),(0.025,0.05);
- 把 CustomBody 物体移动到模拟范围内（比如(0.5,0.8)）。

完成上述操作后运行当前场景，你就能看到一个三角形的 CustomBody 的模拟效果了：

[img.png]()

视频链接：[CustomBody](../../GIFs/CustomBody.mp4)

## MeshBody

> 在本节教程中，我们会介绍如何创建一个 MeshBody，以及它的特性和功能。

MeshBody 也属于 Soft2D 的 `S2Body` 类型。我们可以将一张带有网格的 2D 贴图输入至 MeshBody 内，而 MeshBody 会为网格上的每个顶点生成一个粒子，
而且粒子之间也有着网格那样的拓扑关系。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Body.md)查看。下面是 MeshBody 的创建和使用流程：

- 创建一个新的场景并通过 Soft2D->Soft2DManager 创建一个 **Soft2DManager** 物体；
- 通过 Soft2D->Body->CustomBody 创建一个 **MeshBody** 物体；
- 然后，我们需要为一个 2D 贴图创建网格：
  - 在预设的 2D 贴图的 Inspector 窗口内点击 **Sprite Editor** 按钮进入贴图编辑器窗口；
  - 在左上角将 Sprite Editor 改为 Skinning Editor，在左边新生成的窗口中选择 **Auto Weights** 让 Unity 自动生成网格；
  - 点击左下角的 **Generate All** ，再点击上方的 **Apply** 保存设置；
  - 此时 2D 贴图的网格已经创建完毕，你可以直接关闭贴图编辑器窗口。
- 在 MeshBody 物体下找到 `E Mesh Body` 脚本，把 2D 贴图挂载至 **Mesh Sprite** 下，并通过 **Mesh Scale** 调整它的大小；
- 把 MeshBody 物体移动到模拟范围内（比如(0.5,0.8)）。

完成上述操作后运行当前场景，你就能看到一个有着卡通小车网格的 MeshBody 的模拟效果了：

[img.png]()

视频链接：[MeshBody](../../GIFs/MeshBody.mp4)

## Emitter

> 在本节教程中，我们会介绍 Emitter 的创建方法和功能。

Emitter 是一个能自由控制发射 Body 的发射器。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Emitter.md)查看。下面是 Emitter 的创建和使用流程：

- 创建一个新的场景并通过 Soft2D->Soft2DManager 创建一个 **Soft2DManager** 物体；
- 通过 Soft2D->Emitter 创建一个 **Emitter** 物体；
- 把 Emitter 物体移动到模拟范围内（比如(0.5,0.8)）；
- 将物体的 `E Emitter` 脚本下勾选 Emit On Awake，这样发射器就会在场景运行之初就开始发射预设 Body ；
- 此时我们可以通过修改参数给 **Emitter** 发射的物体换个造型：
  - 将物体的 `E Emitter` 脚本下把 Material Type 修改为 **Elastic**；
  - 将 Shape Type 修改为 **Box**，把 Half Width 和 Half Height 改成 0.05；
  - 把 Base Color 换个颜色（比如橙色）。

完成上述操作后运行当前场景，你就能看到一个不停发射橙色正方弹性体的 Emitter 的模拟效果了：

[img.png]()

视频链接：[Emitter](../../GIFs/Emitter.mp4)

## Collider

> 在本节教程中，我们会介绍 Collider 的创建方法和功能。

Collider 是一个可以与 Soft2D 粒子产生碰撞的物体。因为在 Soft2D 内创建的 Collider 无法与 Unity 的物体发生交互，所以我们将 Soft2D 的
Collider 与 Unity 的 Collider2D 绑定在了一起。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Collider.md)查看。
我们将使用上一章创建 Emitter 的场景来介绍 Collider 的创建和使用流程：

- 通过 Soft2D->Collider 创建一个 **Collider** 物体；
- 把 Collider 物体移动到模拟范围内（比如(0.5,0.8)）。

完成上述操作后运行当前场景，你就能看到 Body 与 Collider 碰撞的模拟效果了：

[img.png]()

> 你可以使用 [测试工具](../Advance/DebugTools.md) 来查看 Collider 在 Soft2D 内的位置和状态。

视频链接：[Collider](../../GIFs/Collider.mp4)

## Trigger

> 在本节教程中，我们会介绍 Trigger 的创建方法和功能。

Trigger 是一个可以与 Soft2D 粒子产生交互的触发器。它可以被进入 Trigger 作用范围的粒子触发，并对粒子做出相应修改。它的具体介绍和参数内容可以[点击这里](../BasicComponents/Trigger.md)查看。
我们将使用上一章创建 Collider 的场景来介绍 Collider 的创建和使用流程：

- 为了演示方便，我们先把 Collider 物体移除；
- 通过 Soft2D->Trigger 创建一个 **Trigger** 物体；
- 把 Collider 物体移动到模拟范围内（比如(0.5,0.8)）；
- 新建一个脚本，起名为 `TriggerExample.cs` ，将下面的代码复制进该脚本：
```csharp
using System;
using Taichi.Soft2D.Generated;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    public ETrigger trigger;

    [AOT.MonoPInvokeCallback(typeof(S2ParticleManipulationCallback))]
    public static void ManipulateTrigger1(IntPtr particles, uint size)
    {
        if(size > 0)
            Debug.Log("Trigger activated");
    }

    public void Update()
    {
        trigger.InvokeCallbackAsync(ManipulateTrigger1);
    }
}

```
- 在场景内新建一个空物体，将 `TriggerExample.cs` 挂载在该空物体上；
- 将 Trigger 物体挂载在 `TriggerExample.cs` 的 **Trigger** 变量上。

完成上述操作后运行当前场景，你就能看到 Body 内粒子触发 Trigger 的效果了：

[img.png]()

> 你可以使用 [Debug Tools 工具](../Advance/DebugTools.md) 来查看 Trigger 在 Soft2D 内的位置和状态。

> 自定义编写触发器修改粒子的教程可以在[这里](../Advance/CustomTrigger.md)看到。

视频链接：[Trigger](../../GIFs/Trigger.mp4)
