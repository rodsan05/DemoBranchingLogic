using System.Collections.Generic;
using UnityEngine;

public class BaseQuest
{
    #region Properties
    private bool completed = false;
    public bool Completed { get => completed; }

    public QuestType QuestType 
    {
        get 
        {
            if (!questInfo) 
            {
                return QuestType.None;
            }

            return questInfo.QuestType;
        } 
    }
    #endregion

    #region References
    protected QuestInfo questInfo;
    protected QuestManager questManager;

    protected List<GameObject> temporalItems = new List<GameObject>();
    protected List<GameObject> permanentItems = new List<GameObject>();
    #endregion

    #region Methods
    public virtual void InitializeQuest(QuestManager manager, QuestInfo info) 
    {
        questInfo = info;
        questManager = manager;

        InstantiateQuestItems();
    }

    public virtual void StartQuest()
    {
        ToggleTemporalQuestItems(true);
        TogglePermanentQuestItems(true);
    }

    public virtual void CompleteQuest()
    {
        completed = true;
    }

    public virtual void EndQuest() 
    {
        ToggleTemporalQuestItems(false);
    }

    public virtual void ToggleTemporalQuestItems(bool active)
    {
        if (temporalItems != null)
        {
            foreach (GameObject item in temporalItems)
            {
                item.SetActive(active);
            }
        }
    }

    public virtual void TogglePermanentQuestItems(bool active)
    {
        if (permanentItems != null)
        {
            foreach (GameObject item in permanentItems)
            {
                item.SetActive(active);
            }
        }
    }

    public virtual void InstantiateQuestItems()
    {
        if (questInfo.TemporalQuestItems != null)
        {
            foreach (GameObject item in questInfo.TemporalQuestItems)
            {
                GameObject itemInstance = GameObject.Instantiate(item);
                itemInstance.SetActive(false);
                // Check if there are quest items to assing its quest to this
                BaseQuestItem questItem = itemInstance.GetComponent<BaseQuestItem>();
                if (questItem)
                {
                    questItem.InitializeItem(this);
                }

                temporalItems.Add(itemInstance);
            }
        }

        if (questInfo.PermanentQuestItems != null)
        {
            foreach (GameObject item in questInfo.PermanentQuestItems)
            {
                GameObject itemInstance = GameObject.Instantiate(item);
                itemInstance.SetActive(false);
                // Check if there are quest items to assing its quest to this
                BaseQuestItem questItem = itemInstance.GetComponent<BaseQuestItem>();
                if (questItem)
                {
                    questItem.InitializeItem(this);
                }

                permanentItems.Add(itemInstance);
            }
        }
    }
    #endregion
}
