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
    

    public enum PlayerName{
        Milo, Betty, Mom, Dad
    }
    private PlayerName names;




    [SerializeField]private GameObject Player1,Player2, Player3, Player4;
    [SerializeField]private PlayerMovement playerMove;
    [SerializeField]private float changeCooldownTimer;
    private bool canChange, isAttack;
    private SpriteRenderer sprite;
    // private Color spriteColor;
    [SerializeField]private PlayerAccessSave playerSave;
    private int levelNow;
    

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
    public event EventHandler OnDeath;

    public event EventHandler<OnChangeHealthEventArgs> OnChangeHealth;
    
    public class OnChangeHealthEventArgs : EventArgs{
        public float playerHealthNormalized;
        public float playerHealth;
    }

    public event EventHandler<OnChangeScoreEventArgs> OnChangeScore;
    
    public class OnChangeScoreEventArgs : EventArgs{
        public int playerScore;
    }

    public event EventHandler<OnChangePlayerEventArgs> OnChangePlayer;
    
    public class OnChangePlayerEventArgs : EventArgs{
        public int names;
    }
    [SerializeField]private PlayerInteraction playerInteract;
    
    private void Start() {
        playerScore = 0;
        playerHealth = playerHealthTotal;
        levelNow = playerSave.GetLevelNow();
        names = PlayerName.Milo;
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
            // Debug.Log(levelNow);
            Debug.Log(Player1.activeSelf);
                Debug.Log(Player2.activeSelf);
                Debug.Log(Player3.activeSelf);
                Debug.Log(Player4.activeSelf);
            if(gameInput.GetInputChangePlayer1() && !Player1.activeSelf && !playerInteract.GetisOnMoving()){
                OnChangePlayer?.Invoke(this, new OnChangePlayerEventArgs{
                    names = 0
                });
                SetIdentity(Player1,speedPlayer1,jumpForce1);
                names = PlayerName.Milo;
                
                Player1.SetActive(true);
                if(Player2.activeSelf){
                    Player2.SetActive(false);
                }
                if(Player3.activeSelf){
                    Player3.SetActive(false);
                }
                if(Player4.activeSelf){
                    Player4.SetActive(false);
                }
                
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer2() && !Player2.activeSelf && levelNow > 1 && !playerInteract.GetisOnMoving()){
                OnChangePlayer?.Invoke(this, new OnChangePlayerEventArgs{
                    names = 1
                });
                SetIdentity(Player2,speedPlayer2,jumpForce2);
                names = PlayerName.Betty;
                if(Player1.activeSelf){
                    Player1.SetActive(false);
                }
                
                Player2.SetActive(true);
                if(Player3.activeSelf){
                    Player3.SetActive(false);
                }
                if(Player4.activeSelf){
                    Player4.SetActive(false);
                }
                
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer3() && !Player3.activeSelf && levelNow > 2 && !playerInteract.GetisOnMoving()){
                OnChangePlayer?.Invoke(this, new OnChangePlayerEventArgs{
                    names = 2
                });
                SetIdentity(Player3,speedPlayer3,jumpForce3);
                names = PlayerName.Mom;
                if(Player1.activeSelf){
                    Player1.SetActive(false);
                }
                if(Player2.activeSelf){
                    Player2.SetActive(false);
                }
                
                Player3.SetActive(true);
                if(Player4.activeSelf){
                    Player4.SetActive(false);
                }
                resetCooldown();
            }
            else if(gameInput.GetInputChangePlayer4() && !Player4.activeSelf && levelNow > 3 && !playerInteract.GetisOnMoving()){
                OnChangePlayer?.Invoke(this, new OnChangePlayerEventArgs{
                    names = 3
                });
                SetIdentity(Player4,speedPlayer4,jumpForce4);
                names = PlayerName.Dad;
                
                if(Player1.activeSelf){
                    Player1.SetActive(false);
                }
                if(Player2.activeSelf){
                    Player2.SetActive(false);
                }
                if(Player3.activeSelf){
                    Player3.SetActive(false);
                }
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
            OnDeath?.Invoke(this,EventArgs.Empty);
            DKGameManager.Instance.setGameOver(false);
            //URUSI KEMATIANNNNNNN
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
    public void OnSpriteRenderer(){
        sprite.enabled = true;
    }
    public SpriteRenderer GetSprite(){
        return sprite;
    }

    public int GetPlayerHealth(){
        return playerHealth;
    }
    public int GetPlayerHealthTotal(){
        return playerHealthTotal;
    }
    public int GetPlayerScore(){
        return playerScore;
    }

}
