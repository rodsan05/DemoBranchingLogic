using System.Collections.Generic;
using UnityEngine;

public class BaseQuest : ScriptableObject
{
    #region Properties
    private bool completed;
    public bool Completed { get => completed; set => completed = value; }
    #endregion

    #region References
    [SerializeField]
    private List<GameObject> questItems;

    [SerializeField]
    private List<GameObject> permanentQuestItems;
    #endregion

    #region Methods
    public virtual void StartQuest() 
    {
        ToggleQuestItems(true);
        TogglePermanentQuestItems();
    }

    public virtual void CompleteQuest() 
    {
        ToggleQuestItems(false);
        completed = true;
    }
    
    public virtual void ToggleQuestItems(bool active) 
    {
        if (questItems != null) 
        {
            foreach (GameObject item in questItems) 
            {
                if (active) 
                {
                    Instantiate(item);
                    // Check if there are quest items to assing its quest to this
                    BaseQuestItem questItem = item.GetComponent<BaseQuestItem>();
                    if (questItem) 
                    {
                        questItem.InitializeItem(this);
                    }
                }

                else 
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public virtual void TogglePermanentQuestItems() 
    {
        if (permanentQuestItems != null)
        {
            foreach (GameObject item in permanentQuestItems)
            {
                Instantiate(item);
                // Check if there are quest items to assing its quest to this
                BaseQuestItem questItem = item.GetComponent<BaseQuestItem>();
                if (questItem)
                {
                    questItem.InitializeItem(this);
                }
            }
        }
    }
    #endregion
}
