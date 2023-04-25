using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField]private DKGameManager gameManager;
    private Animator animatorController;
    private const string IS_ATTACK = "IsAttack";
    private const string IS_BACK = "IsBack";
    [SerializeField]private GameObject Ghost;
    private void Awake() {
        Ghost.SetActive(false);
        animatorController = GetComponent<Animator>();
        
    }
    private void Start() {
        
        animatorController.SetBool(IS_ATTACK, false);
        gameManager.OnCinematicGame += gameManager_OnCinematicGame;
    }
    private void Update() {
        animatorController.SetBool(IS_ATTACK, gameManager.IsGameStart());
    }
    private void gameManager_OnCinematicGame(object sender, System.EventArgs e){ 
        animatorController.SetTrigger(IS_BACK);
    }
    public void GhostOut(){
        Ghost.SetActive(true);
    }
    
}
