using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerIdentity playerIdentity;
    private Animator animatorController;
    private const string IS_JALAN = "IsJalan";
    
    private const string IS_CLIMB = "IsClimb";
    private const string IS_DEATH = "IsDeath";
    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        animatorController.SetBool(IS_JALAN, false);
        animatorController.SetBool(IS_CLIMB, false);

        playerMovement.OnClimb += playerMove_OnClimb;
        playerMovement.OnNotClimb += playerMove_OnNotClimb;
        playerMovement.OnClimbNotMove += playerMove_OnClimbNotMove;
        playerMovement.OnClimbMove += playerMove_OnClimbMove;

        playerIdentity.OnDeath += playerIdentity_OnDeath;
    }
    private void playerMove_OnClimbNotMove(object sender, System.EventArgs e){
        animatorController.speed = 0f;
        Debug.Log("Jalan di tangga");
    }
    private void playerMove_OnClimbMove(object sender, System.EventArgs e){
        
        animatorController.speed = 1f;
        Debug.Log("Diam di tangga");
    }
    private void playerMove_OnClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, true);
        animatorController.speed = 1f;

    }
    private void playerMove_OnNotClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, false);
        animatorController.speed = 1f;
        
    }
    private void playerIdentity_OnDeath(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_DEATH);

    }

    private void Update() {
        animatorController.SetBool(IS_JALAN, playerMovement.GetIsJalan());
    }

    private void playerDeath(){
        DKGameManager.Instance.setGameOver(false);
    }
}
