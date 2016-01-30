Shader "Hidden/Trixels"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct v2f{
                float4 position : SV_POSITION;
            };

           	sampler2D _MainTex;

            v2f vert(float4 v:POSITION) : SV_POSITION {
                v2f o;
                o.position = mul (UNITY_MATRIX_MVP, v);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
			    float2 inFragCoord = i.position.xy;
			    //inFragCoord.y = iResolution.y - inFragCoord.y;
			    float2 inUV = inFragCoord / _ScreenParams.xy;
			    half4 color = tex2D(_MainTex, inUV);
			    float divider = cos(_Time.y/1.5)/2.0 + 0.5;
			    //float divider = 0.5;
			    
			    if(inUV.x > divider + 0.001)
			    {
			        float height = _ScreenParams.x/60.0; // <---------- CHANGE ME TO CHANGE HOW BIG THE TRIXELS ARE
			        //float height = _ScreenParams.x/(40.0+(divider*40.0));
			        float halfHeight = height*0.5;
			        float halfBase = height/sqrt(3.0);
			        float base = halfBase*2.0;

			        float screenX = inFragCoord.x;
			        float screenY = inFragCoord.y;    

			        float upSlope = height/halfBase;
			        float downSlope = -height/halfBase;

			        float oddRow = fmod(floor(screenY/height),2.0);
			        screenX -= halfBase*oddRow;
			        
			        float oddCollumn = fmod(floor(screenX/halfBase), 2.0);

			        float localX = fmod(screenX, halfBase);
			        float localY = fmod(screenY, height);

			        if(oddCollumn == 0.0 )
			        {
			            if(localY >= localX*upSlope)
			            {
			                screenX -= halfBase;
			            }
			        }
			        else
			        {
			            if(localY <= height+localX*downSlope)
			            {
			                screenX -= halfBase;
			            }
			        }
			        
			        
			        float startX = floor(screenX/halfBase)*halfBase;
			        float startY = floor(screenY/height)*height;
			        float4 blend = float4(0.0,0.0,0.0,0.0);
			        for(float x = 0.0; x < 3.0; x += 1.0)
			        {
			            for(float y = 0.0; y < 3.0; y += 1.0)
			            {
			                float2 screenPos = float2(startX+x*halfBase,startY+y*halfHeight);
			                float2 uv = screenPos / _ScreenParams.xy;
			                //uv.x -= 0.5;
			                //blend += vec4(uv,0.5+0.5*sin(_Time.y),1.0);
			                blend += tex2D(_MainTex, uv);
			            }
			        }
			        color = (blend / 9.0);
			        
			        /*
			        float startX = floor(screenX/base)*base + halfBase;
			        float startY = floor(screenY/height)*height + halfHeight;
			        float2 screenPos = float2(startX,startY);
			        float2 uv = screenPos / _ScreenParams.xy;
			        uv.x -= 0.5;
			        //return vec4(uv,0.5+0.5*sin(_Time.y),1.0);
			        color = tex2D(_MainTex, uv);
			        */
			    }
			    else if(inUV.x < divider)
			    {
			        //return vec4(inUV,0.5+0.5*sin(_Time.y),1.0);
			        color = tex2D(_MainTex, inUV);
			    }

			    return color;
            }

            ENDCG
        }
	}
}
