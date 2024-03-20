//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "" {
Properties {
_MainTex ("Particle Texture (Alpha8)", 2D) = "white" { }
}
SubShader {
 Pass {
  Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  Blend SrcAlpha One, SrcAlpha One
  ZWrite Off
  Cull Off
  Fog {
   Mode Off
  }
  GpuProgramID 38786
}
}
}