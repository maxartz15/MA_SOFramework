using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> eventListeners = new List<GameEventListener>();

    public void InvokeEvent()
    {
        for(int i = eventListeners.Count -1; i >= 0; i--)
		{
            eventListeners[i].OnInvokeEvent();
		}
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}