using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroUIController : MonoBehaviour
{
    [SerializeField]private GameObject dialogSystem;
    private CanvasGroup canvas;
    [SerializeField]private MiloLevelController miloController;

    private void Awake() {
        canvas = GetComponent<CanvasGroup>();
    }
    private void Start() {
        dialogSystem.SetActive(false);
    }
    public void show(){
        gameObject.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f).setOnComplete(()=>{
            dialogSystem.SetActive(true);
        });
    }
    public void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            miloController.OnNextScene();
        });
        gameObject.SetActive(false);
    }
}
