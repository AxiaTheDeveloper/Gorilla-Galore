using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private int damage;
    [SerializeField]private float hurtForce;
    private const string DESTROYER_TAG = "PlayerAttack";
    private const string FINAL_GROUND_TAG = "FinalGround";
    private const string LAYER_MASK_NAME = "Ground";
    [SerializeField]private float speedObstacle;
    private float saveSpeed;
    private int changeDirection = 1;
    private bool firstHitGround;

    private Rigidbody2D rb;
    private enum NamaDamageObject{
        Bone, Book, Paper, Bomb
    }
    [SerializeField]private NamaDamageObject nama;
    [SerializeField]private int scorePoint;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        saveSpeed = speedObstacle;
        DKGameManager.Instance.OnStopGame += gameManager_OnStopGame;
        DKGameManager.Instance.OnStartGame += gameManager_OnStartGame;

    }
    private void gameManager_OnStopGame(object sender, System.EventArgs e){
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void gameManager_OnStartGame(object sender, System.EventArgs e){

        rb.constraints = RigidbodyConstraints2D.None;
    }
    

    public int GetDamage(){
        return damage;
    }
    public float GetHurtForce(){
        return hurtForce;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(DESTROYER_TAG)){
            
            PlayerAttack cek = other.gameObject.GetComponentInParent<PlayerAttack>();
            if(cek.GetName() == PlayerAttack.PlayerName.Betty && nama == NamaDamageObject.Bone){
                Debug.Log("Test");
                other.gameObject.GetComponentInParent<PlayerIdentity>().changeScore(scorePoint);
                this.gameObject.SetActive(false);
            }
            if(cek.GetName() == PlayerAttack.PlayerName.Mom && nama == NamaDamageObject.Book){
                
                
                other.gameObject.GetComponentInParent<PlayerIdentity>().changeScore(scorePoint);
                this.gameObject.SetActive(false);
            }
            if(cek.GetName() == PlayerAttack.PlayerName.Dad && nama == NamaDamageObject.Paper){
                other.gameObject.GetComponentInParent<PlayerIdentity>().changeScore(scorePoint);
                this.gameObject.SetActive(false);
                
                
            }
            if(cek.GetName() == PlayerAttack.PlayerName.Dad && nama == NamaDamageObject.Bomb){
                other.gameObject.GetComponentInParent<PlayerIdentity>().changeScore(scorePoint);
                this.gameObject.SetActive(false);
                
            }
            
        }
        else if(other.gameObject.CompareTag(FINAL_GROUND_TAG)){
            this.gameObject.SetActive(false);
        }
        
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.layer == LayerMask.NameToLayer(LAYER_MASK_NAME)){
    //         // int changeDirection = Random.Range(0,2) == 0 ? -1 : 1;
    //         Debug.Log(other.gameObject);
    //         Debug.Log(changeDirection);
    //         if(other.gameObject.GetComponent<PlatformChangeDirection>() == null){
    //             Debug.Log("pew pew pew");
    //             rb.velocity = Vector2.zero;
    //             rb.AddForce(other.transform.right * speedObstacle * changeDirection, ForceMode2D.Impulse);
    //         }
            
            
    //     }
    // }
    public void ChangeDirection(int change){
        changeDirection = change;
    }
    public void AddSpeed(float change){
        speedObstacle += change;
        if(change == 0 && speedObstacle != saveSpeed){
            speedObstacle = saveSpeed;
        }
    }
    public void Go(GameObject ground){
        rb.velocity = Vector2.zero;
        rb.AddForce(ground.transform.right * speedObstacle * changeDirection, ForceMode2D.Impulse);
    }
    
}
