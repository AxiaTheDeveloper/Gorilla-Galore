using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    
    private float keyInputX, keyInputY;
    private bool inputJump, inputChangePlayer1, inputChangePlayer2, inputChangePlayer3, inputChangePlayer4, inputInteract, inputMovementY, inputContinueUI;
    private void Awake() {
        Instance = this;
    }
    
    public float GetInputMovementX(){
        keyInputX = 0;

        if(Input.GetKey(KeyCode.D)) keyInputX = 1;
        if(Input.GetKey(KeyCode.A)) keyInputX = -1;
        
        return keyInputX;
    }

    public float GetInputMovementY(){
        keyInputY = 0;

        if(Input.GetKey(KeyCode.W)) keyInputY = 1;
        if(Input.GetKey(KeyCode.S)) keyInputY = -1;
        
        return keyInputY;
    }
    public bool GetBoolInputMovementY(){
        inputMovementY = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S);
        
        return inputMovementY;
    }
    public bool GetInputJump(){
        inputJump = Input.GetKeyDown(KeyCode.Space);
        
        return inputJump;
    }
    public bool GetInputContinueUI(){
        inputContinueUI = Input.GetKeyDown(KeyCode.Space);
        
        return inputContinueUI;
    }

    public bool GetInputInteract(){
        inputInteract = Input.GetKeyDown(KeyCode.F);
        
        return inputInteract;
    }

    //change chara
    public bool GetInputChangePlayer1(){
        inputChangePlayer1 = Input.GetKeyDown(KeyCode.I);
        return inputChangePlayer1;
    }
    public bool GetInputChangePlayer2(){
        inputChangePlayer2 = Input.GetKeyDown(KeyCode.J);
        return inputChangePlayer2;
    }
    public bool GetInputChangePlayer3(){
        inputChangePlayer3 = Input.GetKeyDown(KeyCode.K);
        return inputChangePlayer3;
    }
    public bool GetInputChangePlayer4(){
        inputChangePlayer4 = Input.GetKeyDown(KeyCode.L);
        return inputChangePlayer4;
    }
    

    
}
