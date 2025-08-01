using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private DecisionPrompt decisionPromptScript;

    private DecisionNode currentDecisionNode;
    #endregion

    #region Methods
    private void Awake()
    {
        GameManager.Instance.DecisionManager = this;
    }

    public void PromptDecision(DecisionNode decisionNode) 
    {
        currentDecisionNode = decisionNode;
        
        if (decisionPromptScript) 
        {
            decisionPromptScript.SetChoices(decisionNode.choices);
            GameManager.Instance.PauseGameplay();
        }
    }

    public void SubmitChoice(string choice) 
    {
        if (currentDecisionNode) 
        {
            currentDecisionNode.SetChoice(choice);
            currentDecisionNode = null;

            decisionPromptScript.HideChoicePrompt();
            GameManager.Instance.ResumeGameplay();
        }
    }
    #endregion
}
