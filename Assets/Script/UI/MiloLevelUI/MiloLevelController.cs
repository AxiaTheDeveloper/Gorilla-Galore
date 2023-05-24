using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MiloLevelController : MonoBehaviour
{
    [SerializeField]private GameObject[] introArray;
    [SerializeField]private DialogueSystem.DialogueHolder[] dialogChecker;
    private int introCheck;
    [SerializeField]private Button SkipButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    public event EventHandler OnNextSceneGo;
    [SerializeField]private AudioBGM audioBGM;


    //MUSIC HERE BECAUSE ALMOST TIME"S UP
 
    private void Awake() {
        // SkipButton.onClick.AddListener(() => {
        //     Debug.Log("HALO");
            
            
        // });
    }
    public void buttonSKIP(){
        
        for(int i=0;i<introArray.Length;i++){
                introArray[i].gameObject.SetActive(false);
            }
            introArray[4].SetActive(true);
            SkipButton.gameObject.SetActive(false);
            SoundAudioManager.Instance.PlayBGMOff();
    }

    private void Start() {
        SkipButton.gameObject.SetActive(false);
        if(playerSO.alreadyPlayed){
            StartCoroutine(showSkipButton());
        }
        introCheck = 0;
        OnNextSceneGo += dialog_OnNextSceneGo;
        introArray[0].gameObject.SetActive(true);
        for(int i=1;i<introArray.Length;i++){
            introArray[i].gameObject.SetActive(false);
        }
        dialogChecker[0].OnDialogueAllDone += dialog1_OnDialogueAllDone;
        dialogChecker[1].OnDialogueAllDone += dialog2_OnDialogueAllDone;
        dialogChecker[2].OnDialogueAllDone += dialog3_OnDialogueAllDone;
        dialogChecker[3].OnDialogueAllDone += dialog4_OnDialogueAllDone;
    }
    private void dialog_OnNextSceneGo(object sender, System.EventArgs e){
        introArray[introCheck].GetComponent<IntroUIController>().show();
    }
    private void dialog1_OnDialogueAllDone(object sender, System.EventArgs e){
        SoundAudioManager.Instance.PlayDoorCreaks(); 
        //matiin dl krn blm ada sound
        // introArray[introCheck].gameObject.SetActive(false);
        ++introCheck;
        OnNextSceneGo?.Invoke(this,EventArgs.Empty);
    }
    private void dialog2_OnDialogueAllDone(object sender, System.EventArgs e){
        introArray[introCheck].GetComponent<IntroUIController>().hide();
        
    }
    private void dialog3_OnDialogueAllDone(object sender, System.EventArgs e){
        introArray[introCheck].GetComponent<IntroUIController>().hide();
        
    }
    private void dialog4_OnDialogueAllDone(object sender, System.EventArgs e){
        // introArray[introCheck].GetComponent<IntroUIController>().hide();
        
        introArray[0].SetActive(false);
        introArray[3].SetActive(false);
        introArray[4].SetActive(true);
        if(SkipButton.gameObject.activeSelf){
            SkipButton.gameObject.SetActive(false);
        }
    }
    public void OnNextScene(){
        ++introCheck;
        OnNextSceneGo?.Invoke(this,EventArgs.Empty);
    }
    private IEnumerator showSkipButton(){
        yield return new WaitForSeconds(5f);
        SkipButton.gameObject.SetActive(true);
    }
    
}
