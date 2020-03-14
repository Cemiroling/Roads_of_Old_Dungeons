using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame : MonoBehaviour
{
    public float avgFrameRate = 1f;
    public Text displayText;
    private float timer;


    void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            displayText.text = "FPS: " + fps;
            timer = Time.unscaledTime + avgFrameRate;
        }
    }
}
