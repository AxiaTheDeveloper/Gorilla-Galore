using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CekKerja : MonoBehaviour
{
    [SerializeField]private AudioBGM audioBGM;
    private void Start() {
        audioBGM.TurnOff();
    }
}
