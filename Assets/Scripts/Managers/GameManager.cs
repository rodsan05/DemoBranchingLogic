using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance 
    {
        get => instance;
    }

    #region References
    private CinematicManager cinematicManager;
    public CinematicManager CinematicManager { set => cinematicManager = value; get => cinematicManager; }

    private DecisionManager decisionManager;
    public DecisionManager DecisionManager { get => decisionManager; set => decisionManager = value; }
    #endregion

    #region Methods
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this) 
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
