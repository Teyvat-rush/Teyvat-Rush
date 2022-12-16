// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//溶解效果
//by：puppet_master
//2017.5.19

Shader "Custom/DissipateEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}

		_DissolveTex("DissolveTex", 2D) = "white" {}
		_DissolveThreshold("DissolveThreshold", Range(0, 1)) = 0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100

			Pass
			{
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
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;

				sampler2D _DissolveTex;
				fixed _DissolveThreshold;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 dissolveCol = tex2D(_DissolveTex, i.uv);

				// 从噪声纹理采样颜色, 如果该值[小于阈值]则丢弃本片段
				// 比如阈值为0.1, 则在噪声纹理上采样的所有像素r值小于0.1的片段都会被丢弃
				// 即噪声纹理上偏黑的颜色(->0)首先开始溶解, 偏白的颜色(->1)最后溶解
				clip(dissolveCol.r - _DissolveThreshold);

				fixed4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
		}
}

