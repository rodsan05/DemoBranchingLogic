using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    #region References
    [SerializeField]
    private DecisionPrompt decisionPromptScript;

    [SerializeField]
    private EndingScreen endingScreenScript;

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

    public void SetupEnding(string endingText) 
    {
        if (endingScreenScript) 
        {
            endingScreenScript.SetEndingText(endingText);
            endingScreenScript.gameObject.SetActive(true);
        }
    }
    #endregion
}
