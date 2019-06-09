using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHUD : MonoBehaviour
{


    [SerializeField]
    private TrawnPlayer _player;
    [SerializeField]
    private PlayerEvent _playerScoredEvent;
    [SerializeField]
    private PlayerInfos _playerInfos;
    [SerializeField]
    private IntArrayVariable _currentPlayers;
    [SerializeField]
    private GameInfo _gameInfo;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _nameText;
    [SerializeField]
    private Image _bgImage;
    [SerializeField]
    private Image _slantImage;

    private void OnEnable()
    {
        _playerScoredEvent.Event += PlayerScored;
        _bgImage.color = _playerInfos.GetColor(_player);
        _slantImage.color = _playerInfos.GetColor(_player);
        _scoreText.color = _playerInfos.GetColor(_player);
        _nameText.text = _playerInfos.GetName(_player);
        LayoutForActive();
    }

    private void OnDisable()
    {
        _playerScoredEvent.Event -= PlayerScored;
    }

    private void LayoutForActive()
    {
        var active = PlayersQuery.IsPlayerActive(_player, _currentPlayers);
        _bgImage.enabled = active;
        _slantImage.enabled = active;
        _nameText.enabled = active;
        _scoreText.enabled = active && _gameInfo.showScores;
    }

    private void PlayerScored(TrawnPlayer player)
    {
        if (!_gameInfo.showScores) return;
        if (player != _player) return;
        var score = _playerInfos.GetScore(player);
        _scoreText.text = score.ToString();
        _scoreText.transform.DOPunchScale(Vector3.one * 0.6f, 0.4f);
    }

}
