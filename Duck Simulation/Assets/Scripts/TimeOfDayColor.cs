using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDayColor : MonoBehaviour
{
    public Light sceneLight;

    public Color dawnColor;
    public Color dayColor;
    public Color duskColor;
    public Color nightColor;

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.TimeOfDayChanged += ChangeColor;
    }

    public void ChangeColor(object sender, TimeManager.TimeOfDay timeOfDay)
    {
        switch (timeOfDay)
        {
            case TimeManager.TimeOfDay.Dawn:
                sceneLight.color = dawnColor;
                break;

            case TimeManager.TimeOfDay.Day:
                sceneLight.color = dayColor;
                break;

            case TimeManager.TimeOfDay.Dusk:
                sceneLight.color = duskColor;
                break;

            case TimeManager.TimeOfDay.Night:
                sceneLight.color = nightColor;
                break;
        }
    }
}
