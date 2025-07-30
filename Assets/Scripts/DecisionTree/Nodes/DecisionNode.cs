using UnityEngine;

public class DecisionNode : BaseNode 
{
    #region Properties
    [Input] public int entry;
    [Output(dynamicPortList = true)] public string[] choice;

    public int choiceIdx = -1;
    #endregion

    #region Methods
    public override bool Evaluate()
    {
        return choiceIdx != -1;
    }
    #endregion
}