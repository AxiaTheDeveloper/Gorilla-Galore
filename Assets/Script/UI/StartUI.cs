using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class StartUI : MonoBehaviour
{
    private CanvasGroup canvas;
    public event EventHandler OnInteractStartGame;
    [SerializeField]private DialogueSystem.DialogueHolder UIInterfaceDialogue;
    private bool isDone;
    private void Awake(){
        canvas = GetComponent<CanvasGroup>();
    }

    private void Start() {
        show();
        UIInterfaceDialogue.OnDialogueAllDone += interfaceDialogue_OnDialogueAllDone;
    }
    private void interfaceDialogue_OnDialogueAllDone(object sender, System.EventArgs e){
        hide();
        OnInteractStartGame?.Invoke(this,EventArgs.Empty);
    }

    private void show(){
        gameObject.SetActive(true);

    }
    private void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            gameObject.SetActive(false);
        });

    }
}
