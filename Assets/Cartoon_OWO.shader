Shader "Custom/ToonOutline" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0.001, 0.1)) = 0.01
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed4 _OutlineColor;
        float _OutlineWidth;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;

            // Calculate the outline
            float2 dx = float2(_OutlineWidth, 0);
            float2 dy = float2(0, _OutlineWidth);
            float gradient = max(length(tex2D(_MainTex, IN.uv_MainTex + dx).rgb - c.rgb), length(tex2D(_MainTex, IN.uv_MainTex + dy).rgb - c.rgb));
            float outline = fwidth(gradient);

            // Convert the gradient to grayscale
            float grayscale = dot(_OutlineColor.rgb, float3(0.299, 0.587, 0.114));

            // Apply the outline color
            o.Emission = grayscale * smoothstep(0, outline, gradient);
        }
        ENDCG
    }
    FallBack "Diffuse"
}