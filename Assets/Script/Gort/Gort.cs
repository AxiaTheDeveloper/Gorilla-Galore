using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Gort : MonoBehaviour
{
      [SerializeField]private GameObject[] dialogueCutsceneArray;
    [SerializeField]private DialogueSystem.DialogueHolder[] dialogChecker;
    [SerializeField]private GameObject sangParentBGDialog;
    [SerializeField]private Button SkipButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    // public event EventHandler OnNextSceneGo;
    private const string BGM_GAME_OBJECT = "BGM";


    private CanvasGroup canvas;



    [SerializeField]private GameObject Transisi;
    private void Awake() {
        SkipButton.onClick.AddListener(() => {
            show();
            
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
        show();
        
        
    }

    public void show(){
        Transisi.SetActive(true);
        canvas.alpha = 0;
        playerSO.baruSajaSelesaiGame = true;
        GameObject bgm = GameObject.Find(BGM_GAME_OBJECT);
        Destroy(bgm);
        canvas.LeanAlpha(1, 1f).setOnComplete(()=>{
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.FinalCutscene);
        });
    }



    // Update is called once per frame

    private IEnumerator showSkipButton(){
        yield return new WaitForSeconds(5f);
        SkipButton.gameObject.SetActive(true);
    }
}
