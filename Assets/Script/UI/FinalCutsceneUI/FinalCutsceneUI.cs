using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FinalCutsceneUI : MonoBehaviour
{
    [SerializeField]private DialogueSystem.DialogueHolder dialogChecker;
    [SerializeField]private GameObject FinalEnding,Dialog,Pembuka;
    [SerializeField]private Button SkipButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    private CanvasGroup canvas;


    //MUSIC HERE BECAUSE ALMOST TIME"S UP
 
    private void Awake() {
        canvas = FinalEnding.GetComponent<CanvasGroup>();
        SkipButton.onClick.AddListener(() => {
            if(!FinalEnding.activeSelf){
                show();
           }
            
        });
    }

    private void Start() {
        
        Dialog.gameObject.SetActive(false);
        FinalEnding.SetActive(false);
        SkipButton.gameObject.SetActive(false);

        // SoundAudioManager.Instance.PlayBirdChirp(); 
        Dialog.gameObject.SetActive(true);
        if(playerSO.alreadyPlayed){
            StartCoroutine(showSkipButton());
        }
        dialogChecker.OnDialogueAllDone += dialog_OnDialogueAllDone;
    }
    private void dialog_OnDialogueAllDone(object sender, System.EventArgs e){
        if(SkipButton.gameObject.activeSelf){
            SkipButton.gameObject.SetActive(false);
        }
        Pembuka.SetActive(false);
        playerSO.level = 4;
        if(!playerSO.alreadyPlayed){
            playerSO.alreadyPlayed = true;
        }
        show();
    }
    
    private IEnumerator showSkipButton(){
        yield return new WaitForSeconds(5f);
        SkipButton.gameObject.SetActive(true);
    }

    public void show(){
        FinalEnding.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f).setOnComplete(()=>{
            hide();
        });
    }
    public void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            FinalEnding.SetActive(false);
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.MainMenu); 
        });
        
    }
}
