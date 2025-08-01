using UnityEngine;
using UnityEngine.SceneManagement;

public class InitController : MonoBehaviour
{
    #region Methods
    void Start()
    {
        SceneManager.LoadScene(SceneNames.MainMenu.ToString());
    }
    #endregion
}
