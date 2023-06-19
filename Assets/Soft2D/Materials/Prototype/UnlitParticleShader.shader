Shader "Unlit/UnlitParticleShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _InstanceSize("Instance Size", Float) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma exclude_renderers d3d11

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma target 4.5
            #define UNITY_INSTANCING_ENABLED

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            uniform float _InstanceSize;

        #if SHADER_TARGET >= 45
            StructuredBuffer<float2> positionBuffer;
            StructuredBuffer<int> tagBuffer;
            StructuredBuffer<float2> velocityBuffer;
            StructuredBuffer<int> IDBuffer;
        #endif

            struct appdata
            {
                float4 vertex : POSITION;
                float3 texcoord : TEXCOORD;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 color:TEXCOORD1;
                float2 uv_MainTex : TEXCOORD0;
                // float2 vel : TEXCOORD4;
                // SHADOW_COORDS(4)
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            

            v2f vert (appdata v)
            {
                v2f o;
                #if SHADER_TARGET >= 45
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);

                int instance_id = UNITY_GET_INSTANCE_ID(v);
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
                
                float4 data = float4(center, -rand/6, 1.0f);

            #else
                float4 data = 0;
            #endif

                float3 localPosition = v.vertex.xyz * _InstanceSize * data.w;
                float3 worldPosition = data.xyz + localPosition;
                

                o.pos = mul(UNITY_MATRIX_VP, float4(worldPosition, 1.0f));
                o.uv_MainTex = v.texcoord;
                o.color = baseColor;
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 output = float4(i.color, 1.0f);
                return output;
            }
            ENDCG
        }
    }
}
