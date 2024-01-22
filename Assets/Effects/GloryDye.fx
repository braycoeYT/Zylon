sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float2 uTargetPosition;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;

float4 GloryDye(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;
    float frameX = (coords.x * uImageSize0.x - uSourceRect.x) / uSourceRect.w;
    
    float time = sin((uTime * 7.5) + (frameY * 8));
    float distortionMapped = time * (0.5 / uImageSize0.x);
    float2 distortionCoords = float2(coords.x + distortionMapped, coords.y);
    float4 color = tex2D(uImage0, distortionCoords);
    float luminosity = (color.r + color.g + color.b) / 3.0;

    float flameWave = (1 - frac((frameY * 3.3) + (frameX * 2) + uTime + time * 0.35)) * 6.28;
    float flameSin = sin(flameWave);

    float finalMulti = flameSin * luminosity;

    color.rgb *= ((finalMulti * uColor * 2) + ((1 - finalMulti) * uSecondaryColor * 8.2));

    return color * sampleColor;
}

technique Technique1
{
    pass GloryDyePass
    {
        PixelShader = compile ps_2_0 GloryDye();
    }
}