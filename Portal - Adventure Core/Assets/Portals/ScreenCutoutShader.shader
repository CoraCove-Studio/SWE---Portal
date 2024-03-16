// ScreenCutoutShader
// This shader performs screen cutout effects based on a texture.

Shader "Unlit/ScreenCutoutShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }

        SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

        // Disable lighting and set other states
        Lighting Off
        Cull Back
        ZWrite On
        ZTest Less
        Fog { Mode Off }

        Pass
        {
            CGPROGRAM

            // Compiler directives for vertex and fragment functions
            #pragma vertex vertexFunc
            #pragma fragment fragmentFunc

            // Include common shader code
            #include "UnityCG.cginc"

            // Input data from vertex to fragment shader
            struct VertexData
            {
                float4 position : POSITION;
                float2 uv : TEXCOORD0;
            };

    // Output data from vertex to fragment shader
    struct VertexToFragment
    {
        float4 position : SV_POSITION;
        float4 screenPos : TEXCOORD1;
    };

    // Vertex Shader
    VertexToFragment vertexFunc(VertexData vertexData)
    {
        VertexToFragment outputData;
        outputData.position = UnityObjectToClipPos(vertexData.position);
        outputData.screenPos = ComputeScreenPos(outputData.position);
        return outputData;
    }

    // Main texture
    sampler2D _MainTex;

    // Fragment Shader
    fixed4 fragmentFunc(VertexToFragment inputData) : SV_Target
    {
        // Normalize screen position
        inputData.screenPos /= inputData.screenPos.w;

    // Sample the main texture based on screen position
    fixed4 color = tex2D(_MainTex, float2(inputData.screenPos.x, inputData.screenPos.y));

    return color;
}

ENDCG
}
    }
}