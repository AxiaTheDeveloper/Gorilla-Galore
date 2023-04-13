using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class testScript : MonoBehaviour
{
    public TimelineAsset[] timelineAsset;
    private PlayableDirector director;
    private int x = 0;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.playableAsset = timelineAsset[x];
        director.stopped += OnTimelineStopped; // subscribe to the stopped event
        // director.extrapolationMode = DirectorWrapMode.None;

        
        director.Play();
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("Dialogue Tiem");
        x++;
    }
    private void Update() {
        if(x == 1 && Input.GetKeyDown(KeyCode.G)){
            Debug.Log("sini ?");
            director.playableAsset = timelineAsset[x];
            director.Play();
        }
        
    }
}
