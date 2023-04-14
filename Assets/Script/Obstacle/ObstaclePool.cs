using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField]private DKGameManager gameManager;
    [SerializeField]private Transform[] ObstacleArrayPrefab;
    [SerializeField]private int totalObstacle;
    [SerializeField]private float obstacleSpawnWait;
    private enum Level{
        level1, level2, level3,level4
    }
    [SerializeField]private Level levelNow;
    private int random;
    private bool isSpawnOn;
    public List<Transform> Obstacles = new List<Transform>();

    private void Start() {
        gameManager.OnStartGame += gameManager_OnStartGame;
        gameManager.OnStopGame += gameManager_OnStopGame;
        

        for(int i=0;i<totalObstacle;i++){
            Transform chosenObstacle = ObstacleArrayPrefab[Random.Range(0,ObstacleArrayPrefab.Length)];
            Debug.Log("Hallo ???");
            Transform obstacle = Instantiate(chosenObstacle);
            obstacle.gameObject.SetActive(false);
            obstacle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            obstacle.position = transform.position;
            obstacle.rotation = transform.rotation;
            
            Obstacles.Add(obstacle);
        }
        isSpawnOn = true;
    }

    private void gameManager_OnStartGame(object sender, System.EventArgs e){
        StartCoroutine(startSpawn());
    }
    private void gameManager_OnStopGame(object sender, System.EventArgs e){ 
        isSpawnOn = false;
        StopCoroutine(startSpawn());
    }

    private IEnumerator startSpawn(){
        yield return new WaitForSeconds(0.7f);
        while(isSpawnOn){
            foreach(Transform obstacle in Obstacles){
                if(!isSpawnOn){
                    break;
                }
                if(obstacle.gameObject.activeSelf){
                    continue;
                }
                // obstacle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                // int random = Random.Range(0,2) == 0 ? -1 : 1;
                
                if(levelNow == Level.level1){
                    random = -1;
                }
                else if(levelNow == Level.level2){
                    random = Random.Range(0,3) % 2 == 0 ? 1 : -1;
                }
                else if(levelNow == Level.level3){
                    random = Random.Range(0,2) == 0 ? -1 : 1;
                }
                else if(levelNow == Level.level4){
                    random = Random.Range(0,2) == 0 ? -1 : 1;
                }
                Obstacle obs = obstacle.GetComponent<Obstacle>();
                obs.ChangeDirection(random);
                
                // obstacle.GetComponent<Rigidbody2D>().velocity =  new Vector2(obstacle.GetComponent<Rigidbody2D>().velocity.x,-30);
                obstacle.position = transform.position;
                obstacle.rotation = transform.rotation;
                obstacle.gameObject.SetActive(true);
                
                yield return new WaitForSeconds(obstacleSpawnWait);
            }
        }

    }

    

    

}
