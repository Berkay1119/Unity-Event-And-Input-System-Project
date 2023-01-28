using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

    public void Raise()
    {
        foreach (var listener in _eventListeners)
        {
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (_eventListeners.Contains(listener))
        {
            return;
        }
        _eventListeners.Add(listener);
    }
    public void UnegisterListener(GameEventListener listener)
    {
        if (!_eventListeners.Contains(listener))
        {
            return;
        }
        _eventListeners.Remove(listener);
    }
}
