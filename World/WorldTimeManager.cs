using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class WorldTimeManager : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColour;
    [SerializeField] Color dayLightColour = Color.white;
    [SerializeField] Color sunsetLightColour;
    [SerializeField] Color sunriseLightColour;
    [SerializeField] AnimationCurve timeCurve;

    float worldTime;

    float Hours
    {
        get { return worldTime / 3600f; }
    }

    [SerializeField] float timeScale = 60f;

    [SerializeField] Text clock;

    [SerializeField] Light2D globalLight;
    private int days = 0;

    private void Update()
    {
        worldTime += Time.deltaTime * timeScale;

        //clock.text = Hours.ToString();

        float curveValue = timeCurve.Evaluate(Hours);
        //TODO add sunrise and sunset
        Color lightColor = Color.Lerp(dayLightColour, nightLightColour, curveValue);

        globalLight.color = lightColor;

        if (worldTime > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        worldTime = 0f;
        days += 1;
    }
}
