using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



namespace DialogueSystem{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished {get; private set;}
        
        [SerializeField]private GameObject pressSpace_Text;
        private void Start() {
            LeanTween.alpha(pressSpace_Text, 0f, 5f); 
            pressSpace_Text.SetActive(false);
        }
        protected IEnumerator dialogueWrite(string input, TextMeshProUGUI textHolder, float delay, AudioClip sound, float delayBetweenLines){
            
            for(int i=0; i<input.Length; i++){
                textHolder.text += input[i];
                // SoundAudioManager.Instance.PlayTypingSound();
                // Debug.Log(input[i]);
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(delayBetweenLines);

            pressSpace_Text.SetActive(true);
            LeanTween.alpha(pressSpace_Text, 1f, 5f);

            yield return new WaitUntil(()=>GameInput.Instance.GetInputContinueUI());
            finished = true;

            
            LeanTween.alpha(pressSpace_Text, 0f, 5f); 
            pressSpace_Text.SetActive(false);
        }
    }
}