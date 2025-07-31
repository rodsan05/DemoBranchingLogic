using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotificationManager : MonoBehaviour
{
    private static NotificationManager instance;
    public static NotificationManager Instance
    {
        get => instance;
    }

    #region Properties
    private Dictionary<DeclaredEvents, UnityEvent> events = new Dictionary<DeclaredEvents, UnityEvent>();
    #endregion

    #region Methods
    public void Awake()
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

    public void SubscribeToEvent(DeclaredEvents _event, UnityAction action)
    {
        if (!events.ContainsKey(_event)) 
        {            
            events.Add(_event, new UnityEvent());
        }

        events[_event].AddListener(action);
    }

    public void UnsubscribeToEvent(DeclaredEvents _event, UnityAction action)
    {
        if (events.ContainsKey(_event))
        {
            events[_event].RemoveListener(action);
        }
    }

    public void InvokeEvent(DeclaredEvents _event) 
    {
        if (events.ContainsKey(_event))
        {
            events[_event].Invoke();
        }
    }
    #endregion
}
