using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MomLevelCinematic : MonoBehaviour
{
  [SerializeField]private GameObject[] dialogueCutsceneArray;
    [SerializeField]private DialogueSystem.DialogueHolder[] dialogChecker;
    [SerializeField]private GameObject sangParentBGDialog;
    [SerializeField]private Button SkipButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    // public event EventHandler OnNextSceneGo;


    private CanvasGroup canvas;
    [SerializeField]private Transform playerNextLevelSpawn;
    [SerializeField]private GameObject bossNextLevel;
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject cameraPos;


    [SerializeField]private GameObject Transisi;
    private void Awake() {
        SkipButton.onClick.AddListener(() => {
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.DadLevel); // ga ini fast forward ke insert disk aja , playerSO.level = 1;
            
        });
        canvas = Transisi.GetComponent<CanvasGroup>();
    }
    void Start()
    {
        bossNextLevel.SetActive(false);
        SkipButton.gameObject.SetActive(false);

        for(int i=0;i<dialogueCutsceneArray.Length;i++){
            dialogueCutsceneArray[i].gameObject.SetActive(false);
        }
        dialogChecker[0].OnDialogueAllDone += dialog1_OnDialogueAllDone;
        dialogChecker[1].OnDialogueAllDone += dialog2_OnDialogueAllDone;
        dialogChecker[2].OnDialogueAllDone += dialog3_OnDialogueAllDone;
        dialogChecker[3].OnDialogueAllDone += dialog4_OnDialogueAllDone;


    }


    private void dialog1_OnDialogueAllDone(object sender, System.EventArgs e){
        dialogueCutsceneArray[0].SetActive(false);
        show();
    }
    private void dialog2_OnDialogueAllDone(object sender, System.EventArgs e){
        dialogueCutsceneArray[1].SetActive(false);
        hide();
        
    }
    private void dialog3_OnDialogueAllDone(object sender, System.EventArgs e){
        dialogueCutsceneArray[2].SetActive(false);
        dialogueCutsceneArray[3].SetActive(true);
        
    }
    private void dialog4_OnDialogueAllDone(object sender, System.EventArgs e){
        // introArray[introCheck].GetComponent<IntroUIController>().hide();
        if(SkipButton.gameObject.activeSelf){
            SkipButton.gameObject.SetActive(false);
        }
        LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.DadLevel);
        
    }

    public void show(){
        Transisi.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f).setOnComplete(()=>{
            player.transform.position = playerNextLevelSpawn.position;
            bossNextLevel.SetActive(true);
            cameraPos.transform.position += new Vector3 (0,10,0);
            dialogueCutsceneArray[1].SetActive(true);
            if(playerSO.alreadyPlayed){
                StartCoroutine(showSkipButton());
            }
        });
    }
    public void hide(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.5f).setOnComplete(()=>{
            dialogueCutsceneArray[2].SetActive(true);
        });
        Transisi.SetActive(false);
    }


    // Update is called once per frame

    private IEnumerator showSkipButton(){
        yield return new WaitForSeconds(5f);
        SkipButton.gameObject.SetActive(true);
    }
}
