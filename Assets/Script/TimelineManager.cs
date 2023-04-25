using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineManager : MonoBehaviour
{
    [SerializeField]private TimelineAsset[] timelineAsset;
    private PlayableDirector director;
    [SerializeField]private int startTrack;

    private void Start()
    {
        director = GetComponent<PlayableDirector>();
        // director.playableAsset = timelineAsset[x];
        director.stopped += OnTimelineStopped; // subscribe to the stopped event
        // director.extrapolationMode = DirectorWrapMode.None;

        
        director.Play();
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("Dialogue Tiem");
        startTrack++;
    }
    private void Update() {
        if(startTrack == 1 && Input.GetKeyDown(KeyCode.G)){
            // Debug.Log("sini ?");
            director.playableAsset = timelineAsset[startTrack];
            director.Play();
        }
        if(startTrack == 2 && Input.GetKeyDown(KeyCode.G)){
            // Debug.Log("sini s?");
            director.playableAsset = timelineAsset[startTrack];
            director.Play();
        }
        
    }
}
