Shader "Custom/dissolvePro" {
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_DissolveTex("dissolve tex",2D) = ""{}
		//�ܽ�����,��������ͼ��Rֵ����Ϊ�Ǻڰ�ͼ������rgb����һ��ͨ�������ԣ������ܽ��жϣ�����ǲ�ɫͼ�Լ�ȥ�ж����ĸ�ͨ��
		//��ʵ����������ͼ��������ʵ���ܽ���ʽ
		_DissolveColor("dissolve color",Color) = (0,0,0,1)//�ܽ���ɫ
		_EdgeColor("edge olor",Color) = (0,0,0,1)//����ɫ����Ϊ�������Ǳ����ܽ⣬��ʵ���ܽ⵽ĳ���̶Ȼ�����ɫ
		_DissolveProgress("dissolve Progress",Range(0,10)) = 0//�ܽ����
		_DissolveStartParma("dissolve Start Parma",range(0,1)) = 0.7//��ʼ�ܽ����
		_DissolveEdgeParma("dissolve Edge Parma",range(0,1)) = 0.9//��ʼ�ܽ�߲���
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
	#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
	#pragma target 3.0

			sampler2D _MainTex;

		sampler2D _DissolveTex;
		float4 _DissolveColor;
		float4 _EdgeColor;
		float _DissolveProgress;
		float _DissolveStartParma;
		float _DissolveEdgeParma;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

			//��ȡuv�����ϵ�������ɫ
			float dissolve_c_r = tex2D(_DissolveTex, IN.uv_MainTex).r;

			//������ȣ�0,1����Χ��
			float Progress = saturate(_DissolveProgress / 10);

			//������ȴ���������ɫ�������������
			if (Progress > dissolve_c_r)
			{
				//��������
				discard;
			}

			//���㵥��������ɫ��ֵ�ٶ�
			float rate = Progress / dissolve_c_r;

			//��ʼ�ܽ�
			if (rate > _DissolveStartParma)
			{
				c.rgb = lerp(c.rgb, _DissolveColor.rgb, rate);
				//��ʼ��ʾ�ܽ����ɫ���������Ǳ��ܽ⣩����ʵ�����ܽ⵽ĳ���̶Ȼ�һ����ɫ
				if (rate > _DissolveEdgeParma)
				{
					c.rgb = lerp(c.rgb, _EdgeColor.rgb, rate);
				}
			}

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
		}
			FallBack "Diffuse"
}