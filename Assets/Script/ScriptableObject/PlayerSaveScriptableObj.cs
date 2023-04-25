using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerSaveScriptableObj : ScriptableObject
{
    public int level;
    public bool alreadyPlayed;
    public bool baruSajaSelesaiGame;
    public int[] score;
}


