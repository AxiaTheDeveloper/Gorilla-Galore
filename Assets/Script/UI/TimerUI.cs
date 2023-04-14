using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    
    [SerializeField]private TextMeshProUGUI timer;
    private string timeString;
    private float timeInSeconds;
    private void Start() {
        times();
    }

    private void Update() {
        times();
    }
    private void times(){
        timeInSeconds = DKGameManager.Instance.GetGamePlayTimer();
        // Debug.Log(timeInSeconds);
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        timeString = timeSpan.ToString("mm':'ss");
        timer.text = timeString;

        if(timeInSeconds <= 4f){
            // Debug.Log(timeInSeconds);
            timer.color = new Color32(255,0,27,255);
        }
        else{
            timer.color = new Color32(60,60,60,255);
        }
    }

}
