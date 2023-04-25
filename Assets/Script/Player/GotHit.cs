using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHit : MonoBehaviour
{
    
    [SerializeField]private float totalblink;
    private float timerblink, blink, timertotalblink;
    private SpriteRenderer SR;

    
    // [SerializeField]private float invisTime;
    [SerializeField]private PlayerIdentity playerIdentity;
    [SerializeField]private PlayerMovement playerMovement;

    private bool mulaiBlink;
    private Collider2D coll;
    private void Awake() {
        // SR = GetComponentInParent<SpriteRenderer>();
        coll = GetComponentInChildren<Collider2D>();
    }
    private void Start() {
        timerblink = 0;
        blink = 0.1f;
        timertotalblink = 0;
        mulaiBlink = false;
    }

    public void changeBlink(){
        mulaiBlink = true;
        SR = playerIdentity.GetSprite();
        SR.enabled = true;
    }

    private void Update() {
        if(mulaiBlink){
            
            blinkTiem();
            
        }
    }

    void blinkTiem(){
        timertotalblink += Time.deltaTime;
        if(timertotalblink >= totalblink){
            mulaiBlink = false;
            timertotalblink = 0;
            SR.enabled = true;
            playerMovement.canGetHit();
            
        }

        timerblink += Time.deltaTime;
        if(timerblink >= blink){
            timerblink = 0;
            if(SR.enabled){
                SR.enabled = false;
            }
            else{
                SR.enabled = true;
            }
        }
    }

   


}
