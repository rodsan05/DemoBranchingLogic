using UnityEngine;

public class BaseQuestItem : MonoBehaviour
{
    #region References
    protected BaseQuest quest;
    #endregion

    #region Methods
    public virtual void InitializeItem(BaseQuest _quest) 
    {
        quest = _quest;
    }
    #endregion
}
