Shader "Unlit/3DParticleShader"
{
    Properties
    {
        [Header(Instance Settings)]
        _InstanceSize("Instance Size",Float)=0.02
        
        [Header(Render Settings)]
        _SpecularColor("Specular Color",Color)=(1,1,1,1)  
        _Smoothness("Smoothness",Float)=10
    }
    SubShader
    {
        Tags { 
            "RenderType"="Opaque" 
            "RenderPipeline"="UniversalPipeline"
            }
        

        Pass
        {
            Tags{"LightMode"="UniversalForward"}
            
            HLSLPROGRAM
            
            #pragma exclude_renderers d3d11

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma target 4.5
            #define UNITY_INSTANCING_ENABLED

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        
            CBUFFER_START(UnityPerMaterial)
            float4 _SpecularColor;
            float _InstanceSize;
            float _Smoothness;
            CBUFFER_END
            
            #if SHADER_TARGET >= 45
            StructuredBuffer<float2> positionBuffer;
            StructuredBuffer<int> tagBuffer;
            StructuredBuffer<float2> velocityBuffer;
            StructuredBuffer<int> IDBuffer;
            #endif

            struct Attributes
            {
                float4 positionOS:POSITION;
                float4 normalOS:NORMAL;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS:SV_POSITION;
                float3 color:TEXCOORD0;
                float3 positionWS:TEXCOORD1;
                float3 normalWS:TEXCOORD2;
                float3 viewDirWS:TEXCOORD3;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            Varyings vert(Attributes IN)
            {
                Varyings OUT;

                #if SHADER_TARGET >= 45
                    UNITY_SETUP_INSTANCE_ID(IN);
                    UNITY_TRANSFER_INSTANCE_ID(IN, OUT);

                    int instance_id = UNITY_GET_INSTANCE_ID(IN);
                    float2 center = positionBuffer[instance_id]; 
                    // o.vel = velocityBuffer[instance_id];
                    uint buffer = tagBuffer[instance_id];
                    uint tag=(buffer >> 24)&0x7;
                    float3 baseColor;
                    uint rbits=(buffer >> 16)&0xFF;
                    baseColor.r=rbits/255.0;
                    uint gbits=(buffer >> 8)&0xFF;
                    baseColor.g=gbits/255.0;
                    uint bbits=buffer & 0xFF;
                    baseColor.b=bbits/255.0;

                float seed = IDBuffer[instance_id];
                float rand = frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453)%3;
                float4 data = float4(center, -rand/10-0.2f, 1.0f);
                
                #else
                    float4 data = 0;
                #endif

                float3 localPosition = IN.positionOS.xyz * _InstanceSize * data.w;
                float3 worldPosition = data.xyz + localPosition;
                OUT.positionCS=mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
                OUT.positionWS=worldPosition;
                OUT.normalWS=IN.normalOS;
                OUT.viewDirWS=GetCameraPositionWS()-worldPosition;
                OUT.color=baseColor;
                return OUT;
            }

            float4 frag(Varyings IN):SV_Target
            {
                Light light=GetMainLight();
                half3 diffuse=LightingLambert(light.color,light.direction,IN.normalWS);
                half3 specular=LightingSpecular(light.color,light.direction,normalize(IN.normalWS),normalize(IN.viewDirWS),_SpecularColor,_Smoothness);

                uint pixelLightCount=GetAdditionalLightsCount();
                for (uint index=0;index<pixelLightCount;index++)
                {
                    Light light=GetAdditionalLight(index,IN.positionWS);
                    diffuse+=LightingLambert(light.color,light.direction,IN.normalWS);
                    specular+=LightingSpecular(light.color,light.direction,normalize(IN.normalWS),normalize(IN.viewDirWS),_SpecularColor,_Smoothness);
                }
                
                half3 color=IN.color.xyz * specular * light.shadowAttenuation*light.distanceAttenuation;
                return float4(color,1);
            }
            
            ENDHLSL
        }
        
        Pass
        {
            Tags {
				"LightMode" = "ShadowCaster"
			}

            ZWrite On
            ZTest LEqual
            Cull[_Cull]
            
            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11

            #pragma vertex vertex
            #pragma fragment fragment
            #pragma shader_feature _ALPHATEST_ON
            #pragma multi_compile_instancing
            #pragma multi_compile _ DOTS_INSTANCING_ON
            #pragma multi_compile_shadowcaster
            #pragma target 4.5
            #define UNITY_INSTANCING_ENABLED
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            CBUFFER_START(UnityPerMaterial)
            float _InstanceSize;
            CBUFFER_END
            
            #if SHADER_TARGET >= 45
            StructuredBuffer<float2> positionBuffer;
            StructuredBuffer<int> tagBuffer;
            StructuredBuffer<float2> velocityBuffer;
            #endif

            struct Attributes
            {
                float4 positionOS:POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS:SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            Varyings vertex(Attributes IN)
            {
                Varyings OUT;

                #if SHADER_TARGET >= 45
                    UNITY_SETUP_INSTANCE_ID(IN);

                    int instance_id = UNITY_GET_INSTANCE_ID(IN);
                    float2 center = positionBuffer[instance_id];
                    // o.vel = velocityBuffer[instance_id];
                    int tag = tagBuffer[instance_id];

                float seed = UNITY_GET_INSTANCE_ID(IN);
                float rand = frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453)%3;
                
                    float4 data = float4(center, -rand/6, 1.0f);
                
                #else
                    float4 data = 0;
                #endif

                float3 localPosition = IN.positionOS.xyz * _InstanceSize * data.w;
                float3 worldPosition = data.xyz + localPosition;
                OUT.positionCS=mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
                return OUT;
            }

            half4 fragment(Varyings input) : SV_TARGET
            {
                float4 color;
                color.xyz=float3(0.0,0.0,0.0);
                return color;
            }
            ENDHLSL
        }
    }
    Fallback Off
}
