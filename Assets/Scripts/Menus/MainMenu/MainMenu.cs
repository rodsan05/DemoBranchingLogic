using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Selectable firstSelected;

    private void Start()
    {
        if (firstSelected) 
        {
            firstSelected.Select();
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("GameplayLoader", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnLoaderLoaded;
    }

    public void OnLoaderLoaded(Scene scene, LoadSceneMode loadSceneMode) 
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.sceneLoaded -= OnLoaderLoaded;
    }

    public void ExitApp() 
    {
        Application.Quit();
    }
}
