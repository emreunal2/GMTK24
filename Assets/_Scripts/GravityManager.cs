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
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Debug.Log(Physics.gravity);
        if(Input.GetMouseButtonDown(1))
        {
            SetGravityScale(GravityScale.Decreased);
        }
    }

    public void SetGravityScale(GravityScale gravityScale)
    {
        currentGravityScale = gravityScale;
        switch (currentGravityScale)
        {
            case GravityScale.Decreased:
                Physics.gravity = new Vector3(0f,-4.9f,0f);
                break;
            case GravityScale.Normal:
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
                break;
            case GravityScale.Increased:
                Physics.gravity = new Vector3(0f, -14.7f, 0f);
                break;
        }
        OnGravityScaleChange?.Invoke(gravityScale);
    }
}
