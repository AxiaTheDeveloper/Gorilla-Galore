using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DKGameManager : MonoBehaviour
{
    public static DKGameManager Instance {get; private set;}

    public enum Level{
        level1, level2, level3,level4
    }
    [SerializeField]private Level levelNow;

    private enum gameState{
        WaitingToStart, GameStart, GameOver, Cinematic
    }
    private gameState state;
    //Idk if we need countdown or not
    [SerializeField]private float countDownTimer, gamePlayTimerTotal;
    private float gamePlayTimer;
    private bool isGamePause;

    //event
    public event EventHandler OnStartGame, OnStopGame, OnCinematicGame;

    //UI
    [SerializeField]private StartUI startUI;
    public event EventHandler OnStopDie, OnStopTimeUp; // ini buat d death ui semua,onstop die berarti sii text isinya you died, kalo satunya ya time's up

    private bool isWin, doDelayStart;
    


    
    
    


    private void Awake() {
        Instance = this;
        state = gameState.WaitingToStart;
    }
    private void Start() {
        isWin = false;
        doDelayStart = true;
        gamePlayTimer = gamePlayTimerTotal;
        Time.timeScale = 1f;
        startUI.OnInteractStartGame += startUI_OnInteractStartGame;
    }
    private void startUI_OnInteractStartGame(object sender, System.EventArgs e){
        
        state = gameState.GameStart;
        gamePlayTimer = gamePlayTimerTotal;
        OnStartGame?.Invoke(this,EventArgs.Empty);
    }

    
    private void Update() {
        if(state == gameState.GameStart){
            if(doDelayStart){
                StartCoroutine(delayStart());
                doDelayStart = false;
            }
            else{
                gamePlayTimer -= Time.deltaTime;
                if(gamePlayTimer <= 0f){
                    state = gameState.GameOver;
                    
                }
            }
            
        }
        else if(state == gameState.GameOver){
            OnStopGame?.Invoke(this,EventArgs.Empty);
            if(isWin){
                state = gameState.Cinematic;
                OnCinematicGame?.Invoke(this,EventArgs.Empty);
            }
            else{
                if(gamePlayTimer > 0){
                    OnStopDie?.Invoke(this,EventArgs.Empty);
                }
                else{
                    OnStopTimeUp?.Invoke(this,EventArgs.Empty);
                }
            }
        
        }
        else if(state == gameState.Cinematic){
            //event nyalain cinematic
        }
    }

    public void setGameOver(bool win){
        state = gameState.GameOver;
        isWin = win;
    }
    // public void setCinematic(){
    //     state = gameState.Cinematic;
    // }

    public bool IsGameStart(){
        return state == gameState.GameStart;
    }
    public bool IsGameCinematic(){
        return state == gameState.Cinematic;
    }

    public void AddGameTime(float time){
        gamePlayTimer += time;
        // Debug.Log(gamePlayTimer);
    }
    public float GetGamePlayTimer(){
        return gamePlayTimer;
    }

    public void PauseGame(){
        isGamePause = !isGamePause;
        if(isGamePause){
            Time.timeScale = 1f;
            // OnGameUnPause?.Invoke(this,EventArgs.Empty);
        }
        else{
            Time.timeScale = 0f;
            
            // OnGamePause?.Invoke(this,EventArgs.Empty);
        }
        
    }

    public int GetLevel(){
        if(levelNow == Level.level1){
            return 1;
        }
        else if(levelNow == Level.level2){
            return 2;
        }
        else if(levelNow == Level.level3){
            return 3;
        }
        else if(levelNow == Level.level4){
            return 4;
        }
        return 0;
    }

    private IEnumerator delayStart(){
        yield return new WaitForSeconds(0.7f);
    }

}
