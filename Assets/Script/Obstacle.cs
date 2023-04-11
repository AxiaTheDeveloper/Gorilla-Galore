using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private int damage;
    [SerializeField]private float hurtForce;
    private const string DESTROYER_TAG = "PlayerAttack";
    private const string FINAL_GROUND_TAG = "FinalGround";
    private enum NamaDamageObject{
        Bone, Book, Paper, Bomb
    }
    [SerializeField]private NamaDamageObject nama;

    public int GetDamage(){
        return damage;
    }
    public float GetHurtForce(){
        return hurtForce;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(DESTROYER_TAG)){
            PlayerAttack cek = other.gameObject.GetComponentInParent<PlayerAttack>();
            if(cek.GetName() == PlayerAttack.PlayerName.Bs && nama == NamaDamageObject.Bone){
                Destroy(this.gameObject);
            }
            if(cek.GetName() == PlayerAttack.PlayerName.Cs && nama == NamaDamageObject.Paper){
                Destroy(this.gameObject);
            }
            
        }
        else if(other.gameObject.CompareTag(FINAL_GROUND_TAG)){
            Destroy(this.gameObject,0.2f);
        }
        
    }
}
