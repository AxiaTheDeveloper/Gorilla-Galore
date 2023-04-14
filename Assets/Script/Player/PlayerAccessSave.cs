using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccessSave : MonoBehaviour
{
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    [SerializeField]private PlayerIdentity playerIdentity;
    private int levelNow, bestScore;
    private void Start() {
        levelNow = playerSO.level;
        bestScore = playerSO.score[levelNow];
    }
    public void PlayerWin(){
        int scoreNow = playerIdentity.GetPlayerScore();
        if(scoreNow > bestScore){
            playerSO.score[levelNow] = scoreNow;
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
