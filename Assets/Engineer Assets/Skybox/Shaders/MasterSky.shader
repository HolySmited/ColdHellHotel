// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.03 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.03;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4999,x:34297,y:32121,varname:node_4999,prsc:2|emission-7905-OUT;n:type:ShaderForge.SFN_Panner,id:56,x:31155,y:32564,varname:node_56,prsc:2,spu:0.0002,spv:0|DIST-3549-OUT;n:type:ShaderForge.SFN_Color,id:534,x:31500,y:31530,ptovrint:False,ptlb:HorizionColor,ptin:_HorizionColor,varname:node_534,prsc:2,glob:False,c1:0,c2:0.4439655,c3:0.7573529,c4:1;n:type:ShaderForge.SFN_Lerp,id:7766,x:32263,y:31847,varname:node_7766,prsc:2|A-8599-OUT,B-9410-OUT,T-7962-OUT;n:type:ShaderForge.SFN_Color,id:8303,x:31477,y:32243,ptovrint:False,ptlb:ZenithColor,ptin:_ZenithColor,varname:node_8303,prsc:2,glob:False,c1:0.4797794,c2:0.6158215,c3:0.75,c4:1;n:type:ShaderForge.SFN_Vector1,id:7460,x:30775,y:31974,varname:node_7460,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:68,x:30961,y:31807,varname:node_68,prsc:2|VAL-7076-OUT,EXP-7460-OUT;n:type:ShaderForge.SFN_Power,id:5289,x:31133,y:31966,varname:node_5289,prsc:2|VAL-3474-OUT,EXP-7460-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7076,x:30775,y:31807,varname:node_7076,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-8246-OUT;n:type:ShaderForge.SFN_Multiply,id:8246,x:30605,y:31807,varname:node_8246,prsc:2|A-2168-UVOUT,B-5462-OUT;n:type:ShaderForge.SFN_TexCoord,id:2168,x:30398,y:31657,varname:node_2168,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:5462,x:30398,y:31853,varname:node_5462,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_OneMinus,id:3474,x:31133,y:31807,varname:node_3474,prsc:2|IN-68-OUT;n:type:ShaderForge.SFN_OneMinus,id:7962,x:31307,y:31966,varname:node_7962,prsc:2|IN-5289-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2287,x:32495,y:32004,ptovrint:False,ptlb:Desaturation,ptin:_Desaturation,varname:node_2287,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Desaturate,id:1951,x:32495,y:31808,varname:node_1951,prsc:2|COL-7766-OUT,DES-2287-OUT;n:type:ShaderForge.SFN_Lerp,id:5119,x:32954,y:32207,varname:node_5119,prsc:2|A-1951-OUT,B-5870-OUT,T-7561-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6520,x:33933,y:32336,ptovrint:False,ptlb:SkyBrightness,ptin:_SkyBrightness,varname:node_6520,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7905,x:33933,y:32184,varname:node_7905,prsc:2|A-5812-OUT,B-6520-OUT;n:type:ShaderForge.SFN_Vector1,id:5870,x:32235,y:32481,varname:node_5870,prsc:2,v1:1;n:type:ShaderForge.SFN_ConstantClamp,id:7590,x:32235,y:32558,varname:node_7590,prsc:2,min:0,max:1|IN-9427-OUT;n:type:ShaderForge.SFN_Lerp,id:9427,x:32046,y:32515,varname:node_9427,prsc:2|A-4175-OUT,B-7430-OUT,T-811-OUT;n:type:ShaderForge.SFN_Vector1,id:7430,x:31868,y:32536,varname:node_7430,prsc:2,v1:1;n:type:ShaderForge.SFN_ConstantClamp,id:811,x:31974,y:32653,varname:node_811,prsc:2,min:0,max:1|IN-8411-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4175,x:32046,y:32449,ptovrint:False,ptlb:StormClouds (Needs work),ptin:_StormCloudsNeedswork,varname:node_4175,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Add,id:8411,x:31730,y:32676,varname:node_8411,prsc:2|A-8721-OUT,B-1662-OUT;n:type:ShaderForge.SFN_Multiply,id:8721,x:31565,y:32579,varname:node_8721,prsc:2|A-7551-OUT,B-2204-RGB;n:type:ShaderForge.SFN_ValueProperty,id:7551,x:31358,y:32526,ptovrint:False,ptlb:Clouds (Not Functional),ptin:_CloudsNotFunctional,varname:node_7551,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_Time,id:3068,x:30695,y:32600,varname:node_3068,prsc:2;n:type:ShaderForge.SFN_Vector1,id:8818,x:30719,y:32817,varname:node_8818,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:3549,x:30878,y:32699,varname:node_3549,prsc:2|A-3068-T,B-8818-OUT;n:type:ShaderForge.SFN_Panner,id:7110,x:31119,y:32871,varname:node_7110,prsc:2,spu:0.0001,spv:0|DIST-3549-OUT;n:type:ShaderForge.SFN_Add,id:1662,x:31658,y:33035,varname:node_1662,prsc:2|A-4449-R,B-5357-OUT;n:type:ShaderForge.SFN_Multiply,id:5357,x:31477,y:33235,varname:node_5357,prsc:2|A-6709-OUT,B-3722-R;n:type:ShaderForge.SFN_Vector1,id:6709,x:31271,y:33143,varname:node_6709,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Panner,id:6343,x:31037,y:33143,varname:node_6343,prsc:2,spu:0.0002,spv:0|DIST-3549-OUT;n:type:ShaderForge.SFN_Tex2d,id:2204,x:31340,y:32641,ptovrint:False,ptlb:Clouds_2,ptin:_Clouds_2,varname:node_2204,prsc:2,tex:7bbdd3c7df9f23840ab0d8252b797174,ntxv:0,isnm:False|UVIN-56-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4449,x:31392,y:32919,ptovrint:False,ptlb:Clouds_1,ptin:_Clouds_1,varname:node_4449,prsc:2,tex:7bbdd3c7df9f23840ab0d8252b797174,ntxv:0,isnm:False|UVIN-7110-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3722,x:31271,y:33298,ptovrint:False,ptlb:Clouds_3,ptin:_Clouds_3,varname:node_3722,prsc:2,tex:7bbdd3c7df9f23840ab0d8252b797174,ntxv:0,isnm:False|UVIN-6343-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8704,x:33064,y:33224,varname:node_8704,prsc:2|A-7590-OUT,B-471-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:1685,x:32105,y:33086,varname:node_1685,prsc:2,min:0,max:1|IN-2204-RGB;n:type:ShaderForge.SFN_Lerp,id:7182,x:32223,y:32915,varname:node_7182,prsc:2|A-2204-RGB,B-1685-OUT,T-8721-OUT;n:type:ShaderForge.SFN_LightVector,id:4614,x:32121,y:33306,varname:node_4614,prsc:2;n:type:ShaderForge.SFN_Vector1,id:981,x:32121,y:33594,varname:node_981,prsc:2,v1:-1;n:type:ShaderForge.SFN_Multiply,id:9628,x:32121,y:33444,varname:node_9628,prsc:2|A-4614-OUT,B-981-OUT;n:type:ShaderForge.SFN_Clamp01,id:2447,x:32295,y:33444,varname:node_2447,prsc:2|IN-9628-OUT;n:type:ShaderForge.SFN_Power,id:1981,x:32494,y:33444,varname:node_1981,prsc:2|VAL-2447-OUT,EXP-4335-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4335,x:32494,y:33606,ptovrint:False,ptlb:rimFallOff (Not Functional),ptin:_rimFallOffNotFunctional,varname:node_4335,prsc:2,glob:False,v1:10;n:type:ShaderForge.SFN_ValueProperty,id:7321,x:32494,y:33371,ptovrint:False,ptlb:RimBrightness (Not Functional),ptin:_RimBrightnessNotFunctional,varname:node_7321,prsc:2,glob:False,v1:2;n:type:ShaderForge.SFN_Fresnel,id:6609,x:32494,y:33210,varname:node_6609,prsc:2|NRM-7182-OUT;n:type:ShaderForge.SFN_Multiply,id:351,x:32740,y:33210,varname:node_351,prsc:2|A-6609-OUT,B-7321-OUT;n:type:ShaderForge.SFN_Multiply,id:471,x:32740,y:33387,varname:node_471,prsc:2|A-351-OUT,B-1981-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4208,x:33224,y:33738,ptovrint:False,ptlb:CloudDarkness (Not Functional),ptin:_CloudDarknessNotFunctional,varname:node_4208,prsc:2,glob:False,v1:0.05;n:type:ShaderForge.SFN_ValueProperty,id:3647,x:33224,y:33828,ptovrint:False,ptlb:CloudBrightness (Not Functional),ptin:_CloudBrightnessNotFunctional,varname:node_3647,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:7666,x:33456,y:33738,varname:node_7666,prsc:2|A-4208-OUT,B-3647-OUT,T-6187-OUT;n:type:ShaderForge.SFN_Power,id:6187,x:33224,y:33935,varname:node_6187,prsc:2|VAL-8983-OUT,EXP-5029-OUT;n:type:ShaderForge.SFN_Vector1,id:5029,x:33036,y:34087,varname:node_5029,prsc:2,v1:1;n:type:ShaderForge.SFN_Dot,id:3218,x:32766,y:33870,varname:node_3218,prsc:2,dt:0|A-7182-OUT,B-4614-OUT;n:type:ShaderForge.SFN_RemapRange,id:8983,x:32995,y:33870,varname:node_8983,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3218-OUT;n:type:ShaderForge.SFN_Multiply,id:3472,x:33761,y:33561,varname:node_3472,prsc:2|A-7590-OUT,B-7666-OUT;n:type:ShaderForge.SFN_Add,id:9266,x:33971,y:33462,varname:node_9266,prsc:2|A-3472-OUT,B-8704-OUT;n:type:ShaderForge.SFN_Color,id:4950,x:31500,y:31733,ptovrint:False,ptlb:ZenithColorNight,ptin:_ZenithColorNight,varname:node_4950,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:2606,x:31477,y:32064,ptovrint:False,ptlb:HorizonColorNight,ptin:_HorizonColorNight,varname:node_2606,prsc:2,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Vector1,id:5152,x:31675,y:31913,varname:node_5152,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:7896,x:31771,y:32094,varname:node_7896,prsc:2|A-8303-RGB,B-2606-RGB,T-5152-OUT;n:type:ShaderForge.SFN_Lerp,id:12,x:31785,y:31677,varname:node_12,prsc:2|A-534-RGB,B-4950-RGB,T-5152-OUT;n:type:ShaderForge.SFN_Tex2d,id:2290,x:32938,y:32013,ptovrint:False,ptlb:Sun,ptin:_Sun,varname:node_2290,prsc:2,tex:e062d528090b6a94598654160b244236,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5812,x:33274,y:32299,varname:node_5812,prsc:2|A-2290-RGB,B-5119-OUT,T-109-OUT;n:type:ShaderForge.SFN_Vector1,id:109,x:33012,y:32496,varname:node_109,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:804,x:33338,y:32051,varname:node_804,prsc:2|A-2290-RGB,B-5119-OUT;n:type:ShaderForge.SFN_Multiply,id:8599,x:31991,y:31502,varname:node_8599,prsc:2|A-3882-OUT,B-12-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3882,x:31744,y:31425,ptovrint:False,ptlb:HorizionBrightNess,ptin:_HorizionBrightNess,varname:node_3882,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Color,id:5636,x:32415,y:32702,ptovrint:False,ptlb:CloudColor,ptin:_CloudColor,varname:node_5636,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7561,x:32625,y:32512,varname:node_7561,prsc:2|A-7590-OUT,B-5636-RGB;n:type:ShaderForge.SFN_Tex2d,id:8677,x:31973,y:32222,ptovrint:False,ptlb:StarsTexture,ptin:_StarsTexture,varname:node_8677,prsc:2,tex:09678d95293fb4d44bed9284815679ec,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:9410,x:32177,y:32121,varname:node_9410,prsc:2|A-7896-OUT,B-8677-RGB,T-5152-OUT;proporder:534-3882-8303-2606-4950-8677-4449-2204-3722-5636-6520-4175-7551-3647-4208-4335-7321-2287-2290;pass:END;sub:END;*/

Shader "Shader Forge/MasterSky" {
    Properties {
        _HorizionColor ("HorizionColor", Color) = (0,0.4439655,0.7573529,1)
        _HorizionBrightNess ("HorizionBrightNess", Float ) = 1
        _ZenithColor ("ZenithColor", Color) = (0.4797794,0.6158215,0.75,1)
        _HorizonColorNight ("HorizonColorNight", Color) = (0,0,0,1)
        _ZenithColorNight ("ZenithColorNight", Color) = (1,1,1,1)
        _StarsTexture ("StarsTexture", 2D) = "white" {}
        _Clouds_1 ("Clouds_1", 2D) = "white" {}
        _Clouds_2 ("Clouds_2", 2D) = "white" {}
        _Clouds_3 ("Clouds_3", 2D) = "white" {}
        _CloudColor ("CloudColor", Color) = (1,1,1,1)
        _SkyBrightness ("SkyBrightness", Float ) = 1
        _StormCloudsNeedswork ("StormClouds (Needs work)", Float ) = 0
        _CloudsNotFunctional ("Clouds (Not Functional)", Float ) = 0.5
        _CloudBrightnessNotFunctional ("CloudBrightness (Not Functional)", Float ) = 1
        _CloudDarknessNotFunctional ("CloudDarkness (Not Functional)", Float ) = 0.05
        _rimFallOffNotFunctional ("rimFallOff (Not Functional)", Float ) = 10
        _RimBrightnessNotFunctional ("RimBrightness (Not Functional)", Float ) = 2
        _Desaturation ("Desaturation", Float ) = 0
        _Sun ("Sun", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _TimeEditor;
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float4 _HorizionColor;
            uniform float4 _ZenithColor;
            uniform float _Desaturation;
            uniform float _SkyBrightness;
            uniform float _StormCloudsNeedswork;
            uniform float _CloudsNotFunctional;
            uniform sampler2D _Clouds_2; uniform float4 _Clouds_2_ST;
            uniform sampler2D _Clouds_1; uniform float4 _Clouds_1_ST;
            uniform sampler2D _Clouds_3; uniform float4 _Clouds_3_ST;
            uniform float4 _ZenithColorNight;
            uniform float4 _HorizonColorNight;
            uniform sampler2D _Sun; uniform float4 _Sun_ST;
            uniform float _HorizionBrightNess;
            uniform float4 _CloudColor;
            uniform sampler2D _StarsTexture; uniform float4 _StarsTexture_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 _Sun_var = tex2D(_Sun,TRANSFORM_TEX(i.uv0, _Sun));
                float node_5152 = 0.0;
                float4 _StarsTexture_var = tex2D(_StarsTexture,TRANSFORM_TEX(i.uv0, _StarsTexture));
                float node_7460 = 2.0;
                float node_5870 = 1.0;
                float4 node_3068 = _Time + _TimeEditor;
                float node_3549 = (node_3068.g*4.0);
                float2 node_56 = (i.uv0+node_3549*float2(0.0002,0));
                float4 _Clouds_2_var = tex2D(_Clouds_2,TRANSFORM_TEX(node_56, _Clouds_2));
                float3 node_8721 = (_CloudsNotFunctional*_Clouds_2_var.rgb);
                float2 node_7110 = (i.uv0+node_3549*float2(0.0001,0));
                float4 _Clouds_1_var = tex2D(_Clouds_1,TRANSFORM_TEX(node_7110, _Clouds_1));
                float2 node_6343 = (i.uv0+node_3549*float2(0.0002,0));
                float4 _Clouds_3_var = tex2D(_Clouds_3,TRANSFORM_TEX(node_6343, _Clouds_3));
                float node_7590 = clamp(lerp(_StormCloudsNeedswork,1.0,clamp((node_8721+(_Clouds_1_var.r+(0.5*_Clouds_3_var.r))),0,1)),0,1);
                float3 node_5119 = lerp(lerp(lerp((_HorizionBrightNess*lerp(_HorizionColor.rgb,_ZenithColorNight.rgb,node_5152)),lerp(lerp(_ZenithColor.rgb,_HorizonColorNight.rgb,node_5152),_StarsTexture_var.rgb,node_5152),(1.0 - pow((1.0 - pow((i.uv0*float2(1,1)).g,node_7460)),node_7460))),dot(lerp((_HorizionBrightNess*lerp(_HorizionColor.rgb,_ZenithColorNight.rgb,node_5152)),lerp(lerp(_ZenithColor.rgb,_HorizonColorNight.rgb,node_5152),_StarsTexture_var.rgb,node_5152),(1.0 - pow((1.0 - pow((i.uv0*float2(1,1)).g,node_7460)),node_7460))),float3(0.3,0.59,0.11)),_Desaturation),float3(node_5870,node_5870,node_5870),(node_7590*_CloudColor.rgb));
                float3 emissive = (lerp(_Sun_var.rgb,node_5119,1.0)*_SkyBrightness);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
