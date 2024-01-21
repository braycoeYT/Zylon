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

float4 OnyxDye(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float4 color = tex2D(uImage0, coords);
    float frameY = (coords.y * uImageSize0.y - uSourceRect.y) / uSourceRect.w;
    float frameX = (coords.x * uImageSize0.x - uSourceRect.x) / uSourceRect.w;
    float luminosity = (color.r + color.g + color.b) / 3.0;
    float wave = 1 - frac((frameY * 3.3) + (frameX * 2) + uTime);
    float wave2 = 1 - frac(((frameY * 1.3) + (frameX * -3) + uTime) * 0.65);
    float wave3 = 1 - frac(((frameY * -1.75) + (frameX * 1.3) + uTime) * 0.35);
    float finalMulti = wave * wave2 * wave3 * luminosity;
    color.rgb *= ((finalMulti * 10.5) * uColor) + ((1 - finalMulti) * uSecondaryColor);
    return color * sampleColor;
}

technique Technique1
{
    pass OnyxDyePass
    {
        PixelShader = compile ps_2_0 OnyxDye();
    }
}