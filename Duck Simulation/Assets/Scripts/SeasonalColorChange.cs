using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonalColorChange : MonoBehaviour
{
    public MeshRenderer[] meshRendererArray;

    public Color springColor;
    public Color summerColor;
    public Color autumnColor;
    public Color winterColor;

    // Start is called before the first frame update
    void Start()
    {
        TimeManager.Instance.SeasonChanged += ChangeColor;
    }

    public void ChangeColor(object sender, TimeManager.Season season)
    {
        switch (season)
        {
            case TimeManager.Season.Spring:
                foreach (MeshRenderer r in meshRendererArray)
                {
                    r.material.color = springColor;
                }
                break;

            case TimeManager.Season.Summer:
                foreach (MeshRenderer r in meshRendererArray)
                {
                    r.material.color = summerColor;
                }
                break;

            case TimeManager.Season.Autumn:
                foreach (MeshRenderer r in meshRendererArray)
                {
                    r.material.color = autumnColor;
                }
                break;

            case TimeManager.Season.Winter:
                foreach (MeshRenderer r in meshRendererArray)
                {
                    r.material.color = winterColor;
                }
                break;
        }
    }
}
