using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject attackCollider1, attackCollider2, attackCollider3;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private PlayerMovement playerMovement;
    public enum PlayerName{
        Betty, Mom, Dad
    }
    private PlayerName namesHereCHECK;

    private bool canAttack, timerStart1, timerStart2, timerStart3, isFirstTimeAttack;
    
    [SerializeField]private float attackDuration1,attackDuration2, attackDuration3;
    public event EventHandler OnPlayerAttack;

    private void Start() {
        attackCollider1.SetActive(false);
        attackCollider2.SetActive(false);
        attackCollider3.SetActive(false);
        canAttack = true; 
        timerStart1 = false;
        timerStart2 = false;
        isFirstTimeAttack = true;
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
        if(GameInput.Instance.GetInputInteract() && canAttack && !playerMovement.GetIsClimb()){
            
            if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Betty){
                attackCollider1.SetActive(true);
                namesHereCHECK = PlayerName.Betty;
                canAttack = false;
                OnPlayerAttack?.Invoke(this,EventArgs.Empty);
                timerStart1 = true;
                playerIdentity.IsAttacking(true);
            }
            else if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Mom){
                attackCollider2.SetActive(true);
                namesHereCHECK = PlayerName.Mom;
                canAttack = false;
                OnPlayerAttack?.Invoke(this,EventArgs.Empty);
                timerStart2 = true;
                playerIdentity.IsAttacking(true);
            }
            else if(playerIdentity.GetName() == PlayerIdentity.PlayerName.Dad){
                attackCollider3.SetActive(true);
                namesHereCHECK = PlayerName.Dad;
                canAttack = false;
                OnPlayerAttack?.Invoke(this,EventArgs.Empty);
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
    public bool GetIsFirstTime(){
        return isFirstTimeAttack;
    }
    public void ChangeIsFirstTime(){
        isFirstTimeAttack = false;
    }

}
