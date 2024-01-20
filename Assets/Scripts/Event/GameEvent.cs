using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_",menuName = "ScriptableObjects/GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    /// <summary>
    /// 调用事件所订阅的所有方法
    /// </summary>
    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender,data);
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
