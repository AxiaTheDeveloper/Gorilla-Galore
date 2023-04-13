using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject attackCollider1, attackCollider2, attackCollider3;
    [SerializeField]private PlayerIdentity playerIdentity;
    public enum PlayerName{
        Bs, Cs, Ds
    }
    private PlayerName namesHereCHECK;

    private bool canAttack, timerStart1, timerStart2, timerStart3;
    
    [SerializeField]private float attackDuration1,attackDuration2, attackDuration3;

    private void Start() {
        attackCollider1.SetActive(false);
        attackCollider2.SetActive(false);
        attackCollider3.SetActive(false);
        canAttack = true; 
        timerStart1 = false;
        timerStart2 = false;
    }
    private void Update() {
        Attack();
        if(timerStart1){
            timerStart1 = false;
            StartCoroutine(startTimerCooldown(attackDuration1, attackCollider1));
        }
        else if(timerStart2){
            timerStart2 = false;
            StartCoroutine(startTimerCooldown(attackDuration2, attackCollider2));
        }
        else if(timerStart3){
            timerStart3 = false;
            StartCoroutine(startTimerCooldown(attackDuration3, attackCollider3));
        }
    }

    private void Attack(){
        if(GameInput.Instance.GetInputInteract() && canAttack){
            if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Bs){
                attackCollider1.SetActive(true);
                namesHereCHECK = PlayerName.Bs;
                canAttack = false;
                timerStart1 = true;
                playerIdentity.IsAttacking(true);
            }
            else if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Cs){
                attackCollider2.SetActive(true);
                namesHereCHECK = PlayerName.Cs;
                canAttack = false;
                timerStart2 = true;
                playerIdentity.IsAttacking(true);
            }
            else if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Ds){
                attackCollider3.SetActive(true);
                namesHereCHECK = PlayerName.Ds;
                canAttack = false;
                timerStart3 = true;
                playerIdentity.IsAttacking(true);
            }
        }
    }

    private IEnumerator startTimerCooldown(float attackDuration, GameObject attackCollider){
        yield return new WaitForSeconds(attackDuration);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        canAttack = true;
        playerIdentity.IsAttacking(false);
    } 
    public PlayerName GetName(){
        return namesHereCHECK;
    }

}
