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
    private bool isOnGround;

    
    // [SerializeField]
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponentInChildren<Collider2D>();
    }
    private void Start() {
        isJalan = false;
        isOnGround = false;
    }
    private void Update() {
        PlayerWalk();
        PlayerJump();
    }
    private void PlayerWalk(){
        keyInputX = gameInput.GetInputMovementX();
        arahGerak.Set(keyInputX, 0f, 0f);
        isJalan = (arahGerak != Vector3.zero);
        transform.position += (arahGerak * speedPlayer * Time.deltaTime);
    }
    private void PlayerJump(){
        if(gameInput.GetInputJump() && coll.IsTouchingLayers(layerGround)){
            isOnGround = false;
            rb.AddForce(loncatVector * jumpForce * JUMP_MULTIPLIER);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(DARATAN_TAG)){
            isOnGround = true;
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
    
}
