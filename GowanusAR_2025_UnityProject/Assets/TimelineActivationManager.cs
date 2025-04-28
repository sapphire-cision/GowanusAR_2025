using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

using System.Collections.Generic;

public class TimelineActivationManager : MonoBehaviour
{
    private PlayableDirector director;
    //public List<GameObject> activationTargets; // Populate with all possible objects that get activated

    void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    void OnEnable()
    {
        if (director != null)
        {
            director.stopped += OnTimelineStopped;
        }
    }

    void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnTimelineStopped;
        }
    }

    void OnTimelineStopped(PlayableDirector _)
    {
        TimelineAsset timeline = director.playableAsset as TimelineAsset;
        if (timeline == null)
            return;

        foreach (var track in timeline.GetOutputTracks())
        {
            if (track is ActivationTrack)
            {
                var boundObject = director.GetGenericBinding(track) as GameObject;
                if (boundObject != null)
                {
                    boundObject.SetActive(false);
                }
            }
        }
    }
}
