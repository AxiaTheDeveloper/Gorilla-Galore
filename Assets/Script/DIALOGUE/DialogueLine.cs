using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



namespace DialogueSystem{
    public class DialogueLine : DialogueBase
    {
        
        private TextMeshProUGUI textHolder;
        [Header("Text Options")]
        [SerializeField]private string input;
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;
        [SerializeField]private float imagePosition;
        [SerializeField]private AudioClip sound;
        [SerializeField]private Sprite charaSprite;
        [SerializeField]private Image imageHolder;
        private enum ImagePlace{
            left,right
        }
        [SerializeField]private ImagePlace placement;

        private enum JenisLine{
            Dialogue,Interface
        }
        [SerializeField]private JenisLine jenisLine;
        

        

        private void Awake() {
            textHolder = GetComponent<TextMeshProUGUI>();
            
        }
        private void Start() {
            textHolder.text = "";
            if(jenisLine == JenisLine.Dialogue){
                imageHolder.sprite = charaSprite;
                imageHolder.preserveAspect = true;
                Vector2 newPosition = imageHolder.rectTransform.anchoredPosition;
                if(placement == ImagePlace.left){
                    newPosition.x = -imagePosition;
                    
                }else{
                    newPosition.x = imagePosition;
                }
                imageHolder.rectTransform.anchoredPosition = newPosition;
            }
            
            StartCoroutine(dialogueWrite(input, textHolder, delay, sound, delayBetweenLines));
            
        }
    }
}
