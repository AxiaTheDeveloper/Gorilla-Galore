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
        [SerializeField]private TextMeshProUGUI namaKarakterHolder;
        [SerializeField]private string namaKarakter;
        [SerializeField]private Image karakterBoxDialogue;
        [SerializeField]private Color karakterBoxColour;
        [SerializeField]private Image karakterInBoxDialogue;
        [SerializeField]private Color karakterInBoxColour;

        [SerializeField]private string input;
        
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;
        [SerializeField]private float imagePositionLeft, imagePositionRight;
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
        [SerializeField]private bool isKarakter;
        

        

        private void Awake() {
            textHolder = GetComponent<TextMeshProUGUI>();
            
        }
        private void Start() {
            textHolder.text = "";
            if(isKarakter){
                namaKarakterHolder.text = "";
                namaKarakterHolder.text = namaKarakter;
                karakterBoxDialogue.color = karakterBoxColour;
                karakterInBoxDialogue.color = karakterInBoxColour;
                // Debug.Log(karakterBoxColour);
            }
            if(jenisLine == JenisLine.Dialogue){
                imageHolder.sprite = charaSprite;
                imageHolder.preserveAspect = true;
                Vector2 newPosition = imageHolder.rectTransform.anchoredPosition;
                if(placement == ImagePlace.left){
                    newPosition.x = imagePositionLeft;
                    
                }else{
                    newPosition.x = imagePositionRight;
                }
                imageHolder.rectTransform.anchoredPosition = newPosition;
            }
            
            StartCoroutine(dialogueWrite(input, textHolder, delay, sound, delayBetweenLines));
            
        }
    }
}
