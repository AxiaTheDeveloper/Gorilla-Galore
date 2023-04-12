using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    
    [SerializeField]private PlayerIdentity playerIdentity;
    private const string HEALING_TAG = "Healing";
    private const string TIME_ENHANCE_TAG = "TimeEnhance";
    private const string OBSTACLE_TAG = "Obstacle";
    private const string GROUND_TAG = "Daratan";
    private const string WIN_TAG = "WinTag";

    //--------------------------------------------
    private int damage, heal;
    private float time, hurtForce;
    private Obstacle obs;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(OBSTACLE_TAG)){
            if(!playerMovement.GetIsHurt() && DKGameManager.Instance.IsGameStart()){
                obs = other.gameObject.GetComponent<Obstacle>();
                damage = obs.GetDamage();
                hurtForce = obs.GetHurtForce();
                //ntr ksh demeg ke player jgn lupa;
                if(other.gameObject.transform.position.x > transform.position.x){
                    playerMovement.GotHurt(-hurtForce);
                }
                else{
                    playerMovement.GotHurt(hurtForce);
                }
                playerIdentity.changePlayerHealth(-damage);
                other.gameObject.SetActive(false);
                //terserah destroy ato setactive false, mungkin nanti bs ke setactive false aja ??


            }
            
        }
        if(other.gameObject.CompareTag(GROUND_TAG)){
            if(transform.position.y > other.gameObject.transform.position.y){
                playerMovement.ResetJump();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(HEALING_TAG)){
            heal = other.gameObject.GetComponent<Items>().GetAddHealth();
            playerIdentity.changePlayerHealth(heal);
            other.gameObject.SetActive(false);
            //add ke player
        }
        else if(other.gameObject.CompareTag(TIME_ENHANCE_TAG)){
            time = other.gameObject.GetComponent<Items>().GetAddTime();
            DKGameManager.Instance.AddGameTime(time);
            other.gameObject.SetActive(false);
            //add ke game manager
        }
        else if(other.gameObject.CompareTag(WIN_TAG)){
            DKGameManager.Instance.setGameOver();
        }
    }

}
