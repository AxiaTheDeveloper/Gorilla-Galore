using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudio : MonoBehaviour
{
    [SerializeField]private bool isGlowEffect, isNoiseEffect, isCasseteInsert;
    [SerializeField]private SoundAudioManager soundAudio;
    
    void Start()
    {
        if(isGlowEffect){
            soundAudio.PlayGlowEffect();
        }
        if(isNoiseEffect){
            soundAudio.StopGlowEffect();
            soundAudio.PlayNoiseTV();
        }

        
    }

    public void Cassete(){
        soundAudio.StopNoiseTV();
        soundAudio.PlayCassete();
    }

    
}
