// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//�ܽ�Ч��
//by��puppet_master
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

				// ���������������ɫ, �����ֵ[С����ֵ]������Ƭ��
				// ������ֵΪ0.1, �������������ϲ�������������rֵС��0.1��Ƭ�ζ��ᱻ����
				// ������������ƫ�ڵ���ɫ(->0)���ȿ�ʼ�ܽ�, ƫ�׵���ɫ(->1)����ܽ�
				clip(dissolveCol.r - _DissolveThreshold);

				fixed4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
		}
}

