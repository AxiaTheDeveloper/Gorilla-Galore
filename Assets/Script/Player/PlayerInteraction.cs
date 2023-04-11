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

    //--------------------------------------------
    private int damage, heal;
    private float time, hurtForce;
    private Obstacle obs;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(OBSTACLE_TAG)){
            if(!playerMovement.GetIsHurt()){
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
                Destroy(other.gameObject);
                //terserah destroy ato setactive false, mungkin nanti bs ke setactive false aja ??


            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(HEALING_TAG)){
            heal = other.gameObject.GetComponent<Items>().GetAddHealth();
            playerIdentity.changePlayerHealth(heal);
            Destroy(other.gameObject);
            //add ke player
        }
        else if(other.gameObject.CompareTag(TIME_ENHANCE_TAG)){
            time = other.gameObject.GetComponent<Items>().GetAddTime();
            DKGameManager.Instance.AddGameTime(time);
            Destroy(other.gameObject);
            //add ke game manager
        }
    }

}
