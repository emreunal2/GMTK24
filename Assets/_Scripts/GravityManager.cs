using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    [SerializeField] float decreasedFloat;
    [SerializeField] float normalGravityFloat;
    [SerializeField] float increasedFloat;

    [SerializeField] GravityScale currentGravityScale = GravityScale.Normal;

    public event Action<GravityScale> OnGravityScaleChange;

    public static GravityManager instance;


    public enum GravityScale
    {
        Decreased,
        Normal,
        Increased,
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SetGravityScale(GravityScale gravityScale)
    {
        currentGravityScale = gravityScale;
        switch (currentGravityScale)
        {
            case GravityScale.Decreased:
                Physics2D.gravity = new Vector3(0f,-1.9f);
                break;
            case GravityScale.Normal:
                Physics2D.gravity = new Vector3(0f, -9.81f);
                break;
            case GravityScale.Increased:
                Physics2D.gravity = new Vector3(0f, -50.7f);
                break;
        }
        OnGravityScaleChange?.Invoke(gravityScale);
    }
}
