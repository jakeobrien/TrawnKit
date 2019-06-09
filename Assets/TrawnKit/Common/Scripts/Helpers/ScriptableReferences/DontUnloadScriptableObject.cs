using UnityEngine;

public class DontUnloadScriptableObject : ScriptableObject
{

    protected virtual void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

}
