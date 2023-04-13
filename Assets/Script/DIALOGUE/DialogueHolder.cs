using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace DialogueSystem{
    
    public class DialogueHolder : MonoBehaviour
    {
        public event EventHandler OnDialogueAllDone;
        
        private void Awake() {
            StartCoroutine(dialogueSequence());
        }
        

        private IEnumerator dialogueSequence(){
            for(int i=0;i<transform.childCount;i++){
                Deactive();
                
                transform.GetChild(i).gameObject.SetActive(true);
                
                yield return new WaitUntil(()=>transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            OnDialogueAllDone?.Invoke(this,EventArgs.Empty);
            gameObject.SetActive(false);
        }

        private void Deactive(){
            for(int i=0;i<transform.childCount;i++){
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
