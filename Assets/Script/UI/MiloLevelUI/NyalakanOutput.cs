using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyalakanOutput : MonoBehaviour
{
    [SerializeField]private GameObject output;
    void Start()
    {
        output.gameObject.SetActive(true);
    }


}
