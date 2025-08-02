using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests/BaseQuest")]
public class QuestInfo : ScriptableObject
{
    #region Properties
    [SerializeField]
    private QuestType questType;
    public QuestType QuestType { get => questType; set => questType = value; }
    #endregion

    #region References
    [SerializeField]
    private List<GameObject> temporalQuestItems;
    public List<GameObject> TemporalQuestItems { get => temporalQuestItems; }

    [SerializeField]
    private List<GameObject> permanentQuestItems;
    public List<GameObject> PermanentQuestItems { get => permanentQuestItems; }
    #endregion
}
