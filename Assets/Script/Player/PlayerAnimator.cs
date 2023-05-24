using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerIdentity playerIdentity;
    [SerializeField] private PlayerAttack playerAttack;
    private Animator animatorController;
    private const string IS_JALAN = "IsJalan";
    
    private const string IS_CLIMB = "IsClimb";
    private const string IS_DEATH = "IsDeath";
    private const string IS_JUMP = "IsJump";
    private const string IS_ATTACK = "IsAttack";
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

        playerMovement.OnJump += playerMove_OnJump;
        playerMovement.OnNotJump += playerMove_OnNotJump;

        playerIdentity.OnDeath += playerIdentity_OnDeath;

        playerAttack.OnPlayerAttack += playerAttack_OnPlayerAttack;
    }
    private void playerMove_OnClimbNotMove(object sender, System.EventArgs e){
        animatorController.speed = 0f;
        // Debug.Log("Jalan di tangga");
    }
    private void playerMove_OnClimbMove(object sender, System.EventArgs e){
        
        animatorController.speed = 1f;
        // Debug.Log("Diam di tangga");
    }
    private void playerMove_OnClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, true);
        animatorController.speed = 1f;

    }
    private void playerMove_OnNotClimb(object sender, System.EventArgs e){
        animatorController.SetBool(IS_CLIMB, false);
        animatorController.speed = 1f;
        
    }
    private void playerMove_OnJump(object sender, System.EventArgs e){
        animatorController.SetBool(IS_JUMP, true);
        

    }
    private void playerMove_OnNotJump(object sender, System.EventArgs e){
        animatorController.SetBool(IS_JUMP, false);
        
        
    }
    private void playerIdentity_OnDeath(object sender, System.EventArgs e){
        animatorController.SetTrigger(IS_DEATH);

    }
    private void playerAttack_OnPlayerAttack(object sender, System.EventArgs e){
        
        animatorController.SetTrigger(IS_ATTACK);
    }

    private void Update() {
        animatorController.SetBool(IS_JALAN, playerMovement.GetIsJalan());
    }

    public void DeathScreen(){
        DKGameManager.Instance.gameOverDeath();
    }

}
