using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundHouse : MonoBehaviour
{
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    [SerializeField]private Image BG;
    [SerializeField]private TextMeshProUGUI text; 
    [SerializeField]private Sprite spriteMalam, spritePagi;
    [SerializeField]private Color colorMalam, colorPagi;
    [SerializeField]private Color textcolorMalam, textcolorPagi;
    private void Start() {
        UpdateBG();
    }
    public void UpdateBG(){
        if(playerSO.baruSajaSelesaiGame){
            BG.sprite = spritePagi;
            text.color = textcolorPagi;
        }
        else{
            BG.sprite = spriteMalam;
            text.color = textcolorMalam;
        }
    }



}
