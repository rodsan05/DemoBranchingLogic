using UnityEngine;

public class DecisionNode : BaseNode 
{
    #region Properties
    [Input] public int entry;
    [Output(dynamicPortList = true)] public string[] choice;

    private int choiceIndex = -1;
    public int ChoiceIndex { get => choiceIndex; }
    #endregion

    #region Methods
    public override bool Evaluate()
    {
        return choiceIndex != -1;
    }

    public override void ResetNodeValues()
    {
        base.ResetNodeValues();

        choiceIndex = -1;
    }
    #endregion
}