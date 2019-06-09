using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//TODO add min/max
//TODO make managed contols work with these
//TODO readonly
//TODO raise events on value change
[Serializable]
public class BoolVariable : Variable<bool> { }
[Serializable]
public class FloatVariable : Variable<float> { }
[Serializable]
public class IntVariable : Variable<int> { }
[Serializable]
public class IntArrayVariable : Variable<int[]> { }
[Serializable]
public class StringVariable : Variable<string> { }
[Serializable]
public class Vector2Variable : Variable<Vector2> { }
[Serializable]
public class Vector3Variable : Variable<Vector3> { }
[Serializable]
public class ColorVariable : Variable<Color> { }

public class Variable<T>
{

    public bool useReference;
    public T localValue;
    public Reference<T> Reference
    {
        get { return (Reference<T>)serializedReference; }
        set { serializedReference = value; }
    }
    public ScriptableObject serializedReference;
    public T Value
    {
        get { return useReference ? Reference.value : localValue; }
    }

    public static implicit operator T(Variable<T> var)
    {
        return var.Value;
    }
}
