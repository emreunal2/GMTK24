using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInputs : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            TimeManager.instance.SetTimeScale(TimeManager.TimeScale.Normal);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            TimeManager.instance.SetTimeScale(TimeManager.TimeScale.Slowed);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            TimeManager.instance.SetTimeScale(TimeManager.TimeScale.Speedup);
        }
        
    }
}
