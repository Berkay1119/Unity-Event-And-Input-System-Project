using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, GameEventListener
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        _event.UnegisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
