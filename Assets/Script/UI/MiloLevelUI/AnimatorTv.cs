using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorTv : MonoBehaviour
{
    private Animator animatorController;
    private const string IS_INSERT = "IsInsert";
    private const string HAS_FIRST = "HasFirst";
    [SerializeField]private Button ButtonGo;
    [SerializeField]private PlayerSaveScriptableObj playerSO;

    private void Awake() {
        animatorController = GetComponent<Animator>();
        ButtonGo.gameObject.SetActive(false);
    }
    public void Go(){
        ButtonGo.gameObject.SetActive(false);
        animatorController.SetTrigger(IS_INSERT);
        playerSO.level = 1;
        Debug.Log(playerSO.level);
    }
    public void firstLoop(){
        animatorController.SetTrigger(HAS_FIRST);
        ButtonGo.gameObject.SetActive(true);
        ButtonGo.GetComponent<CanvasGroup>().alpha = 0;
        ButtonGo.GetComponent<CanvasGroup>().LeanAlpha(1, 0.5f);
    }

}
