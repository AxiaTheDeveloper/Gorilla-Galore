using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField]private RawImage raw;
    [SerializeField]private float x,y;
    private void Update() {
        if(raw.uvRect.x >= 0.9){
            raw.uvRect = new Rect(new Vector2(-0.315f,0), raw.uvRect.size);
        }
        raw.uvRect = new Rect(raw.uvRect.position + new Vector2(x,y) * Time.deltaTime, raw.uvRect.size);

    }
}
