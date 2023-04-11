using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject attackCollider1, attackCollider2;
    [SerializeField]private PlayerIdentity playerIdentity;
    public enum PlayerName{
        Bs, Cs
    }
    private PlayerName namesHereCHECK;

    private bool canAttack, timerStart1, timerStart2;
    [SerializeField]private float attackCooldown1,attackCooldown2;

    private void Start() {
        attackCollider1.SetActive(false);
        attackCollider2.SetActive(false);
        canAttack = true; 
        timerStart1 = false;
        timerStart2 = false;
    }
    private void Update() {
        Attack();
        if(timerStart1){
            timerStart1 = false;
            StartCoroutine(startTimerCooldown(attackCooldown1, attackCollider1));
        }
        else if(timerStart2){
            timerStart2 = false;
            StartCoroutine(startTimerCooldown(attackCooldown2, attackCollider2));
        }
    }

    private void Attack(){
        if(GameInput.Instance.GetInputInteract() && canAttack){
            if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Bs){
                attackCollider1.SetActive(true);
                namesHereCHECK = PlayerName.Bs;
                canAttack = false;
                timerStart1 = true;
            }
            if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Cs){
                attackCollider2.SetActive(true);
                namesHereCHECK = PlayerName.Cs;
                canAttack = false;
                timerStart2 = true;
            }
        }
    }

    private IEnumerator startTimerCooldown(float attackCooldown, GameObject attackCollider){
        yield return new WaitForSeconds(attackCooldown);
        attackCollider.SetActive(false);
        canAttack = true;
    } 
    public PlayerName GetName(){
        return namesHereCHECK;
    }

}
