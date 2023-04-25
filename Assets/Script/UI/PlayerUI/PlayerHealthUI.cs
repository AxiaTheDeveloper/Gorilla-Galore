using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private Image fillHealth;
    [SerializeField]private TextMeshProUGUI healthText;
    private int healthTotal;
    
    
    
    // private bool firstUpdate = true;

    private void Start() {
        playerIdentity.OnChangeHealth += playerIdentity_OnChangeHealth;
        fillHealth.fillAmount = 1f;  
        healthTotal = playerIdentity.GetPlayerHealthTotal();
        healthText.text = healthTotal.ToString() + " / " + healthTotal.ToString();
        fillHealth.color = new Color32(44,255,0,255);
        // Show();
        
    }


    private void playerIdentity_OnChangeHealth(object sender, PlayerIdentity.OnChangeHealthEventArgs e){
        fillHealth.fillAmount = e.playerHealthNormalized;
        healthText.text = e.playerHealth.ToString() + " / " + healthTotal.ToString();
        if(e.playerHealthNormalized >= 0.6f){
            fillHealth.color = new Color32(50,255,50,255);

        }
        else if(e.playerHealthNormalized >= 0.3f){
            fillHealth.color = new Color32(255,170,92,255);

        }
        else{
            fillHealth.color = new Color32(255,26,0,255);
        }
        

    }

    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
