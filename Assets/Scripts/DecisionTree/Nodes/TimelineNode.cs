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
    }

    public override bool Evaluate()
    {
        return timelineEnded;
    }

    public override void OnNodeEnter()
    {
        base.OnNodeEnter();

        PlayableDirector director = GameManager.Instance.Director;
        if (director != null) 
        {
            director.playableAsset = timeline;
            director.stopped += OnTimelineEnded;
            director.Play();
        }
    }

    public override void OnNodeExit()
    {
        base.OnNodeExit();

        PlayableDirector director = GameManager.Instance.Director;
        if (director != null)
        {
            director.stopped -= OnTimelineEnded;
        }
    }
    #endregion
}