using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathUI : MonoBehaviour
{
    private const string YOU_DIE_TEXT = "Y O U   D I E D";
    private const string TIMES_UP_TEXT = "T I M E ' S    U P";
    [SerializeField]private DKGameManager gameManager;
    [SerializeField]private TextMeshProUGUI judulGameOver;

    [SerializeField]private Button restartButton, mainmenuButton;
    
    private int level;

    private CanvasGroup canvas;

    private void Awake() {
        canvas = GetComponent<CanvasGroup>();

        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        mainmenuButton.onClick.AddListener(() => {
            // LoadingScreenScene.Load(LoadingScreenScene.Scene.MainGame);
            //masih nanti tunggu nama scene..
        });
    }
    private void Start() {
        level = gameManager.GetLevel();
        hide();
        gameManager.OnStopDie += gameManager_OnStopDie;
        gameManager.OnStopTimeUp += gameManager_OnStopTimeUp;
    }
    private void gameManager_OnStopDie(object sender, System.EventArgs e){
        
        judulGameOver.text = YOU_DIE_TEXT;
        show();
    }
    private void gameManager_OnStopTimeUp(object sender, System.EventArgs e){
        judulGameOver.text = TIMES_UP_TEXT;
        show();
    }

    private void show(){
        gameObject.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.5f);
    }
    private void hide(){
        gameObject.SetActive(false);
    }
}
