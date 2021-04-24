Shader "Unlit/Snow"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("NoiseTex", 2D) = "white" {}

        _SnowSize ("SnowSize", Range(0,1)) = 0.5
        _NoiseAmount ("NoiseAmount", Range(0,1)) = 0
        _SnowAmount ("SnowAmount", Range(0,1)) = 0

    }
    SubShader
    {
        Tags {"Queue"="Transparent"  "IgnoreProjector"="true" "RenderType"="Transparent" }
        Pass
        {
            ZWrite on
            ColorMask 0
        }
        Pass
        {
            Tags{"LightMode"="ForwardBase"}

            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _NoiseTex;
            float4 _NoiseTex_ST;

            float _SnowAmount;
            float _NoiseAmount;
            float _SnowSize;

            float Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv.zw = TRANSFORM_TEX(v.uv, _NoiseTex);
                return o;
            }

            fixed2 randVec(fixed2 value)
			{
				fixed2 pos = fixed2(dot(value, fixed2(127.1, 337.1)), dot(value, fixed2(269.5, 183.3)));
				pos = frac(sin(pos) * 43758.5453123);
				return pos;
			}

			//泰森多边形
			float4 worleyNoise(float2 uv)
			{
				fixed2 index = floor(uv);
				float2 pos = frac(uv);
				//其中x分量存储最短距离，y分量存储第二近的距离
				float4 d = float4(1.5, 1.5, 1.5, 1.5);
				//周围8点加上自己共9个点范围为（-1，1）,实际使用时需加上index
				for (int i = -1; i < 2; i++)
					for (int j = -1; j < 2; j++)
					{
						//判断该点属于哪个Voronoi块内，进行距离判断的时候是在（-1，1）的二维坐标中进行

						//先生成随机点，该p为偏移量
						fixed2 p = randVec(index + fixed2(i, j));
						//然后获取该随机点到该uv点的距离，p + fixed2(i, j)为新点位置，pos为相对原点（0，0）的位置
						float dist = length(p + fixed2(i, j) - pos);
						if (dist < d.x)
						{
							d.y = d.x;
							d.x = dist * 4;
                            d.zw = index + fixed2(i, j);
						}
						else
						{
							d.y = min(dist, d.y);
						}
					}
				return d;
			}

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv.xy);

                i.uv.z += _Time.x * Speed;
                i.uv.w -= _Time.x * Speed;
                float4 d = worleyNoise(i.uv.zw * _NoiseAmount * 100);
                fixed4 snow = tex2D(_NoiseTex, d.zw / 100);

                d.x = step(_SnowAmount, snow.r) ? 1 : d.x;

                float alpha = saturate(_SnowSize - d.x);
                alpha *= saturate(i.uv.x / (i.uv.y + 0.0001));
                fixed4 finalColor = saturate(fixed4(1,1,1,alpha));
                
                return finalColor;
            }
            ENDCG
        }
    }
}
