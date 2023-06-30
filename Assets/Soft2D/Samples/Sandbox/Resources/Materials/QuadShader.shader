Shader "Example/URPUnlitShaderTexture"
{
    Properties
    {
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
        _StrokeColor("Stroke Color", Color) = (1,1,1,1)
        _Stroke("Stroke", Range(0,1)) = 0.1
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags { 
            "RenderType" = "Transparent" 
            "RenderPipeline" = "UniversalPipeline" 
            "IgnoreProjector" = "True"
            "Queue" = "AlphaTest"
            }
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };
            
            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            CBUFFER_START(UnityPerMaterial)
                float4 _StrokeColor;
                float4 _BaseMap_ST;
                float _Stroke;
                float _Cutoff;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv);
                clip(color.a - _Cutoff);
                if(color.a < _Stroke)
                    color = _StrokeColor;
                else
                {
                    color = color.r > 0 ? (color.b > 0 ? float4(1,1,1,1) : float4(80.0/255.0,1,0,1)) : float4(0,129.0/255.0,201.0/255.0,1);
                }
                return color;
            }
            ENDHLSL
        }
    }
}