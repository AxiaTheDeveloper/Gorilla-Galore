using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;//buat loncat
    [SerializeField]GameInput gameInput;
    private float keyInputX;
    
    
    

    [Header("This is for Player Movement")]
    private float speedPlayer; 
    private Vector3 arahGerak = new Vector3(0,0,0);
    private bool isJalan; //tugas utama animasi Jalan

    [Header("This is for Player Jump")]
    [SerializeField]private LayerMask layerGround;
    [SerializeField]private LayerMask layerLadder;
    // private bool isOnGround;
    [SerializeField]private int saveTotalJump;
    private float jumpForce;
    private Vector2 loncatVector = new Vector2(0,1);
    private const float JUMP_MULTIPLIER = 100;
    private const string DARATAN_TAG = "Daratan";
    private Collider2D coll;
    
    private int totalJump;

    [Header("This is for Player Hurt")]
    
    [SerializeField]private GotHit hit;
    [SerializeField]private PlayerIdentity playerIdentity;
    private bool isHurt, isInvis, wasInvis;
    

    [Header("This is for Player Climb")]
    [SerializeField]private float climbSpeed;
    private bool canClimb, isClimb;
    private Collider2D[] results;
    private const string LAYER_TAG_GROUND = "Ground";
    private const string LAYER_TAG_LADDER = "Ladder";
    private const string LADDER_TAG = "Ladder";
    private GameObject ladder;
    private float keyInputY;
    private Vector3 arahGerakLadder = new Vector3(0,0,0);
    private float gravityScaleTemp;
    
    public event EventHandler OnClimb, OnNotClimb, OnClimbMove, OnClimbNotMove;

    [Header("This is for Cinematic")]
    private bool isMasukCinematicPertama;

    
    
    // [SerializeField]
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponentInChildren<Collider2D>();

        results = new Collider2D[4];
    }
    private void Start() {
        rb.isKinematic = false;
        isJalan = false;
        // isOnGround = false;
        isHurt = false;
        canClimb = false;
        isClimb = false;
        isInvis = false;
        wasInvis = false;
        isMasukCinematicPertama = true;
        gravityScaleTemp = rb.gravityScale;
        totalJump = saveTotalJump;
    }
    private void Update() {
        if(DKGameManager.Instance.IsGameStart()){
            
            if(!isHurt){
                if(!isClimb){
                    PlayerWalk();
                    PlayerJump();
                }
                if(canClimb){
                    PlayerClimb();
                }
            }
            else if(isHurt){
                if(Mathf.Abs(rb.velocity.x) < 0.1f){
                    isHurt = false;
                    
                }
            }
        }
        else if(DKGameManager.Instance.IsGameCinematic()){
            if(isMasukCinematicPertama){
                keyInputX = 0;
                isJalan = false;
                OnNotClimb?.Invoke(this,EventArgs.Empty);
                //jalanin metod cinematicnya
            }
        }
        if(wasInvis){
            playerIdentity.OnSpriteRenderer();
            wasInvis = false;
        }
        
        
    }
    private void PlayerWalk(){
        keyInputX = gameInput.GetInputMovementX();
        arahGerak.Set(keyInputX, 0f, 0f);
        isJalan = (arahGerak != Vector3.zero);
        transform.position += (arahGerak * speedPlayer * Time.deltaTime);
    }
    private void PlayerJump(){
        if(gameInput.GetInputJump() && totalJump > 0){
            // isOnGround = false;
            totalJump -= 1;
            // Debug.Log(totalJump);
            rb.AddForce(loncatVector * jumpForce * JUMP_MULTIPLIER);
        }
        
    }

    public void ResetJump(){
        totalJump = saveTotalJump;
    }

    private void PlayerClimb(){

        keyInputY = gameInput.GetInputMovementY();
        arahGerakLadder.Set(0f,keyInputY,0f);
        // Debug.Log(keyInputY);
        if(canClimb && keyInputY != 0){
            isClimb = true;
            OnClimb?.Invoke(this,EventArgs.Empty);
            isJalan = false;
        }
    }

    private void FixedUpdate() {
        if(isClimb){
            // gravityScaleTemp = rb.gravityScale;
            // CheckCollision();
            rb.gravityScale = 0f;
            transform.position = new Vector3(ladder.transform.position.x,rb.position.y);

            rb.velocity = new Vector2(rb.velocity.x,keyInputY * climbSpeed);
            transform.position += (arahGerakLadder * climbSpeed * Time.deltaTime);
            Collider2D tileLadder = ladder.GetComponent<LadderTileController>().GetTileCollider(); 
            if(tileLadder){
                Physics2D.IgnoreCollision(coll, tileLadder, true);
            }
            // Debug.Log(keyInputY);
            if(keyInputY == 0){
                
                OnClimbNotMove?.Invoke(this,EventArgs.Empty);
            }
            else{
                OnClimbMove?.Invoke(this,EventArgs.Empty);
            }
            
        }
        else{
            rb.gravityScale = gravityScaleTemp;
            
        }
    }
    

    
    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag(DARATAN_TAG)){
    //         // isOnGround = true;
    //     }
    // }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(LADDER_TAG)){
            // Debug.Log("hm?" + other.gameObject + "weee");
            ladder = other.gameObject;
            
            canClimb = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(LADDER_TAG)){
            // Debug.Log("hm?" + other.gameObject);
            if(ladder){
                Collider2D tileLadder = ladder.GetComponent<LadderTileController>().GetTileCollider(); 
                if(tileLadder){
                    Physics2D.IgnoreCollision(coll, tileLadder, false);
                }
                
                ladder = null;
                isClimb = false;
                canClimb = false;
                OnNotClimb?.Invoke(this,EventArgs.Empty);
            }
            
        }
    }
    

    public float GetKeyInputX(){
        return keyInputX;
    }
    public void SetCollider2D(Collider2D collChange){
        coll = collChange;
    }

    public void SetPlayerSpeed(float playerSpeed){
        speedPlayer = playerSpeed;
    }
    public void SetPlayerJumpForce(float forceJump){
        jumpForce = forceJump;
    }
    public bool GetIsJalan(){
        return isJalan;
    }

    //gothurt
    public bool GetIsHurt(){
        return isHurt;
    }
    public void GotHurt(float hurtForce){
        isHurt = true;
        // isInvis = true;
        // foreach (Transform obs in obsPool.Obstacles){
        //     Physics2D.IgnoreCollision(coll, obs.GetComponent<Collider2D>(), true);
        //     Debug.Log(obs);
        // }
        Physics2D.IgnoreLayerCollision(8, 9, true);
        isInvis = true;
        if(playerIdentity.GetPlayerHealth()>0){
            hit.changeBlink();
        }
        
        
        
        rb.velocity = new Vector2(hurtForce, rb.velocity.y);
    }

    //climb
    public bool GetIsClimb(){
        return isClimb;
    }
    public void canGetHit(){
        // foreach (Transform obs in obsPool.Obstacles){
        //     Physics2D.IgnoreCollision(coll, obs.GetComponent<Collider2D>(), false);
        //     Debug.Log(obs);
        // }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        
        isInvis = false;
        wasInvis = true;
    }



    public bool GetIsInvis(){
        return isInvis;
    }
    
}
