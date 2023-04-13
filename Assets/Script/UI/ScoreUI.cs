using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private TextMeshProUGUI playerScoreText;
    private int score;
    
    private void Start() {
        playerIdentity.OnChangeScore += playerIdentity_OnChangeScore;
        score = 0;
        playerScoreText.text = score.ToString("D6");
        
    }
    private void playerIdentity_OnChangeScore(object sender, PlayerIdentity.OnChangeScoreEventArgs e){
        score = e.playerScore;
        playerScoreText.text = score.ToString("D6");
        

    }
}
