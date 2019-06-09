using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTintGroup : MonoBehaviour
{

    [SerializeField]
    private TrawnPlayer _player;
    [SerializeField]
    private PlayerTint[] _tints;

    private void Start()
    {
        SetColor();
    }

    public void SetColor()
    {
        foreach (var tint in _tints) tint.SetPlayer(_player);
    }

}
