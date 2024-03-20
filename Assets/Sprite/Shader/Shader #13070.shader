//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "" {
Properties {
_MainTex ("Sprite Texture", 2D) = "white" { }
_Color ("Tint", Color) = (1,1,1,1)
_Angle ("Angle", Range(0, 360)) = 0
_Arc1 ("Arc Point 1", Range(0, 360)) = 15
_Arc2 ("Arc Point 2", Range(0, 360)) = 15
[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
}
SubShader {
 Pass {
  Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  Blend One OneMinusSrcAlpha, One OneMinusSrcAlpha
  ZWrite Off
  Cull Off
  GpuProgramID 9769
}
}
}