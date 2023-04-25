using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MiloLevel2 : MonoBehaviour
{
    [SerializeField]private GameObject[] dialogueCutsceneArray;
    [SerializeField]private DialogueSystem.DialogueHolder[] dialogChecker;
    [SerializeField]private Button SkipButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    private CanvasGroup canvas;
    [SerializeField]private GameObject Transisi;

    private void Awake() {
        SkipButton.onClick.AddListener(() => {
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.BettyLevel); // ga ini fast forward ke insert disk aja , playerSO.level = 1;
            
        });
        canvas = Transisi.GetComponent<CanvasGroup>();
    }
    void Start()
    {
        SkipButton.gameObject.SetActive(false);
        for(int i=0;i<dialogueCutsceneArray.Length;i++){
            dialogueCutsceneArray[i].gameObject.SetActive(false);
        }
        dialogChecker[0].OnDialogueAllDone += dialog1_OnDialogueAllDone;
        dialogChecker[1].OnDialogueAllDone += dialog2_OnDialogueAllDone;
        hide();


    }


    private void dialog1_OnDialogueAllDone(object sender, System.EventArgs e){
        dialogueCutsceneArray[0].SetActive(false);
        dialogueCutsceneArray[1].SetActive(true);
        
    }
    private void dialog2_OnDialogueAllDone(object sender, System.EventArgs e){
        dialogueCutsceneArray[1].SetActive(false);
        if(SkipButton.gameObject.activeSelf){
            SkipButton.gameObject.SetActive(false);
        }
        LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.BettyLevel);
        
    }

    public void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            dialogueCutsceneArray[0].SetActive(true);
            Transisi.SetActive(false);
        });
        
    }


    // Update is called once per frame

    private IEnumerator showSkipButton(){
        yield return new WaitForSeconds(5f);
        SkipButton.gameObject.SetActive(true);
    }
}
