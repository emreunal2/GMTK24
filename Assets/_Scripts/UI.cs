using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Image timeImage;
    [SerializeField] Image gravityImage;
    [SerializeField] List<Sprite> gravitySprites;
    [SerializeField] List<Sprite> timeSprites;

    private void Start()
    {
        TimeManager.instance.OnTimeScaleChange += SetTimeSprite;
        GravityManager.instance.OnGravityScaleChange += SetGravitySprite;
    }

    private void OnDisable()
    {
        TimeManager.instance.OnTimeScaleChange -= SetTimeSprite;
        GravityManager.instance.OnGravityScaleChange -= SetGravitySprite;
    }

    public void SetTimeSprite(TimeManager.TimeScale currentScale)
    {
        switch (currentScale) 
        {
            case TimeManager.TimeScale.Slowed:
                timeImage.sprite = timeSprites[0];
                break;
            case TimeManager.TimeScale.Normal:
                timeImage.sprite = timeSprites[1]; 
                break;
            case TimeManager.TimeScale.Speedup:
                timeImage.sprite = timeSprites[2];
                break;
        }
    }

    public void SetGravitySprite(GravityManager.GravityScale currentScale)
    {
        switch (currentScale)
        {
            case GravityManager.GravityScale.Decreased:
                gravityImage.sprite = gravitySprites[0];
                break;
            case GravityManager.GravityScale.Normal:
                gravityImage.sprite= gravitySprites[1]; 
                break;
            case GravityManager.GravityScale.Increased:
                gravityImage.sprite = gravitySprites[2];
                break;
        }
    }

}
