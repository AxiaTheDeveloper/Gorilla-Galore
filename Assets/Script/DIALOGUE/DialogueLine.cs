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
        [SerializeField]private Image karakterBoxDialogue, karakterBoxName, karakterBoxNameBlack;
        [SerializeField]private Color karakterBoxColour;
        [SerializeField]private Image karakterInBoxDialogue;
        [SerializeField]private Color karakterInBoxColour;

        [SerializeField]private string input;
        
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;
        [SerializeField]private float imagePositionLeft, imagePositionRight;
        [SerializeField]private float namaHolderPosLeft, namaHolderPosRight;
        [SerializeField]private float boxNamaHolderPosLeft, boxNamaHolderPosRight;
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
                karakterBoxName.color = karakterBoxColour;
                karakterInBoxDialogue.color = karakterInBoxColour;
                // Debug.Log(karakterBoxColour);
            }
            if(jenisLine == JenisLine.Dialogue){
                imageHolder.sprite = charaSprite;
                imageHolder.preserveAspect = true;
                Vector2 newPosition = imageHolder.rectTransform.anchoredPosition;
                Vector2 newPosNameBox = karakterBoxName.rectTransform.anchoredPosition;
                Vector2 newPosNameBoxBlack = karakterBoxNameBlack.rectTransform.anchoredPosition;
                Vector2 newPosNameNameHolder = namaKarakterHolder.rectTransform.anchoredPosition;
                if(placement == ImagePlace.left){
                    newPosition.x = imagePositionLeft;
                    newPosNameBox.x = boxNamaHolderPosRight;
                    newPosNameBoxBlack.x = boxNamaHolderPosRight;
                    newPosNameNameHolder.x = namaHolderPosRight;
                    
                }else{
                    newPosition.x = imagePositionRight;
                    newPosNameBox.x = boxNamaHolderPosLeft;
                    newPosNameBoxBlack.x = boxNamaHolderPosLeft;
                    newPosNameNameHolder.x = namaHolderPosLeft;
                }
                imageHolder.rectTransform.anchoredPosition = newPosition;
                karakterBoxName.rectTransform.anchoredPosition = newPosNameBox;
                karakterBoxNameBlack.rectTransform.anchoredPosition = newPosNameBoxBlack;
                namaKarakterHolder.rectTransform.anchoredPosition = newPosNameNameHolder;
            }
            else if(jenisLine != JenisLine.Dialogue && isKarakter){
                Vector2 newPosNameBox = karakterBoxName.rectTransform.anchoredPosition;
                Vector2 newPosNameBoxBlack = karakterBoxNameBlack.rectTransform.anchoredPosition;
                Vector2 newPosNameNameHolder = namaKarakterHolder.rectTransform.anchoredPosition;
                newPosNameBox.x = boxNamaHolderPosLeft;
                newPosNameBoxBlack.x = boxNamaHolderPosLeft;
                newPosNameNameHolder.x = namaHolderPosLeft;
                karakterBoxName.rectTransform.anchoredPosition = newPosNameBox;
                karakterBoxNameBlack.rectTransform.anchoredPosition = newPosNameBoxBlack;
                namaKarakterHolder.rectTransform.anchoredPosition = newPosNameNameHolder;
            }
            
            StartCoroutine(dialogueWrite(input, textHolder, delay, sound, delayBetweenLines));
            
        }
    }
}
