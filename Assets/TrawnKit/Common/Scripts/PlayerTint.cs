using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTint : MonoBehaviour
{

    [SerializeField]
    private TrawnPlayer _player;
    [SerializeField]
    private PlayerInfos _playerInfos;
    [SerializeField]
    [Range(0, 1)]
    private float _alpha = 1f;
    [SerializeField]
    private Graphic[] _graphics;
    [SerializeField]
    private SpriteRenderer[] _sprites;

    public void SetPlayer(TrawnPlayer player)
    {
        _player = player;
        SetColor();
    }

    private void OnEnable()
    {
        SetColor();
    }

    private void SetColor()
    {
        var color = _playerInfos.GetColor(_player);
        color.a = _alpha;
        foreach (var graphic in _graphics) graphic.color = color;
        foreach (var sprite in _sprites) sprite.color = color;
    }

}
