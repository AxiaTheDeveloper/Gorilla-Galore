using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI judulLevelPlay;
    [SerializeField]private GameObject credits, reset;

    [SerializeField]private Button PlayButton, CreditsButton, QuitButton, ResetButton;
    [SerializeField]private PlayerSaveScriptableObj playerSO;
    private const string LEVELSTART_TEXT = "- Milo -";
    private const string LEVEL_ONE_TEXT = "- Betty -";
    private const string LEVEL_TWO_TEXT = "- Mom -";
    private const string LEVEL_THREE_TEXT = "- Dad -";
    private const string LEVEL_FINAL_TEXT = "- Gort -";
    private int levelNow;
    [SerializeField]private BackgroundHouse BG;

    private void Awake() {
        levelNow = playerSO.level;
        PlayButton.onClick.AddListener(() => {
            if(levelNow == 0){
                LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.MiloLevel); 
            }
            else if(levelNow == 1){
                LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.BettyLevel); 
            }
            else if(levelNow == 2){
                LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.MomLevel); 
            }
            else if(levelNow == 3){
                LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.DadLevel); 
            }
            else if(levelNow == 4){
                LoadingScreenScene.LoadScene(LoadingScreenScene.Scene.GortLevel); 
            }
        });
        CreditsButton.onClick.AddListener(() => {
            credits.SetActive(true);
        });
        QuitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        ResetButton.onClick.AddListener(() => {
            reset.SetActive(true);
        });
    }
    private void Start() {
        credits.SetActive(false);
        reset.SetActive(false);
        if(levelNow == 0){
            judulLevelPlay.text = LEVELSTART_TEXT;
        }
        else if(levelNow == 1){
            judulLevelPlay.text = LEVEL_ONE_TEXT;
        }
        else if(levelNow == 2){
            judulLevelPlay.text = LEVEL_TWO_TEXT;
        }
        else if(levelNow == 3){
            judulLevelPlay.text = LEVEL_THREE_TEXT;
        }
        else if(levelNow == 4){
            judulLevelPlay.text = LEVEL_FINAL_TEXT;
        }
        
    }
    private void ResetSave(){
        levelNow = playerSO.level;
        if(levelNow == 0){
            judulLevelPlay.text = LEVELSTART_TEXT;
        }
        else if(levelNow == 1){
            judulLevelPlay.text = LEVEL_ONE_TEXT;
        }
        else if(levelNow == 2){
            judulLevelPlay.text = LEVEL_TWO_TEXT;
        }
        else if(levelNow == 3){
            judulLevelPlay.text = LEVEL_THREE_TEXT;
        }
        else if(levelNow == 4){
            judulLevelPlay.text = LEVEL_FINAL_TEXT;
        }
    }

    public void Reset(){
        playerSO.level = 0;
        playerSO.baruSajaSelesaiGame = false;
        BG.UpdateBG();
        ResetSave();
    }



}
