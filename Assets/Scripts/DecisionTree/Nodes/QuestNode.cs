using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using XNode;

public class QuestNode : BaseNode 
{
    #region Properties
    [Input] public int entry;
    [Output] public int exit;
    #endregion

    #region References
    public QuestInfo quest;
    #endregion

    #region Methods
    public override bool Evaluate()
    {
        return GameManager.Instance.QuestManager.IsCurrentQuestCompleted();
    }

    public override void ResetNodeValues()
    {
        base.ResetNodeValues();
    }

    public override void OnNodeEnter()
    {
        base.OnNodeEnter();

        GameManager.Instance.QuestManager?.StartNewQuest(quest);
    }

    public override void OnNodeExit() 
    {
        GameManager.Instance.QuestManager?.EndCurrentQuest();

    }
    #endregion
}