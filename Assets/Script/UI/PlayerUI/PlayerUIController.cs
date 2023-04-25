using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    private CanvasGroup canvas;
    [SerializeField]private DKGameManager gameManager;

    private void Awake(){
        canvas = GetComponent<CanvasGroup>();
    }

    private void Start() {
        hide();
        gameManager.OnStartGame += gameManager_OnStartGame;
        gameManager.OnCinematicGame += gameManager_OnCinematicGame;
    }
    private void gameManager_OnStartGame(object sender, System.EventArgs e){
        show(); 
    }
    private void gameManager_OnCinematicGame(object sender, System.EventArgs e){
        hideCinematic();
    }

    private void show(){
        gameObject.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.2f);
    }
    private void hide(){
        gameObject.SetActive(false);
    }
    private void hideCinematic(){
        canvas.alpha = 1;
        canvas.LeanAlpha(0, 0.2f);
        gameObject.SetActive(false);
    }
}
