using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInGameDialogueUI : MonoBehaviour
{
    [SerializeField]private GameObject BGGame;
    [SerializeField]private GameObject Transisi;
    private CanvasGroup canvas;
    [SerializeField]private GameObject UIMulaiDialog, DialogPertama;
    [SerializeField]private Ghost ghost;
    

    private void Awake() {
        canvas = Transisi.GetComponent<CanvasGroup>();
    }
    private void Start() {
        BGGame.SetActive(false);
        UIMulaiDialog.SetActive(false);
        Transisi.SetActive(false);
        
        ghost.OnStartDialogue += ghost_OnStartDialogue;
    }

    public void show(){
        Transisi.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f).setOnComplete(()=>{
            
            BGGame.SetActive(true);
            hide();
            UIMulaiDialog.SetActive(true);
        });
    }
    public void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            DialogPertama.SetActive(true);
        });
        Transisi.SetActive(false);
    }
    
    private void ghost_OnStartDialogue(object sender, System.EventArgs e){
        show();
    }

}
