using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSOnScreen : MonoBehaviour
{
    Rect fpsRect;
    GUIStyle style;
    float fps;
    
    void Start()
    {
        fpsRect = new Rect(500, 5, 400, 100);
        style = new GUIStyle();
        style.fontSize = 40;
        
        StartCoroutine(RecalculateFPS());



    }

    private IEnumerator RecalculateFPS()
    {
        while (true)
        {
            fps = 1 / Time.deltaTime;
            
            //GUI.Label(fpsRect, "FPS:" + fps, style);
            yield return new WaitForSeconds(.2f);
        }
    }

    void OnGUI()
    {
        if (fps < 37f)
        {
            style.fontSize = 80;
        }
        else
        {
            style.fontSize = 40;
        }
        GUI.Label(fpsRect, "FPS:" + fps, style);
    }
}
