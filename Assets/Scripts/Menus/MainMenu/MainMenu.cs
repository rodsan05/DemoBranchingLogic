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

    public void FadeAndLoadMainScene() 
    {
        GameManager.Instance.FadeTransition(GameManager.TransitionType.FadeOut, 1.0f, LoadMainScene);
    }

    private void LoadMainScene() 
    {
        SceneManager.LoadSceneAsync(SceneNames.GameplayLoader.ToString(), LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnLoaderLoaded;
    }

    private void OnLoaderLoaded(Scene scene, LoadSceneMode loadSceneMode) 
    {
        SceneManager.LoadSceneAsync(SceneNames.MainScene.ToString(), LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(SceneNames.MainMenu.ToString());
        SceneManager.sceneLoaded -= OnLoaderLoaded;
        SceneManager.sceneUnloaded += OnMenuUnloaded;
    }

    private void OnMenuUnloaded(Scene scene) 
    {
        GameManager.Instance.FadeTransition(GameManager.TransitionType.FadeIn, 1.0f);
        SceneManager.sceneUnloaded -= OnMenuUnloaded;
    }

    public void ExitApp() 
    {
        Application.Quit();
    }
}
