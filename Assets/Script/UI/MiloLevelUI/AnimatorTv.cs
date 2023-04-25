using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorTv : MonoBehaviour
{
    private Animator animatorController;
    private const string IS_INSERT = "IsInsert";
    [SerializeField]private Button ButtonGo;
    [SerializeField]private PlayerSaveScriptableObj playerSO;

    private void Awake() {
        animatorController = GetComponent<Animator>();
        
    }
    public void Go(){
        animatorController.SetTrigger(IS_INSERT);
            playerSO.level = 1;
        
    }

}
