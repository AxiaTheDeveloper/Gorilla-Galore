using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DKGameManager : MonoBehaviour
{
    public static DKGameManager Instance {get; private set;}
    private enum gameState{
        WaitingToStart, CountDown, GameStart, GameOver, Cinematic
    }
    private gameState state;
    //Idk if we need countdown or not
    [SerializeField]private float countDownTimer, gamePlayTimerTotal;
    private float gamePlayTimer;

    //event
    public event EventHandler OnInteractStartGame, OnStartGame, OnStopGame;
    


    private void Awake() {
        Instance = this;
        state = gameState.WaitingToStart;
    }
    private void Start() {
        OnInteractStartGame += gameManager_OnInteractStartGame;
    }
    private void gameManager_OnInteractStartGame(object sender, System.EventArgs e){
        
        state = gameState.CountDown;
        
    }

    
    private void Update() {
        if(state == gameState.WaitingToStart){
            if(GameInput.Instance.GetInputInteract()){
                OnInteractStartGame?.Invoke(this,EventArgs.Empty);
            }
        }
        else if(state == gameState.CountDown){
            countDownTimer -= Time.deltaTime;
            if(countDownTimer <= 0f){
                state = gameState.GameStart;
                gamePlayTimer = gamePlayTimerTotal;
                OnStartGame?.Invoke(this,EventArgs.Empty);
            }
        }
        else if(state == gameState.GameStart){
            gamePlayTimer -= Time.deltaTime;
            if(gamePlayTimer <= 0f){
                state = gameState.GameOver;
                
            }
        }
        else if(state == gameState.GameOver){
            OnStopGame?.Invoke(this,EventArgs.Empty);
        }
    }

    public void setGameOver(){
        state = gameState.GameOver;
    }

    public bool IsGameStart(){
        return state == gameState.GameStart;
    }

    public void AddGameTime(float time){
        gamePlayTimer += time;
        Debug.Log(gamePlayTimer);
    }
}
