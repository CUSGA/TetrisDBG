Shader "Unlit/Bricks"
{
    Properties
    {
        _Brick1 ("Brick1", 2D) = "white" {}
        _Brick2 ("Brick2", 2D) = "white" {}

        _Normal1 ("Normal1", 2D) = "white" {}
        _Normal2 ("Normal2", 2D) = "white" {}

        [HDR]_Specular ("Specular", Color) = (1,1,1,1)
        [HDR]_Diffuse ("Diffuse", Color) = (1,1,1,1)
        _Gloss ("Gloss", Range(1,255)) = 1
        _BumpScale ("BumpScale", Float) = 1

        [IntRange]_Row ("Row", Range(10,20)) = 10
        [IntRange]_Column ("Column", Range(6,10)) = 6

    }
    SubShader
    {

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float3 lDirTS : TEXCOORD1;
                float3 vDirTS : TEXCOORD2;
                float4 vertex : SV_POSITION;
            };

            sampler2D _Brick1;
            float4 _Brick1_ST;
            sampler2D _Brick2;
            float4 _Brick2_ST;
            sampler2D _Normal1;
            float4 _Normal1_ST;
            sampler2D _Normal2;
            float4 _Normal2_ST;

            float4 _Specular;
            float4 _Diffuse;
            float _Gloss;
            float _BumpScale;
            float _Row;
            float _Column;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = TRANSFORM_TEX(v.uv, _Brick1);
                o.uv.zw = TRANSFORM_TEX(v.uv, _Normal1);

                float3 binormal = cross(v.normal, v.tangent.xyz) * v.tangent.w;
                float3x3 rotation = float3x3(normalize(v.tangent.xyz), normalize(binormal), normalize(v.normal));
                o.lDirTS = mul(rotation, normalize(float3(1,1,5) - v.vertex)).xyz;
                o.vDirTS = mul(rotation, ObjSpaceViewDir(v.vertex)).xyz;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 brick1 = tex2D(_Brick1, float2(i.uv.x * _Column, i.uv.y * _Row));
                fixed4 brick2 = tex2D(_Brick2, float2(i.uv.x * _Column, i.uv.y * _Row));

                fixed3 tangentLightDir = normalize(i.lDirTS);
                fixed3 tangentViewDir = normalize(i.vDirTS);
                fixed4 packedNormal1 = tex2D(_Normal1, float2(i.uv.z * _Column, i.uv.w * _Row));
                fixed4 packedNormal2 = tex2D(_Normal2, float2(i.uv.z * _Column, i.uv.w * _Row));

                int isodd = floor(i.uv.x * _Column) + floor(i.uv.y * _Row);

                fixed4 albedo = isodd % 2 == 0 ? brick1 : brick2;
                fixed3 tangentNormal = isodd % 2 == 0 ? UnpackNormal(packedNormal1) : UnpackNormal(packedNormal2);
                tangentNormal.xy *= _BumpScale;
                tangentNormal.z *= sqrt(1.0 - saturate(dot(tangentNormal.xy, tangentNormal.xy)));

                fixed3 diffuse = _Diffuse.rgb * albedo * (max(0,dot(tangentNormal,tangentLightDir)) * 0.5 + 0.5);
                fixed3 halfDir = normalize(tangentLightDir + tangentViewDir);
                fixed3 specular = fixed3(1,1,1) * _Specular.rgb * pow(max(0, dot(tangentNormal,halfDir)), _Gloss);
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT * albedo;

                return fixed4(diffuse + specular + ambient, 1);
            }
            ENDCG
        }
    }
}
