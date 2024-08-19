using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    [SerializeField] float slowDownFloat;
    [SerializeField] float normalFloat;
    [SerializeField] float speedUpFloat;

    [SerializeField] TimeScale currentScale = TimeScale.Normal;

    public event Action<TimeScale> OnTimeScaleChange;

    public static TimeManager instance;


   public enum TimeScale
    {
        Slowed = 1,
        Normal,
        Speedup,
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetTimeScale(TimeScale timeScale)
    {
        currentScale = timeScale;
        switch (currentScale)
        {
            case TimeScale.Slowed:
                Time.timeScale = 0.5f;
                break;
            case TimeScale.Normal:
                Time.timeScale = 1;
                break;
            case TimeScale.Speedup:
                Time.timeScale = 1.5f;
                break;
        }
        OnTimeScaleChange?.Invoke(timeScale);

    }

}
