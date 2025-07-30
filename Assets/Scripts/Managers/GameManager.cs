using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance 
    {
        get => instance;
    }

    #region References
    [SerializeField]
    private PlayableDirector director;
    public PlayableDirector Director { set => director = value; get => director; }
    #endregion

    #region Methods
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this) 
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
