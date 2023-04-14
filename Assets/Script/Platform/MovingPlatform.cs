using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]private Transform position1, position2;
    [SerializeField]private float speedPlatform, timerIdleTotal;
    private float timerIdle;
    private Transform tujuan;
    private const string PLAYER_TAG = "Player";

    
    private void Start() {
        tujuan = position1;

        timerIdle = timerIdleTotal;
    }


    private void Update() {
        if(DKGameManager.Instance.IsGameStart()){
            if(transform.position == position1.position){
                timerIdle -= Time.deltaTime;
                if(timerIdle <= 0){
                    timerIdle = timerIdleTotal;
                    tujuan = position2;
                }
            
            }
            else if(transform.position == position2.position){
                timerIdle -= Time.deltaTime;
                if(timerIdle <= 0){
                    timerIdle = timerIdleTotal;
                    tujuan = position1;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, tujuan.position, speedPlatform * Time.deltaTime);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)){
            
            if(transform.position.y < other.gameObject.transform.position.y){
                other.gameObject.transform.SetParent(transform);
            }

        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag(PLAYER_TAG)){
            other.gameObject.transform.SetParent(null);
        }
    }



}
