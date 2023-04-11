using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float jumpForce;
    private Vector2 loncatVector = new Vector2(0,1);
    private const float JUMP_MULTIPLIER = 100;
    private const string DARATAN_TAG = "Daratan";
    private Collider2D coll;
    [SerializeField]private LayerMask layerGround;
    [SerializeField]private LayerMask layerLadder;
    private bool isOnGround;

    [Header("This is for Player Hurt")]
    private bool isHurt;

    [Header("This is for Player Hurt")]
    private bool canClimb, isClimb;
    private Collider2D[] results;
    private const string LAYER_TAG_GROUND = "Ground";
    private const string LAYER_TAG_LADDER = "Ladder";
    private const string LADDER_TAG = "Ladder";
    private GameObject ladder;
    private float keyInputY;
    private Vector3 arahGerakLadder = new Vector3(0,0,0);
    private float gravityScaleTemp;
    [SerializeField]private float climbSpeed;


    
    // [SerializeField]
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponentInChildren<Collider2D>();

        results = new Collider2D[4];
    }
    private void Start() {
        isJalan = false;
        isOnGround = false;
        isHurt = false;
        canClimb = false;
        isClimb = false;
        gravityScaleTemp = rb.gravityScale;
    }
    private void Update() {
        if(DKGameManager.Instance.IsGameStart()){
            // CheckCollision();
            // if(coll.IsTouchingLayers(layerLadder)){
            //     canClimb = true;
            // }
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
        
        
    }
    private void PlayerWalk(){
        keyInputX = gameInput.GetInputMovementX();
        arahGerak.Set(keyInputX, 0f, 0f);
        isJalan = (arahGerak != Vector3.zero);
        transform.position += (arahGerak * speedPlayer * Time.deltaTime);
    }
    private void PlayerJump(){
        if(gameInput.GetInputJump() && coll.IsTouchingLayers(layerGround)){
            // isOnGround = false;
            rb.AddForce(loncatVector * jumpForce * JUMP_MULTIPLIER);
        }
    }

    private void PlayerClimb(){

        keyInputY = gameInput.GetInputMovementY();
        arahGerakLadder.Set(0f,keyInputY,0f);
        // Debug.Log(keyInputY);
        if(canClimb && keyInputY != 0){
            isClimb = true;
            
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
            Physics2D.IgnoreCollision(coll, tileLadder, true);
        }
        else{
            rb.gravityScale = gravityScaleTemp;
            
        }
    }
    
    private void CheckCollision(){
        Vector2 size = coll.bounds.size;
        size.y += 0.1f;
        size.x /= 2f;
        int amountOverlap = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);
        for(int i=0;i<amountOverlap;i++){
            GameObject hit = results[i].gameObject;
            if(hit.layer == LayerMask.NameToLayer(LAYER_TAG_GROUND)){
                Debug.Log(hit.gameObject);
                if(hit.transform.position.y < (transform.position.y- 0.5f)){
                    Physics2D.IgnoreCollision(coll, results[i]);
                    // break;
                }
                // Debug.Log(hit.transform.position.y);
                // Debug.Log("A" + transform.position.y);
                // Debug.Log(isOnGround);
                
            }
            

        }

        // for(int i=0;i<amountOverlap;i++){
        //     Physics2D.IgnoreCollision(coll, results[i], isOnGround);
        // }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(DARATAN_TAG)){
            // isOnGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(LADDER_TAG)){
            ladder = other.gameObject;
            
            canClimb = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(LADDER_TAG)){
            Collider2D tileLadder = ladder.GetComponent<LadderTileController>().GetTileCollider(); 
            Physics2D.IgnoreCollision(coll, tileLadder, false);
            ladder = null;
            isClimb = false;
            canClimb = false;
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

    //gothurt
    public bool GetIsHurt(){
        return isHurt;
    }
    public void GotHurt(float hurtForce){
        isHurt = true;
        rb.velocity = new Vector2(hurtForce, rb.velocity.y);
    }
    
}
