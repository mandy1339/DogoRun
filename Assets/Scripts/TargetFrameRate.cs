using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;
        //Application.targetFrameRate = 120;
        Application.targetFrameRate = 60;
        //Application.targetFrameRate = -1;
        //QualitySettings.antiAliasing = 0;
        //QualitySettings.shadowCascades = 0;
        //QualitySettings.shadowDistance = 0;
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
