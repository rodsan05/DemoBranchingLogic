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
        GameManager.Instance.FadeTransition(GameManager.TransitionType.FadeOut, 1.0f, LoadGameplayLoader);
    }

    private void LoadGameplayLoader() 
    {
        SceneManager.LoadSceneAsync(SceneNames.GameplayLoader.ToString(), LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnLoaderLoaded;
    }

    private void OnLoaderLoaded(Scene scene, LoadSceneMode loadSceneMode) 
    {
        SceneManager.UnloadSceneAsync(SceneNames.MainMenu.ToString());
        SceneManager.sceneLoaded -= OnLoaderLoaded;
        SceneManager.sceneUnloaded += OnMenuUnloaded;
    }

    private void OnMenuUnloaded(Scene scene) 
    {
        SceneManager.LoadScene(SceneNames.MainScene.ToString(), LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnMainSceneLoaded;
        SceneManager.sceneUnloaded -= OnMenuUnloaded;
    }

    private void OnMainSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) 
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.sceneLoaded -= OnMainSceneLoaded;
    }

    public void ExitApp() 
    {
        Application.Quit();
    }
}
