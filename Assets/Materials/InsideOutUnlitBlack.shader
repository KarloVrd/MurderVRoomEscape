Shader "Custom/InsideOutUnlitBlack"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Front 
        Lighting Off
        ZWrite On
        ZTest LEqual
        Pass
        {
            Color [_Color]
        }
    }
}
