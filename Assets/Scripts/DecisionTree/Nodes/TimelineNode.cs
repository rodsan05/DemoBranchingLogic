using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineNode : BaseNode
{
    #region Properties
    [Input] public int entry;
	[Output] public int exit;

	private bool timelineEnded = false;
    #endregion

    #region References
    public TimelineAsset timeline;
    #endregion

    #region Methods
    public void OnTimelineEnded(PlayableDirector director) 
    {
        timelineEnded = true;
        director.stopped -= OnTimelineEnded;
    }

    public override bool Evaluate()
    {
        return timelineEnded;
    }

    public override void ResetNodeValues()
    {
        base.ResetNodeValues();

        timelineEnded = false;
    }

    public override void OnNodeEnter()
    {
        base.OnNodeEnter();

        CinematicManager cinematicManager = GameManager.Instance.CinematicManager;
        if (cinematicManager != null) 
        {
            cinematicManager.PlayTimeline(timeline, OnTimelineEnded);
        }
    }
    #endregion
}