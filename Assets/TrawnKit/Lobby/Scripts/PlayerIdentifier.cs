using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIdentifier : MonoBehaviour
{

    [SerializeField]
    private TrawnPlayer _player;
    [SerializeField]
    private PlayerInfos _playerInfos;
    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Image _bgImage;
    [SerializeField]
    private Image _slantImage;

    private void OnEnable()
    {
        _bgImage.color = _playerInfos.GetColor(_player);
        _slantImage.color = _playerInfos.GetColor(_player);
        _nameText.text = _playerInfos.GetName(_player);
    }


}
