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

    [SerializeField]private CanvasGroup canvas;
    private const string BGM_GAME_OBJECT = "BGM";
    private void Awake() {
        // canvas = GetComponent<CanvasGroup>();

        restartButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        mainmenuButton.onClick.AddListener(() => {
            GameObject bgm = GameObject.Find(BGM_GAME_OBJECT);
            Destroy(bgm);
            LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.MainMenu);
            
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
        // Debug.Log("Test>?");
        show();
    }
    private void gameManager_OnStopTimeUp(object sender, System.EventArgs e){
        judulGameOver.text = TIMES_UP_TEXT;
        // Debug.Log("Test");
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
