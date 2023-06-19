Shader "Custom/RenderFeature/KawaseBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { 
            "RenderType" = "Transparent" 
            "RenderPipeline" = "UniversalPipeline" 
            "IgnoreProjector" = "True"
        }
        LOD 100

        Pass
        {
            ZTest Always Cull Off ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f
            {
                half2 uv : TEXCOORD0; 
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 _MainTex_ST;
            
            float _offset;

            v2f vert (appdata_full v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                return o;
            }

            fixed4 frag (v2f input) : SV_Target
            {
                float2 res = _MainTex_TexelSize.xy;
                float i = _offset;
    
                fixed4 col;                
                col = tex2D( _MainTex, input.uv );
                col += tex2D( _MainTex, input.uv + float2( i, i ) * res );
                col += tex2D( _MainTex, input.uv + float2( i, -i ) * res );
                col += tex2D( _MainTex, input.uv + float2( -i, i ) * res );
                col += tex2D( _MainTex, input.uv + float2( -i, -i ) * res );
                col /= 5.0f;
                
                return col;
            }
            ENDCG
        }
    }
}

