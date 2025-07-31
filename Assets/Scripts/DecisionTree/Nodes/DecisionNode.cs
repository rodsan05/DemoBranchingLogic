using UnityEngine;

public class DecisionNode : BaseNode 
{
    #region Properties
    [Input] public int entry;
    [Output(dynamicPortList = true)] public string[] choices;

    private int choiceIndex = -1;
    public int ChoiceIndex { get => choiceIndex; }
    #endregion

    #region Methods
    public override bool Evaluate()
    {
        return choiceIndex != -1;
    }

    public override void OnNodeEnter()
    {
        base.OnNodeEnter();

        GameManager.Instance.DecisionManager?.PromptDecision(this);
    }

    public void SetChoice(string chosenOption) 
    {
        for (int i = 0; i < choices.Length; i++) 
        {
            if (choices[i] == chosenOption) 
            {
                choiceIndex = i;
                return;
            }
        }
    }

    public string[] GetPossibleChoices() 
    {
        return choices;
    }

    public override void ResetNodeValues()
    {
        base.ResetNodeValues();


        choiceIndex = -1;
    }
    #endregion
}