# 自定义着色器
用户除了使用插件自带的 shader 外，还可以自己编写 shader 代码并在场景内使用。我们将从参数设置、顶点着色器、脚本设置三部分展开介绍。

## 参数设置
由于 Soft2D 目前仅支持 Vulkan 与 Metal 图形 API，我们在编译着色器代码时也可以只为它们编译以节省性能：
``` shaderlab
#pragma exclude_renderers d3d11
```
同时，我们需要开启 GPU Instancing 功能并将目标设置为 4.5 及以上：
```shaderlab
#pragma multi_compile_instancing
#pragma UNITY_INSTANCING_ENABLE
#pragma target 4.5
```
Soft2DManager 会自动获取粒子属性的缓冲并传给 shader，我们只需声明它们即可，**这里不能修改它们的名字和变量类型**：
```shaderlab
#if SHADER_TARGET >= 45
StructuredBuffer<float2> positionBuffer;
StructuredBuffer<int> tagBuffer;
StructuredBuffer<float2> velocityBuffer;
StructuredBuffer<int> IDBuffer;
#endif
```

- 这些变量分别为：
  - positionBuffer：记录粒子位置的缓冲。
  - tagBuffer：记录粒子标签的缓冲，内部包括粒子的逻辑标签和颜色RGB值。
  - velocityBuffer：记录粒子线速度的缓冲。
  - IDBuffer：记录粒子在 Soft2D 内 ID 的缓冲。粒子的 ID 不会随着粒子的增减发生变化。

最后，我们需要在输入顶点着色器的结构体内加上`UNITY_VERTEX_INPUT_INSTANCE_ID`。

## 顶点着色器
首先我们需要获取当前粒子的 instance_id ，因为 Soft2D 提供的缓冲都以 instance_id 作为索引。
```shaderlab
UNITY_SETUP_INSTANCE_ID(IN);
UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
int instance_id = UNITY_GET_INSTANCE_ID(IN);
```

因为当前粒子所在位置是由 Soft2D 提供的，所以我们需要手动为粒子做模型变换操作：
```shaderlab
int instance_id = UNITY_GET_INSTANCE_ID(IN);
float2 center = positionBuffer[instance_id]; 
float4 data = float4(center, -0.2f, 1.0f);
float3 localPosition = IN.positionOS.xyz * _InstanceSize * data.w;
float3 worldPosition = data.xyz + localPosition;
```
再将获得的数据进行 VP 变换，获得正确的齐次坐标系下粒子的位置：
```shaderlab
OUT.positionCS=mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
```

除了粒子的位置外，我们还可以获取粒子当前的速度和它的标签：
```shaderlab
OUT.velocity = velocityBuffer[instance_id];
uint buffer = tagBuffer[instance_id];
```

其中 tagBuffer 的高 8 位为粒子的逻辑标签，低 24 位是粒子的颜色RGB值，我们还需要把它们分离：
```shaderlab
uint tag=(buffer >> 24)&0x7;
float3 baseColor;
uint rbits=(buffer >> 16)&0xFF;
baseColor.r=rbits/255.0;
uint gbits=(buffer >> 8)&0xFF;
baseColor.g=gbits/255.0;
uint bbits=buffer & 0xFF;
baseColor.b=bbits/255.0;
```
获取的RGB值是 0-255 的，我们需要把它转换成 0-1 的 float 格式。

> 至此，我们已经获得了编写一个普通材质 shader 所需的参数了。

## 脚本设置
在 Soft2DManager 的 Inspector 窗口内将粒子渲染模式改成 Custom，并将自定义编写的材质拖进 Instance Material 内。

![](../images/custom_rendering.png)

你也可以在这里设置粒子渲染所在的层级和网格。详细内容见 [Soft2DManager](Soft2DManager.md)。
