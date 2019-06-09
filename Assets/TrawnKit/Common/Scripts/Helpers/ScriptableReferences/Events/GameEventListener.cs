using UnityEngine;
using UnityEngine.Events;
using System;

public class GameEventListener : MonoBehaviour
{

    public EventMapping[] mappings;
    public FloatEventMapping[] floatMappings;

    private void OnEnable()
    {
        foreach (var mapping in mappings) mapping.Subscribe();
        foreach (var mapping in floatMappings) mapping.Subscribe();
    }

    private void OnDisable()
    {
        foreach (var mapping in mappings) mapping.Unsubscribe();
        foreach (var mapping in floatMappings) mapping.Unsubscribe();
    }

}

[Serializable]
public class FloatEventMapping : EventMapping<float> { }

public class EventMapping<T>
{
    public GameEvent<T> Event;
    public UnityEvent<T> Response;

    public void Subscribe()
    {
        Event.Event += OnEventFired;
    }

    public void Unsubscribe()
    {
        Event.Event -= OnEventFired;
    }

    public void OnEventFired(T t)
    {
        Response.Invoke(t);
    }
}

[Serializable]
public class EventMapping
{
    public GameEvent Event;
    public UnityEvent Response;

    public void Subscribe()
    {
        Event.Event += OnEventFired;
    }

    public void Unsubscribe()
    {
        Event.Event -= OnEventFired;
    }

    public void OnEventFired()
    {
        Response.Invoke();
    }
}
