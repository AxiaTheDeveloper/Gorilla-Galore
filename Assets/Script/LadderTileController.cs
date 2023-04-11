using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTileController : MonoBehaviour
{
    [SerializeField]private GameObject tileCollider;
    public Collider2D GetTileCollider(){
        return tileCollider.GetComponent<Collider2D>();
    }
}
