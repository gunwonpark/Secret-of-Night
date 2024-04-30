using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;
    public float maxNightIntensity = 0.2f; // 밤에 최소한의 밝기

    public Material sunriseSkybox;
    public Material daySkybox;
    public Material sunsetSkybox;
    public Material nightSkybox;

    private const float SUNRISE_TIME = 0.25f;
    private const float SUNSET_TIME = 0.65f;
    private const float SUNRISE_SET_DURATION = 0.05f;

    private void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
    }

    private void Update()
    {
        time = (time + timeRate * Time.deltaTime) % 1.0f;

        UpdateLighting(sun, sunColor, sunIntensity);
        UpdateLighting(moon, moonColor, moonIntensity);

        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionIntensityMultiplier.Evaluate(time);        

        UpdateSkybox();
    }

    // 퀘스트 03이 완료되면 호출될 메서드
    public void OnQuest03Complete()
    {
        Debug.Log("낮으로 바뀜");
        // 한낮으로 시간을 조정
        time = startTime;
    }

    void UpdateLighting(Light lightSource, Gradient colorGradiant, AnimationCurve intensityCurve)
    {
        float intensity = intensityCurve.Evaluate(time);

        lightSource.transform.eulerAngles = (time - (lightSource == sun ? 0.25f : 0.75f)) * noon * 4.0f;
        lightSource.color = colorGradiant.Evaluate(time);
        //lightSource.intensity = intensity;

        // 밤에 최소한의 밝기를 보장합니다.
        if (intensity < maxNightIntensity)
        {
            intensity = maxNightIntensity;
        }

        lightSource.intensity = intensity;

        GameObject go = lightSource.gameObject;
        if (lightSource.intensity == 0 && go.activeInHierarchy)
            go.SetActive(false);
        else if (lightSource.intensity > 0 && !go.activeInHierarchy)
            go.SetActive(true);

        if (QuestManager.I.currentQuest.QuestID == 1001 || QuestManager.I.currentQuest.QuestID == 1002)
        {
            time = startTime;
        }
        else if (QuestManager.I.currentQuest.QuestID == 1004)
        {
            time = 0.8f;
        }        
    }

    private void UpdateSkybox()
    {
        if (time < SUNRISE_TIME)
        {
            setSkybox(nightSkybox);
        }
        else if (time < SUNRISE_TIME + SUNRISE_SET_DURATION)
        {
            setSkybox(sunriseSkybox);
        }
        else if (time < SUNSET_TIME)
        {
            setSkybox(daySkybox);
        }
        else if (time < SUNSET_TIME + SUNRISE_SET_DURATION)
        {
            setSkybox(sunsetSkybox);
        }
        else
        {
            setSkybox(nightSkybox);
        }
    }

    private void setSkybox(Material skybox)
    {
        if (RenderSettings.skybox != skybox)
        {
            RenderSettings.skybox = skybox;
            // 스카이박스 변경 후 조명 환경 업데이트
            DynamicGI.UpdateEnvironment();
        }
    }
}