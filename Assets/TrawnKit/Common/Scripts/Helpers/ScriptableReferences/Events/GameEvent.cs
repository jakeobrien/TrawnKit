using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent<T, U, V, X> : ScriptableObject
{
    public event Action<T, U, V, X> Event;

    public void Fire(T t, U u, V v, X x)
    {
        if (Event != null) Event.Invoke(t, u, v, x);
    }
}

public class GameEvent<T, U, V> : ScriptableObject
{
    public event Action<T, U, V> Event;

    public void Fire(T t, U u, V v)
    {
        if (Event != null) Event.Invoke(t, u, v);
    }
}

public class GameEvent<T, U> : ScriptableObject
{
    public event Action<T, U> Event;

    public void Fire(T t, U u)
    {
        if (Event != null) Event.Invoke(t, u);
    }
}

public class GameEvent<T> : ScriptableObject
{
    public event Action<T> Event;

    public void Fire(T t)
    {
        if (Event != null) Event.Invoke(t);
    }
}

[CreateAssetMenu(menuName = "Events/-no args-", order = (int)ReferenceTypeOrder.NoArgs)]
public class GameEvent : ScriptableObject
{
    public event Action Event;

    public void Fire()
    {
        if (Event != null) Event.Invoke();
    }
}
