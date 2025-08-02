using UnityEngine;

public class QuestManager : MonoBehaviour
{
    #region References
    private BaseQuest currentQuest;
    #endregion

    #region Methods
    private void Start()
    {
        GameManager.Instance.QuestManager = this;
    }

    public void StartNewQuest(QuestInfo questInfo) 
    {
        currentQuest = new BaseQuest();
        currentQuest.InitializeQuest(this, questInfo);
        currentQuest.StartQuest();
    }

    public void EndCurrentQuest() 
    {
        currentQuest.EndQuest();
    }

    public bool IsCurrentQuestCompleted() 
    {
        return currentQuest.Completed;
    }
    #endregion
}
