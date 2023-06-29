# Custom Shaders
In addition to using the shaders provided by the plugin, users can create their own shader and use it in the scene. We will introduce custom shader from three perspectives: parameter settings, vertex shader and script settings.

## Parameter Setting
Since Soft2D only supports Vulkan and Metal, we can optimize the performance by compiling shader code tailored to them:
``` shaderlab
#pragma exclude_renderers d3d11
```
At the same time, we need to enable GPU instancing and set the target version to 4.5 or higher:
```shaderlab
#pragma multi_compile_instancing
#pragma UNITY_INSTANCING_ENABLE
#pragma target 4.5
```
Soft2DManager will automatically retrieve the buffer of particle properties and pass them to the shader. We only need to declare them, and **should not change their names or variable types**:
```shaderlab
#if SHADER_TARGET >= 45
StructuredBuffer<float2> positionBuffer;
StructuredBuffer<int> tagBuffer;
StructuredBuffer<float2> velocityBuffer;
StructuredBuffer<int> IDBuffer;
#endif
```

- The variables are as follows:
  - positionBuffer: a buffer that stores the positions of the particles.
  - tagBuffer: a buffer that stores the tags of the particles, including logical tags and RGB values.
  - velocityBuffer: a buffer that stores the velocities of the particles.
  - IDBuffer: a buffer that stores the IDs of the particles within Soft2D. As particles are added or destroyed, their IDs remain unchanged.

Finally, we need to add `UNITY_VERTEX_INPUT_INSTANCE_ID` to the struct of the input vertex shader.

## Vertex Shader

First, we need to obtain the instance_id of the current particle, since the buffers provided by Soft2D are indexed based on instance_id:
```shaderlab
UNITY_SETUP_INSTANCE_ID(IN);
UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
int instance_id = UNITY_GET_INSTANCE_ID(IN);
```

Since Soft2D provides the position of the particle, we need to manually apply a model transformation to the particle:
```shaderlab
int instance_id = UNITY_GET_INSTANCE_ID(IN);
float2 center = positionBuffer[instance_id]; 
float4 data = float4(center, -0.2f, 1.0f);
float3 localPosition = IN.positionOS.xyz * _InstanceSize * data.w;
float3 worldPosition = data.xyz + localPosition;
```
Next, apply the VP transformation and obtained the correct position of the particle in homogeneous coordinates.
```shaderlab
OUT.positionCS=mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
```

In addition to the position of the particle, we can also obtain its current velocity and tag:
```shaderlab
OUT.velocity = velocityBuffer[instance_id];
uint buffer = tagBuffer[instance_id];
```

The higher 8 bits of the tagBuffer represent the logical label of the particle, while the lower 24 bits represent the RGB value of the particle. We need to separate them:
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
The obtained RGB values range from 0 to 255, and we need to convert them to floating-point numbers ranging from 0.0 to 1.0.

> Now, we have obtained all the parameters required to write a regular material shader.

## Script Setting

Change the particle rendering mode to `Custom` in the inspector window of Soft2DManager, and drag the custom material into the Instance Material slot.

![](../images/custom_rendering.png)

You can also set the rendering layer and the mesh for the particle here. For more details, please refer to [Soft2DManager](./Soft2DManager.md).
