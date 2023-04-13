using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIdentity : MonoBehaviour
{
    [SerializeField]private GameInput gameInput;

    [SerializeField]private int playerHealthTotal;
    private int playerHealth;
    private int playerScore;
    
    //ntr ini benerin la
    public enum PlayerName{
        As, Bs, Cs, Ds
    }
    private PlayerName names;




    [SerializeField]private GameObject Player1,Player2, Player3, Player4;
    [SerializeField]private PlayerMovement playerMove;
    [SerializeField]private float changeCooldownTimer;
    private bool canChange, isAttack;
    private SpriteRenderer sprite;
    private Color spriteColor;
    

    [Header("Player1 Identity1")]
    [SerializeField]private float speedPlayer1;
    [SerializeField]private float jumpForce1;
    
    [Header("Player1 Identity2")]
    [SerializeField]private float speedPlayer2;
    [SerializeField]private float jumpForce2;
    [Header("Player1 Identity3")]
    [SerializeField]private float speedPlayer3;
    [SerializeField]private float jumpForce3;
    [Header("Player1 Identity4")]
    [SerializeField]private float speedPlayer4;
    [SerializeField]private float jumpForce4;

    //event

    public event EventHandler<OnChangeHealthEventArgs> OnChangeHealth;
    
    public class OnChangeHealthEventArgs : EventArgs{
        public float playerHealthNormalized;
        public float playerHealth;
    }

    public event EventHandler<OnChangeScoreEventArgs> OnChangeScore;
    
    public class OnChangeScoreEventArgs : EventArgs{
        public int playerScore;
    }
    
    private void Start() {
        playerScore = 0;
        playerHealth = playerHealthTotal;

        names = PlayerName.As;
        Player1.SetActive(true);
        Player2.SetActive(false);
        Player3.SetActive(false);
        Player4.SetActive(false);
        
        SetIdentity(Player1,speedPlayer1,jumpForce1);
        isAttack = false;
        canChange = true;
    }
    private void Update() {
        //ntr br kasih syarat
        if(!playerMove.GetIsHurt() && DKGameManager.Instance.IsGameStart() && !isAttack && !playerMove.GetIsClimb()){
            changeCharacter();
        }
        
        
    }
    private void changeCharacter(){
        if(canChange){
            //buat ini ntr diakses lwt save file di scriptable aja
            if(gameInput.GetInputChangePlayer1() && !Player1.activeSelf){
                SetIdentity(Player1,speedPlayer1,jumpForce1);
                names = PlayerName.As;
                Player1.SetActive(true);
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(false);
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer2() && !Player2.activeSelf){
                SetIdentity(Player2,speedPlayer2,jumpForce2);
                names = PlayerName.Bs;
                Player1.SetActive(false);
                Player2.SetActive(true);
                Player3.SetActive(false);
                Player4.SetActive(false);
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer3() && !Player3.activeSelf){
                SetIdentity(Player3,speedPlayer3,jumpForce3);
                names = PlayerName.Cs;
                Player1.SetActive(false);
                Player2.SetActive(false);
                Player3.SetActive(true);
                Player4.SetActive(false);
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer4() && !Player4.activeSelf){
                SetIdentity(Player4,speedPlayer4,jumpForce4);
                names = PlayerName.Ds;
                Player1.SetActive(false);
                Player2.SetActive(false);
                Player3.SetActive(false);
                Player4.SetActive(true);
                resetCooldown();
            }
            
        }   
    }

    private void SetIdentity(GameObject player, float speed, float forceJump){
        playerMove.SetCollider2D(player.GetComponent<Collider2D>());
        playerMove.SetPlayerJumpForce(forceJump);
        playerMove.SetPlayerSpeed(speed);
        sprite = player.GetComponentInChildren<SpriteRenderer>();
        spriteColor = sprite.color;
        spriteColor.a = 1f; 
        sprite.color = spriteColor;
    }

    private void resetCooldown(){
        canChange = false;
        
        StartCoroutine(ChangeCooldown());
    }
    private IEnumerator ChangeCooldown(){
        yield return new WaitForSeconds(changeCooldownTimer);
        canChange = true;
        
    }

    public void changePlayerHealth(int health){
        playerHealth += health;
        // Debug.Log(playerHealth);
        if(playerHealth <= 0){
            playerHealth = 0;
            DKGameManager.Instance.setGameOver(false);
            //tp ini harusnya dinyalain stlh animasi slsai sih

            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //play death ui after animation, or both idk lmao, trus reset button
        }
        OnChangeHealth?.Invoke(this, new OnChangeHealthEventArgs{
            playerHealthNormalized = (float)playerHealth / playerHealthTotal,
            playerHealth = playerHealth
        });
    }
    public void changeScore(int score){
        playerScore += score;
        // Debug.Log(playerScore);
        OnChangeScore?.Invoke(this, new OnChangeScoreEventArgs{
            playerScore = playerScore
        });
    }

    public PlayerName GetName(){
        return names;
    }
    public void IsAttacking(bool change){
        isAttack = change;
    }
    public void ChangeSpriteRenderer(float change){
        spriteColor.a = change; 
        sprite.color = spriteColor;
    }

    // public int GetPlayerHealth(){
    //     return playerHealth;
    // }
    public int GetPlayerHealthTotal(){
        return playerHealthTotal;
    }
    // public int GetPlayerScore(){
    //     return playerScore;
    // }
}
