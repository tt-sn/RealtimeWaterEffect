Shader "Custom/NewSurfaceShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_RimColor("Rim Color", Color) = (0,0,0,0)
	}
		SubShader
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100

		GrabPass{ "_WaterGrab" }
		Pass
	{
		Cull Off
		Blend One Zero
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
		half3 normal : NORMAL;
	};

	struct v2f
	{
		float2 uv : TEXCOORD0;
		float4 vertex : SV_POSITION;
		half4 projCoord: TEXCOORD1; // proj
		half3 viewNormal : TEXCOORD2;
		half define : TEXCOORD3;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;
	fixed4 _Color;
	fixed4 _RimColor;
	sampler2D _WaterGrab;

	v2f vert(appdata v)
	{
		v2f o;
		//頂点を視点座標に変換
		o.vertex = UnityObjectToClipPos(v.vertex);
		
		//uvテクスチャを
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		//頂点座標をテクスチャ座標に変換（？）
		o.projCoord = ComputeGrabScreenPos(o.vertex); //50行とセット
		//モデル * ビュー行列の逆行列の転置行列と法線の乗算
		o.viewNormal = COMPUTE_VIEW_NORMAL;

		//UNITY_MATRIX_MV(モデルビュー変換行列)
		//
		half cN = 1.0 - abs(dot(normalize(mul(UNITY_MATRIX_MV, v.vertex).xyz), o.viewNormal));
		cN *= cN;
		cN *= cN;
		o.define.x = cN;
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{

		//EncodeViewNormalStereo---------------------
		half kScale = 1.7777;
		half2 enc;
		enc = i.viewNormal.xy / (i.viewNormal.z + 1);
		enc /= kScale;
		i.viewNormal.xy = enc;//*0.5+0.5;
		//-------------------------------------------
		fixed4 col = tex2D(_MainTex, i.uv);
		col *= _Color;
		i.projCoord.xy -= i.viewNormal.xy;
		fixed3 baseColor = tex2Dproj(_WaterGrab, UNITY_PROJ_COORD(i.projCoord));
		col.rgb = lerp(baseColor, col.rgb, col.a);
		col.rgb += i.define.x * _RimColor;
		return col;
	}
		ENDCG
	}
	}
}



//Shader "Custom/NewSurfaceShader" {
//		Properties{
//			_Cubemap("Environment", Cube) = "gray" {}
//			_NormalTex("Normal Tex", 2D) = "bump" {}
//			_Distortion("Distortion", Float) = 1
//			
//		}
//
//SubShader{
//			Tags{
//			"Queue" = "Transparent"
//			"RenderType" = "Transparent"
//		}
//
//			GrabPass{}
//
//			CGPROGRAM
//#pragma target 4.0
//#pragma surface surf Standard fullforwardshadows alpha:fade 
//
//		sampler2D _GrabTexture;
//
//		sampler2D _NormalTex;
//		float _Distortion;
//
//		struct Input {
//			float2 uv_NormalTex;
//			float4 screenPos;
//
//			法線ベクトル
//			float3 worldNormal;
//			視線ベクトル
//			float3 viewDir;
//		};
//
//		uniformで宣言
//		samplerCUBE _Cubemap;
//
//
//		void surf(Input IN, inout SurfaceOutputStandard o) {
//
//
//			屈折比（見た目の調整のため）
//			float Rat = 0.6f;
//
//			float3 n = normalize(IN.worldNormal);
//			float3 v = normalize(IN.viewDir);
//
//			視線の反射ベクトル
//			float3 r = reflect(v, n);
//			視線の屈折ベクトル
//			float3 s = refract(v, n, Rat);
//
//			worldNormalが
//			float alpha = 1 - (abs(dot(v, n)));
//			float3 al = lerp(texCUBE(_Cubemap,r) , texCUBE(_Cubemap,s), 0.5f);
//
//			o.Albedo = fixed3(0, 0, 0.3);
//			o.Alpha = alpha;
//			o.Albedo = al;
//
//		}
//
//		ENDCG
//		}
//
//			FallBack "Transparent/Diffuse"
//	}