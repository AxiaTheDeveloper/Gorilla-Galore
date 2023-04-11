using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField]private DKGameManager gameManager;
    [SerializeField]private Transform[] ObstacleArrayPrefab;
    [SerializeField]private int totalObstacle;
    [SerializeField]private float obstacleSpawnWait;
    
    public List<Transform> Obstacles = new List<Transform>();

    private void Start() {
        gameManager.OnStartGame += gameManager_OnStartGame;
        gameManager.OnStopGame += gameManager_OnStopGame;
        for(int i=0;i<totalObstacle;i++){
            Transform chosenObstacle = ObstacleArrayPrefab[Random.Range(0,ObstacleArrayPrefab.Length)];
            Transform obstacle = Instantiate(chosenObstacle);
            obstacle.gameObject.SetActive(false);
            
            obstacle.position = transform.position;
            obstacle.rotation = transform.rotation;
            
            Obstacles.Add(obstacle);
        }
    }

    private void gameManager_OnStartGame(object sender, System.EventArgs e){
        StartCoroutine(startSpawn());
    }
    private void gameManager_OnStopGame(object sender, System.EventArgs e){
        StopCoroutine(startSpawn());
    }

    private IEnumerator startSpawn(){
        yield return new WaitForSeconds(0.1f);
        while(enabled){
            foreach(Transform obstacle in Obstacles){
                if(obstacle.gameObject.activeSelf){
                    continue;
                }
                obstacle.position = transform.position;
                obstacle.rotation = transform.rotation;
                obstacle.gameObject.SetActive(true);
                
                yield return new WaitForSeconds(obstacleSpawnWait);
            }
        }

    }

    

}
