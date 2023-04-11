using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]private float addTime;
    [SerializeField]private int addHealth;

    public int GetAddHealth(){
        return addHealth;
    }
    public float GetAddTime(){
        return addTime;
    }
}
