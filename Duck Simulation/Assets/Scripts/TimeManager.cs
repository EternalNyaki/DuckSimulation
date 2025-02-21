using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public enum TimeOfDay
    {
        Dawn,
        Day,
        Dusk,
        Night
    }

    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public const float k_hoursPerDay = 24;

    public float lengthOfDay;
    public float daysPerYear;

    public TMP_Text timeOfDayText;
    public TMP_Text seasonText;

    public float time { get; private set; }
    public int date { get; private set; }

    public event EventHandler<TimeOfDay> TimeOfDayChanged;
    public event EventHandler<Season> SeasonChanged;

    private float _hoursPerRealSecond;

    protected override void Initialize()
    {
        base.Initialize();

        UpdateTimeOfDayText(this, GetTimeOfDay());
        UpdateSeasonText(this, GetSeason());

        TimeOfDayChanged += UpdateTimeOfDayText;
        SeasonChanged += UpdateSeasonText;

        _hoursPerRealSecond = k_hoursPerDay / lengthOfDay;

        time = 0f;
        date = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay prevTimeOfDay = GetTimeOfDay();

        time += _hoursPerRealSecond * Time.deltaTime;
        if (time >= k_hoursPerDay)
        {
            Season prevSeason = GetSeason();

            date++;
            if (date > daysPerYear)
            {
                date = 1;
            }

            if (GetSeason() != prevSeason)
            {
                OnSeasonChanged(GetSeason());
            }

            time -= k_hoursPerDay;
        }

        if (GetTimeOfDay() != prevTimeOfDay)
        {
            OnTimeOfDayChanged(GetTimeOfDay());
        }
    }

    public TimeOfDay GetTimeOfDay()
    {

        if (time >= 18f && time <= 20f)
        {
            return TimeOfDay.Dusk;
        }
        else if (time >= 8f && time <= 18f)
        {
            return TimeOfDay.Day;
        }
        else if (time >= 6f && time <= 8f)
        {
            return TimeOfDay.Dawn;
        }
        else
        {
            return TimeOfDay.Night;
        }
    }

    public Season GetSeason()
    {
        if (date > 3 * daysPerYear / 4)
        {
            return Season.Winter;
        }
        else if (date > daysPerYear / 2)
        {
            return Season.Autumn;
        }
        else if (date > daysPerYear / 4)
        {
            return Season.Summer;
        }
        else
        {
            return Season.Spring;
        }
    }

    private void UpdateTimeOfDayText(object sender, TimeOfDay timeOfDay)
    {
        timeOfDayText.text = "Time of Day: " + timeOfDay.ToString();
    }

    private void UpdateSeasonText(object sender, Season season)
    {
        seasonText.text = "Season: " + season.ToString();
    }

    private void OnTimeOfDayChanged(TimeOfDay timeOfDay)
    {
        TimeOfDayChanged?.Invoke(this, timeOfDay);
    }

    private void OnSeasonChanged(Season season)
    {
        SeasonChanged?.Invoke(this, season);
    }
}