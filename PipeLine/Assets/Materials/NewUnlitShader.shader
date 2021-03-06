Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
//        _Power ( "Color Power", float) = 0.5
//        _MainTex ("Texture", 2D) = "white" {}
//        _MyVector ( "My Vector", Vector) = ( 0.2, 0.3, 1)
//        _Range ( "Range", Range(0.2,4)) = 1
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        
        Pass
        {
            //Cull Front
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : NORMAL;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float NdotL = dot (_WorldSpaceLightPos0, normal);
                return _Color * NdotL;
            }
            ENDCG
        }        
    }
    
   // Fallback "Unlit/Color"
}
