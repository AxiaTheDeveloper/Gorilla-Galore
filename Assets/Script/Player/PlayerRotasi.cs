using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotasi : MonoBehaviour
{
    [SerializeField]PlayerMovement playerMovement;
    private float arahHadap;
    void Update()
    {
        PlayerHadap();
    }
    private void PlayerHadap(){
        arahHadap = playerMovement.GetKeyInputX();
        if(arahHadap == 1){
            transform.localScale = new Vector2(1,1);
        }
        else if(arahHadap == -1){
            transform.localScale = new Vector2(-1,1);
        }
    }
}
