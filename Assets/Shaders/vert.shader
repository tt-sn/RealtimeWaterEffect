Shader "Unlit/vert"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 100

			GrabPass{ "_WaterGrab" }

		Pass
		{
			Blend One Zero
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				half3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				half4 grabPos : TEXCORD1;
				float4 vertex : SV_POSITION;
				half3 viewNormal : TEXCOORD2;
				half edge : TEXCOORD3; //輪郭の反射用
			};

			sampler2D _MainTex;
			sampler2D _WaterGrab;
			fixed4    _Color;

			v2f vert (appdata v)
			{
				v2f o;
				//頂点をクリッピング
				o.vertex = UnityObjectToClipPos(v.vertex); 
				//正しいテクスチャ座標を取得します
				o.grabPos = ComputeGrabScreenPos(o.vertex);
				//#define COMPUTE_VIEW_NORMAL mul((float3x3)UNITY_MATRIX_IT_MV, v.normal)
				//モデル * ビュー行列の逆行列の転置行列と法線の乗算
				//つまり、法線ベクトルをローカル座標からカメラ座標まで変換している
				o.viewNormal = COMPUTE_VIEW_NORMAL;

				//dot(a,b) : a,bの内積
				//vertex shaderからの頂点座標のxyzをモデルビュー変換行列で乗算したものを正規化したものと、法線ベクトルをモデルビュー行列の逆行列の転置行列の乗算したものの内積を求める.
				//面と視線の向きの内積（平行なら1 : 垂直なら0）
				half _Edge = 1.0 - abs(dot(normalize(mul(UNITY_MATRIX_MV, v.vertex).xyz), o.viewNormal));

				//輪郭部分の強調
				//pow(x,y)のyが大きければ輪郭以外の補正が小さくなる
				o.edge = pow(_Edge, 3);

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{

				//UnityCG.cginc内の埋め込みの関数-------------
				//EncodeFloatRG(float v)をアレンジ------------
				half2 kEncodeMul = float2(1.0, 255.0);
				half kEncodeBit = 1.0 / 255.0;
				half2 enc = kEncodeMul * i.viewNormal.xy;
				enc = frac(enc);
				enc.x -= enc.y * kEncodeBit;
				i.viewNormal.xy = enc * 0.05;
				//--------------ここまで----------------------

				//_MainTexにfragmentで決めたuv座標を設定
				fixed4 col = tex2D(_MainTex, i.uv);
				//ゆがませる
				i.grabPos.xyz -= (1.5 * i.viewNormal).xyz;
				//投影(GrabPass)で取得したテクスチャの色を表面の色にする
				fixed3 MainColor = tex2D(_WaterGrab, (i.grabPos.xyz / i.grabPos.w));
				//MainColorと設定色_Colorの線形補間
				col.rgb = lerp(MainColor, _Color.rgb, _Color.a);
				//輪郭を強調させる補正
				col.rgb += i.edge;
				return col;
			}
			ENDCG
		}
	}
}
