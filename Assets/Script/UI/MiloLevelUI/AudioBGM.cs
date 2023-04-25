using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    [SerializeField]private GameObject dialogBirthday;

    private bool isOn=false;
    private void Update() {
        if(!isOn){
            if(dialogBirthday.activeSelf){
                SoundAudioManager.Instance.PlayBGM();
                isOn = true;
            }
        }
    }
    public void TurnOff(){
        SoundAudioManager.Instance.PlayBGMOff();
    }
}
