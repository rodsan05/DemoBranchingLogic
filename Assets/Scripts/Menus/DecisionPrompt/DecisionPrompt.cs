using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPrompt : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private GameObject choicesLayout;

    [SerializeField]
    private GameObject choicePrefab;
    #endregion

    #region Methods
    public void SetChoices(string[] choices) 
    {
        // Resize choices layout if there are more choices in the list than in the layout
        while (choicesLayout.transform.childCount < choices.Length) 
        {
            Instantiate(choicePrefab, choicePrefab.transform);
        }

        for (int i = 0; i < choices.Length; i++) 
        {
            GameObject choiceButton = choicesLayout.transform.GetChild(i).gameObject;
            string choice = choices[i];

            choiceButton.SetActive(true);
            choiceButton.GetComponent<AnimatedButton>().onClick.RemoveAllListeners();
            choiceButton.GetComponent<AnimatedButton>().onClick.AddListener(() => { GameManager.Instance.DecisionManager?.SubmitChoice(choice); });
            choiceButton.GetComponentInChildren<TextMeshProUGUI>().text = choice;
        }

        choicesLayout.transform.GetChild(0).GetComponent<Selectable>().Select();
    }

    public void SubmitChoice() 
    {

    }

    public void HideChoicePrompt() 
    {
        foreach (Transform choice in choicesLayout.transform) 
        {
            choice.gameObject.SetActive(false);
        }
    }
    #endregion
}
