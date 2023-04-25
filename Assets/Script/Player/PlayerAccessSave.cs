using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccessSave : MonoBehaviour
{
    public static PlayerAccessSave Instance {get; private set;}
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    [SerializeField]private PlayerIdentity playerIdentity;
    private int levelNow, bestScore;
    private void Awake() {
        Instance = this;
        levelNow = playerSO.level;
        bestScore = playerSO.score[levelNow-1]; //-1 becuz array
        playerSO.baruSajaSelesaiGame = false;
    }
    public void PlayerWin(){
        int scoreNow = playerIdentity.GetPlayerScore();
        if(scoreNow > bestScore){
            playerSO.score[levelNow-1] = scoreNow;
        }
        
        if(levelNow < 4 ){
            playerSO.level++;
        }
    }

    public int GetBestScore(){
        return bestScore;
    }
    public int GetLevelNow(){
        return levelNow;
    }
    

}
