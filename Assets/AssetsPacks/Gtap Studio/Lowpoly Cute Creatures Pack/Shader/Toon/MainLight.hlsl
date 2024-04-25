void MainLight_half(float3 worldPos, out half3 direction, out half3 color, out half distanceAtten, out half shadowAtten)
{
    #ifdef SHADERGRAPH_PREVIEW
        direction = half3(0.5, 0.5, 0);
        color = 1;
        distanceAtten = 1;
        shadowAtten = 1;
    #else
        #ifdef SHADOWS_SCREEN
            half4 clipPos = TransformWorldToHClip(worldPos);
            half4 shadowCoord = ComputeScreenPos(clipPos);
        #else
            half4 shadowCoord = TransformWorldToShadowCoord(worldPos);
        #endif
            Light mainLight = GetMainLight(shadowCoord);
            direction = mainLight.direction;
            color = mainLight.color;
            distanceAtten = mainLight.distanceAttenuation;

        #if !defined(_MAIN_LIGHT_SHADOWS) || defined(_RECEIVE_SHADOWS_OFF)
            shadowAtten = 1.0h;
        #endif

        #ifdef SHADOWS_SCREEN
            shadowAtten = SampleScreenSpaceShadowmap(shadowCoord);
        #else
            ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
            half shadowStrength = GetMainLightShadowStrength();
            shadowAtten = SampleShadowmap(shadowCoord, TEXTURE2D_ARGS(_MainLightShadowmapTexture,
            sampler_MainLightShadowmapTexture),
            shadowSamplingData, shadowStrength, false);
        #endif
    #endif
}
