using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXBG : MonoBehaviour
{
    [SerializeField]private GameObject SFXBGIMAGE;
    private CanvasGroup canvas;
    private void Awake(){
        canvas = SFXBGIMAGE.GetComponent<CanvasGroup>();
    }
    void Start()
    {
        show();
    }

    public void show(){
        SFXBGIMAGE.SetActive(true);
        canvas.alpha = 0;
        canvas.LeanAlpha(1, 0.2f);

    }
}
