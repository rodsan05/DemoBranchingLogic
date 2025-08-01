using System;
using UnityEngine;

public class ReachPointTrigger : BaseQuestItem
{
    #region Properties
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (quest is ReachPointQuest)
            {
                quest.CompleteQuest();
            }
        }
    }
    #endregion
}
