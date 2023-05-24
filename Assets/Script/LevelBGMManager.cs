using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBGMManager : MonoBehaviour
{
    [SerializeField]private AudioSource DA_BGM;
    [SerializeField]private float bgmSpeedFade;
    [SerializeField]private float bgmMaxVol;
    public static LevelBGMManager instance;

    private void Awake() {
        if(!instance){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
        DA_BGM.volume = 0f;
        DA_BGM.Play();
        StartCoroutine(playFadeBGM());
    }
    private IEnumerator playFadeBGM(){
        float volumeNow = DA_BGM.volume;
        while(DA_BGM.volume < bgmMaxVol){
            volumeNow += bgmSpeedFade;
            DA_BGM.volume = volumeNow;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
