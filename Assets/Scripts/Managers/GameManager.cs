using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using System.Collections;

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

    [SerializeField]
    private Image blackScreen;
    #endregion

    #region Enums
    public enum TransitionType { FadeIn, FadeOut, FadeOutAndIn }
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

    private void Start()
    {
        FadeTransition(TransitionType.FadeOut, 0f);
    }

    public void FadeTransition(TransitionType transition, float time, Action onTransitionEnded = null) 
    {
        switch (transition) 
        {
            case TransitionType.FadeIn:
                blackScreen?.DOFade(0.0f, time);
                break;
            case TransitionType.FadeOut:
                blackScreen?.DOFade(1.0f, time);
                break;
            case TransitionType.FadeOutAndIn:
                Sequence sequence = DOTween.Sequence();
                sequence.Append(blackScreen?.DOFade(1.0f, time/2));
                sequence.Append(blackScreen?.DOFade(0.0f, time/2));
                sequence.Play();
                break;
        }

        if (onTransitionEnded!= null) 
        {
            StartCoroutine(TransitionCallback(onTransitionEnded, time));
        }
    }

    private IEnumerator TransitionCallback(Action callback, float time) 
    {
        yield return new WaitForSeconds(time);

        callback.Invoke();
    }

    public void PauseGameplay() 
    {
        Time.timeScale = 0f;
    }

    public void ResumeGameplay() 
    {
        Time.timeScale = 1f;
    }
    #endregion
}
