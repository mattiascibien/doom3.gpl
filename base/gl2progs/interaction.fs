#version 120      
 
varying vec3     			var_Position; 
varying vec2            	var_TexDiffuse;     
varying vec2            	var_TexNormal;     
varying vec2            	var_TexSpecular;    
varying vec4            	var_TexLight; 
varying mat3				var_TangentBitangentNormalMatrix; 
varying vec4            	var_Color;
 
uniform sampler2D   	    u_normalTexture;      
uniform sampler2D   	    u_lightFalloffTexture;      
uniform sampler2D   	    u_lightProjectionTexture;      
uniform sampler2D   	    u_diffuseTexture;      
uniform sampler2D   	    u_specularTexture;     

uniform vec4 				u_lightOrigin;   
uniform vec4 				u_viewOrigin;
uniform vec4 				u_diffuseColor;     
uniform vec4 				u_specularColor;     
 
vec4 lightingModel( vec4 diffuseTerm, vec3 specularTerm, vec3 L, vec3 N, vec3 H ) {   
#if 0
	// half-lambertian blinn-phong lighting model    
	float NdotL = max( ( dot( N, L ) + 0.5 ) / ( 1.0 + 0.5 ), 0.0 ); 
	NdotL *= NdotL; 
	float NdotH = pow( clamp( dot( N, H ), 0.0, 1.0 ), 16 );   
  
	vec4 diffuseLighting = ( diffuseTerm * NdotL ); 
	vec3 specularLighting = ( specularTerm * NdotH );   
 
	return diffuseLighting + vec4( specularLighting.rgb, 1.0 );  
#else 
	// traditional lambertian blinn-phong lighting model
	float NdotL = max( dot( N, L ), 0.0); 
	float NdotH = pow( clamp( dot( N, H ), 0.0, 1.0 ), 16 );  

	return ( diffuseTerm * NdotL ) + vec4( specularTerm * NdotH, 1.0 );   
#endif  
} 
 
void main( void ) {      
	// compute normalized light, view and half angle vectors 
	vec3 L = normalize( u_lightOrigin.xyz - var_Position ); 
	vec3 V = normalize( u_viewOrigin.xyz - var_Position ); 
	vec3 H = normalize( L + V ); 
 
	// compute normal from normal map, move from [0, 1] to [-1, 1] range, normalize 
	// NOTE: this is agb due to the RXGB compression technique used 
	vec3 N = normalize( ( 2.0 * texture2D ( u_normalTexture, var_TexNormal.st ).agb ) - 1.0 ); 
	N = var_TangentBitangentNormalMatrix * N; 

	// compute the diffuse term 
	vec4 diffuse = texture2D( u_diffuseTexture, var_TexDiffuse );  
	diffuse *= u_diffuseColor;  
 
	// compute the specular term 
	vec3 specular = 2.0 * texture2D( u_specularTexture, var_TexSpecular ).rgb;       
	specular *= u_specularColor.rgb;  
  
	// compute light projection and falloff 
	vec3 lightFalloff = texture2D( u_lightFalloffTexture, vec2( var_TexLight.z, 0.5 ) ).rgb;       
	vec3 lightProjection = texture2DProj( u_lightProjectionTexture, var_TexLight.xyw ).rgb; 
 
	// compute lighting model 
    vec4 color = lightingModel( diffuse, specular, L, N, H );  
	color.rgb *= lightProjection; 
	color.rgb *= lightFalloff; 
	color.rgb *= var_Color.rgb; 
 
	// output final color  
	gl_FragColor = color;     
}