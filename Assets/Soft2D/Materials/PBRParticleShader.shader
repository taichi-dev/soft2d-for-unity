Shader "Soft2D/PBRParticleShader"
{
    Properties
    {
        _Smoothness("Smoothness", Range(0,1)) = 0
        _Metallic("Metallic", Range(0,1)) = 0
        _Emission("Emission", Color) = (0,0,0,0)
        _Occlusion("Occlusion Size", Range(0,1)) = 0
        _InstanceSize("Instance Size", Float) = 0.03
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma exclude_renderers d3d11

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma target 4.5
            #define UNITY_INSTANCING_ENABLED
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 normalOS : NORMAL;
                float4 texcoord1 : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 positionWS : TEXCOORD0;
                float3 normalWS : TEXCOORD1;
                float3 viewDir : TEXCOORD2;
                float3 color : COLOR;
                DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 4);
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            float _Smoothness;
            float _Metallic;
            float4 _Emission;
            float _InstanceSize;
            float _Occlusion;

            #if SHADER_TARGET >= 45
            StructuredBuffer<float2> positionBuffer;
            StructuredBuffer<int> tagBuffer;
            StructuredBuffer<float2> velocityBuffer;
            StructuredBuffer<int> IDBuffer;
            #endif

            void InitializeInputData(Varyings input, out InputData inputData)
            {
	            inputData = (InputData)0; 
	            inputData.positionWS = input.positionWS;

	            #ifdef _NORMALMAP
		            half3 viewDirWS = half3(input.normalWS.w, input.tangentWS.w, input.bitangentWS.w); // viewDir has been stored in w components of these in vertex shader
		            inputData.normalWS = TransformTangentToWorld(normalTS, half3x3(input.tangentWS.xyz, input.bitangentWS.xyz, input.normalWS.xyz));
	            #else
		            half3 viewDirWS = GetWorldSpaceNormalizeViewDir(inputData.positionWS);
		            inputData.normalWS = input.normalWS;
	            #endif

	            inputData.normalWS = NormalizeNormalPerPixel(inputData.normalWS);

	            viewDirWS = SafeNormalize(viewDirWS);
	            inputData.viewDirectionWS = viewDirWS;

	            #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
		            inputData.shadowCoord = input.shadowCoord;
	            #elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
		            inputData.shadowCoord = TransformWorldToShadowCoord(inputData.positionWS);
	            #else
		            inputData.shadowCoord = float4(0, 0, 0, 0);
	            #endif

	            inputData.bakedGI = SAMPLE_GI(input.lightmapUV, input.vertexSH, inputData.normalWS);
	            inputData.normalizedScreenSpaceUV = GetNormalizedScreenSpaceUV(input.positionCS);
	            inputData.shadowMask = SAMPLE_SHADOWMASK(input.lightmapUV);
            }

            Varyings vert (Attributes IN)
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
                float rand = frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453);
                float4 data = float4(center, -rand/20, 1.0f);
                
                #else
                    float4 data = 0;
                #endif

                float3 localPosition = IN.positionOS.xyz * _InstanceSize * data.w;
                float3 worldPosition = data.xyz + localPosition;
                OUT.positionCS=mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
                
                OUT.positionWS = worldPosition;
                OUT.normalWS = IN.normalOS;
                OUT.viewDir = normalize(GetCameraPositionWS() - worldPosition);
                OUT.color=baseColor;

                OUTPUT_LIGHTMAP_UV( v.texcoord1, unity_LightmapST, o.lightmapUV );
                OUTPUT_SH(OUT.normalWS.xyz, OUT.vertexSH );

                return OUT;
            }

            half4 frag (Varyings IN) : SV_Target
            {
                InputData inputdata = (InputData)0;
                InitializeInputData(IN, inputdata);
                
                SurfaceData surfacedata = (SurfaceData)0;
                surfacedata.metallic = _Metallic;
                surfacedata.smoothness = _Smoothness;
                surfacedata.emission = _Emission;
                surfacedata.occlusion = _Occlusion;
                surfacedata.alpha = 1;
                surfacedata.clearCoatMask = 0;
                surfacedata.clearCoatSmoothness = 0;
                surfacedata.albedo=IN.color;

                return UniversalFragmentPBR(inputdata, surfacedata);
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
}