using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTint : MonoBehaviour
{

    [SerializeField]
    private TrawnButton _button;
    [SerializeField]
    private ColorArrayReference _buttonColors;
    [SerializeField]
    [Range(0, 1)]
    private float _alpha = 1f;
    [SerializeField]
    private Graphic[] _graphics;
    [SerializeField]
    private SpriteRenderer[] _sprites;

    private void OnEnable()
    {
        var color = _buttonColors.value[(int)_button];
        color.a = _alpha;
        foreach (var graphic in _graphics) graphic.color = color;
        foreach (var sprite in _sprites) sprite.color = color;
    }

}
