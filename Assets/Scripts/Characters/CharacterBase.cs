using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    #region Properties
    private bool wasActive = false;
    #endregion

    #region Methods
    private void Awake()
    {
        NotificationManager.Instance.SubscribeToEvent(DeclaredEvents.CinematicStart, OnCinematicStart);
        NotificationManager.Instance.SubscribeToEvent(DeclaredEvents.CinematicEnded, OnCinematicEnd);
    }

    public virtual void OnCinematicStart() 
    {
        wasActive = gameObject.activeSelf;
        gameObject.SetActive(false);
    }
    public virtual void OnCinematicEnd()
    {
        if (wasActive) 
        {
            gameObject.SetActive(true);
        }
    }
    #endregion
}
