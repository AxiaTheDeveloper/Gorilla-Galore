using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChangeDirection : MonoBehaviour
{
    private enum direction{
        right, left, none
    }
    [SerializeField]private direction direct;
    [SerializeField]private float addSpeed;
    private const string OBSTACLE_TAG = "Obstacle";
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(OBSTACLE_TAG)){
            Obstacle obs = other.gameObject.GetComponent<Obstacle>();
            if(direct == direction.right){
                obs.ChangeDirection(1);
                obs.AddSpeed(addSpeed);
                obs.Go(this.gameObject);
                // Debug.Log("koko");
            }
            else if(direct == direction.left){
                obs.ChangeDirection(-1);
                obs.AddSpeed(addSpeed);
                obs.Go(this.gameObject);
                // Debug.Log("???");
            }
            else{
                obs.AddSpeed(addSpeed);
                obs.Go(this.gameObject);
            }
        }
    }
}
