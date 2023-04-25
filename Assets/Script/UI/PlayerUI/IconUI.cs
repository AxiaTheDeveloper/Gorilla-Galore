using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconUI : MonoBehaviour
{
    [SerializeField]private GameObject[] playerIcon;
    [SerializeField]private GameObject[] playerIconBG;
    [SerializeField]private GameObject iconPenandUsedPlayer;
    [SerializeField]private PlayerIdentity playerIdentity;
    private int levelNow;//4 - 3  3 - 2   2 - 1  1 - 0
    private Vector3 iconPenandaPlace;
    private void Start() {
        playerIdentity.OnChangePlayer += playerIdentity_OnChangePlayer;
        levelNow = PlayerAccessSave.Instance.GetLevelNow();
        for(int i=0;i<levelNow;i++){ 
            playerIcon[i].SetActive(true);
            playerIconBG[i].SetActive(true);
        }
        for(int i=3;i>levelNow-1;i--){ 
            playerIcon[i].SetActive(false);
            playerIconBG[i].SetActive(false);
        }
        
        iconPenandUsedPlayer.GetComponent<RectTransform>().anchoredPosition = playerIcon[0].GetComponent<RectTransform>().anchoredPosition;
    }

    private void playerIdentity_OnChangePlayer(object sender, PlayerIdentity.OnChangePlayerEventArgs e){
        iconPenandUsedPlayer.GetComponent<RectTransform>().anchoredPosition = playerIcon[e.names].GetComponent<RectTransform>().anchoredPosition;


    }


    
}
