using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


namespace DialogueSystem{
    
    public class DialogueHolder : MonoBehaviour
    {
        public event EventHandler OnDialogueAllDone;
        [SerializeField]private GameObject dialogueBG;
        private CanvasGroup canvas;
        private enum JenisBG{
            animasi,none
        }
        [SerializeField]private JenisBG jenisBG;
        // private bool isAnimasi = true;
        
        private void Awake() {
            
            if(jenisBG == JenisBG.animasi){
                dialogueBG.gameObject.SetActive(false);
                canvas = dialogueBG.GetComponent<CanvasGroup>();
                show();
                

            }
            else{
                StartCoroutine(dialogueSequence());
                
            }
  
        }
        

        private IEnumerator dialogueSequence(){
            yield return new WaitForSeconds(0.1f);
            for(int i=0;i<transform.childCount;i++){
                Deactive();
                
                transform.GetChild(i).gameObject.SetActive(true);
                
                yield return new WaitUntil(()=>transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            OnDialogueAllDone?.Invoke(this,EventArgs.Empty);
            dialogueBG.gameObject.SetActive(false); //10 190 0 255
            gameObject.SetActive(false);
        }

        private void Deactive(){
            for(int i=0;i<transform.childCount;i++){
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        private void show(){
            dialogueBG.gameObject.SetActive(true);
            canvas.alpha = 0;
            canvas.LeanAlpha(1, 0.5f);
            dialogueBG.gameObject.transform.LeanScale(Vector2.one, 0.8f).setOnComplete(()=>{
                StartCoroutine(dialogueSequence());
                // Debug.Log("aa");
            });
            
            
        }
        
    }

}
