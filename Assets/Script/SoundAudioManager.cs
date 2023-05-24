using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAudioManager : MonoBehaviour
{
    public static SoundAudioManager Instance{get; private set;}

    [Header("For MILO LEVEL")]
    [SerializeField]private AudioSource doorCreaks;
    [SerializeField]private AudioSource glowEffect;
    [SerializeField]private AudioSource noiseTV;
    [SerializeField]private AudioSource casseteInsert;
    [Header("For FINAL CUTSCENE")]
    [SerializeField]private AudioSource birdChirp;

    [Header("For DIALOGUE")]
    [SerializeField]private AudioSource hitSound;
    

    [SerializeField]private AudioSource DA_BGM;
    [SerializeField]private float bgmSpeedFade;
    [SerializeField]private float bgmMaxVol;


    private void Awake() {
        Instance = this;
    }
    public void PlayDoorCreaks(){
        doorCreaks.Play();
    }
    public void PlayGlowEffect(){
        glowEffect.Play();
    }
    public void StopGlowEffect(){
        glowEffect.Stop();
    }
    public void PlayNoiseTV(){
        noiseTV.Play();
    }
    public void StopNoiseTV(){
        // Debug.Log("Stop");
        // noiseTV.volume = 0f;
        noiseTV.Stop();
    }
    public void PlayCassete(){
        casseteInsert.Play();
    }
    public void StopCassete(){
        casseteInsert.Stop();
    }

    public void PlayBGM(){
        DA_BGM.volume = 0f;
        DA_BGM.Play();
        StartCoroutine(playFadeBGM());
    }
    public void PlayBGMOff(){
        DA_BGM.Stop();
    }


    public void PlayHitSound(){
        hitSound.Play();
    }

    private IEnumerator playFadeBGM(){
        float volumeNow = DA_BGM.volume;
        yield return new WaitForSeconds(0.1f);
        while(DA_BGM.volume < bgmMaxVol){
            volumeNow += bgmSpeedFade;
            DA_BGM.volume = volumeNow;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
