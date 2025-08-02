using TMPro;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    #region References
    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private TextMeshProUGUI mainText;
    #endregion

    #region Methods
    public void SetEndingText(string text) 
    {
        string[] texts = text.Split(':');

        title.text = texts[0];
        mainText.text = texts[1];
    }
    #endregion
}
