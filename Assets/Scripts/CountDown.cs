using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    static CountDown instance;
    public static CountDown Instance { get { return instance; } }
    static float remainingTime = 0;
    [SerializeField] Text timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void refreshTimer()
    {
        remainingTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            return;
        }

        remainingTime -= Time.unscaledDeltaTime;
        float seconds = remainingTime;
        timer.text = (Mathf.Round(seconds * 1000f) / 1000f) + " seconds";

        if (remainingTime <= 0 )
        {
            timer.text = "";
        }
    }
}
