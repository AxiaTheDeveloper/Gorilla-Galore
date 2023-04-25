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
        noiseTV.Stop();
    }
    public void PlayCassete(){
        casseteInsert.Play();
    }
    public void StopCassete(){
        casseteInsert.Stop();
    }

    public void PlayBGM(){
        DA_BGM.Play();
    }
    public void PlayBGMOff(){
        DA_BGM.Stop();
    }


    public void PlayHitSound(){
        hitSound.Play();
    }
}
