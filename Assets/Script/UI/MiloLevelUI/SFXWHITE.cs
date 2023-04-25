using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXWHITE : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject Transisi;

    private CanvasGroup canvas;
    private void Awake() {
        
        canvas = Transisi.GetComponent<CanvasGroup>();
    }

public void show(){
        Transisi.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 1f).setOnComplete(()=>{
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.MiloLevel2);
        });
    }
}
