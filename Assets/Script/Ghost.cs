using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ghost : MonoBehaviour
{
    public event EventHandler OnStartDialogue;

    public void start(){
        OnStartDialogue?.Invoke(this,EventArgs.Empty);
    }
}
