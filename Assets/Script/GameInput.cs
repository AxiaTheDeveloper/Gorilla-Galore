using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    
    private float keyInputX;
    private bool inputJump, inputChangePlayer1, inputChangePlayer2, inputChangePlayer3;
    
    public float GetInputMovementX(){
        keyInputX = 0;

        if(Input.GetKey(KeyCode.D)) keyInputX = 1;
        if(Input.GetKey(KeyCode.A)) keyInputX = -1;
        
        return keyInputX;
    }
    public bool GetInputJump(){
        inputJump = Input.GetKeyDown(KeyCode.Space);
        
        return inputJump;
    }

    //change chara
    public bool GetInputChangePlayer1(){
        inputChangePlayer1 = Input.GetKeyDown(KeyCode.J);
        return inputChangePlayer1;
    }
    public bool GetInputChangePlayer2(){
        inputChangePlayer2 = Input.GetKeyDown(KeyCode.K);
        return inputChangePlayer2;
    }
    public bool GetInputChangePlayer3(){
        inputChangePlayer3 = Input.GetKeyDown(KeyCode.L);
        return inputChangePlayer3;
    }
    

    
}
