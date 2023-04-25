using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private PlayerAccessSave playerSave;
    [SerializeField]private TextMeshProUGUI playerScoreText;
    [SerializeField]private TextMeshProUGUI bestScoreText;

    private int score, bestScore;
    
    private void Start() {
        playerIdentity.OnChangeScore += playerIdentity_OnChangeScore;
        score = 0;
        bestScore = playerSave.GetBestScore();

        //siapin tempatnya~~
        bestScoreText.text = bestScore.ToString("D6");
        playerScoreText.text = score.ToString("D6");
        
    }
    private void playerIdentity_OnChangeScore(object sender, PlayerIdentity.OnChangeScoreEventArgs e){
        score = e.playerScore;
        playerScoreText.text = score.ToString("D6");
        

    }
}
