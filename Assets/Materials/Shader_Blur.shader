Shader "Custom/dissolvePro" {
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_DissolveTex("dissolve tex",2D) = ""{}
		//溶解纹理,根据这张图的R值（因为是黑白图所以用rgb其中一个通道都可以）来做溶解判断，如果是彩色图自己去判断用哪个通道
		//其实就是用这张图的特征来实现溶解样式
		_DissolveColor("dissolve color",Color) = (0,0,0,1)//溶解颜色
		_EdgeColor("edge olor",Color) = (0,0,0,1)//边颜色，因为看起来是边在溶解，其实是溶解到某个程度换个颜色
		_DissolveProgress("dissolve Progress",Range(0,10)) = 0//溶解进度
		_DissolveStartParma("dissolve Start Parma",range(0,1)) = 0.7//开始溶解参数
		_DissolveEdgeParma("dissolve Edge Parma",range(0,1)) = 0.9//开始溶解边参数
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

			//获取uv坐标上的像素颜色
			float dissolve_c_r = tex2D(_DissolveTex, IN.uv_MainTex).r;

			//计算进度（0,1）范围内
			float Progress = saturate(_DissolveProgress / 10);

			//如果进度大于像素颜色则抛弃这个像素
			if (Progress > dissolve_c_r)
			{
				//抛弃像素
				discard;
			}

			//计算单个像素颜色插值速度
			float rate = Progress / dissolve_c_r;

			//开始溶解
			if (rate > _DissolveStartParma)
			{
				c.rgb = lerp(c.rgb, _DissolveColor.rgb, rate);
				//开始显示溶解边颜色（看起来是便溶解），其实就是溶解到某个程度换一种颜色
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