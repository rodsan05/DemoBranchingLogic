using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[RequireComponent(typeof(PlayableDirector))]
public class CinematicManager : MonoBehaviour
{
    #region References
    [SerializeField]
    private PlayableDirector director;

    [SerializeField]
    private Transform playerPosition;

    public Transform PlayerPosition { get => playerPosition; set => playerPosition = value; }
    #endregion

    #region Methods
    private void Awake()
    {
        if (director == null) 
        {
            director = GetComponent<PlayableDirector>();
        }

        GameManager.Instance.CinematicManager = this;
    }

    public void PlayTimeline(TimelineAsset timeline, Action<PlayableDirector> onTimelineEnded = null) 
    {
        if (director) 
        {
            NotificationManager.Instance.InvokeEvent(DeclaredEvents.CinematicStart);
            director.playableAsset = timeline;
            director.Play();
            director.stopped += OnTimelineStopped;

            if (onTimelineEnded != null) 
            {
                director.stopped += onTimelineEnded;
            }
        }
    }

    public void OnTimelineStopped(PlayableDirector playableDirector) 
    {
        NotificationManager.Instance.InvokeEvent(DeclaredEvents.CinematicEnded);
        playableDirector.stopped -= OnTimelineStopped;
    }

    public void StopCurrentTimeline() 
    {
        if (director) 
        {
            director.Stop();
        }
    }

    public void RepositionDirector(Vector3 position) 
    {
        if (director) 
        {
            director.transform.position = position;
        }
    }
    #endregion
}
