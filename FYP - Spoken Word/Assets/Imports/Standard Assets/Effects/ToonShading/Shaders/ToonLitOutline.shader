Shader "Toon/Lit Outline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (35,27,103,1)
		_Outline ("Outline width", Range (-1, 1)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		UsePass "Toon/Lit/FORWARD"
		UsePass "Toon/Basic Outline/OUTLINE"
	} 
	
	Fallback "Toon/Lit"
}