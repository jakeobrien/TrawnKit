using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Reference<T> : ReferenceBase
{

#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public T value;
}

public abstract class ReferenceBase : DontUnloadScriptableObject { }

public abstract class ListReference<T> : DontUnloadScriptableObject
{
    public List<T> items = new List<T>();

    public void Add(T t)
    {
        if (!items.Contains(t)) items.Add(t);
    }

    public void Remove(T thing)
    {
        if (items.Contains(thing)) items.Remove(thing);
    }
}
