using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using DG.Tweening;

public class LobbyView : MonoBehaviour
{

    [SerializeField]
    private GameInfo _gameInfo;
    [SerializeField]
    private TrawnButtonEvent _buttonEvent;
    [SerializeField]
    private IntArrayReference _currentPlayers;
    [SerializeField]
    private LobbyPlayerMenu[] _playerSelects;
    [SerializeField]
    private Countdown _countdown;
    [SerializeField]
    private Text _gameNameText;
    [SerializeField]
    private Text _playersText;
    [SerializeField]
    private SceneReference _launcherScene;
    [SerializeField]
    private SceneReference _instructionsScene;
    private Coroutine _countdownCoroutine;
    private float _startTime;

    public GameInfo GameInfo { get { return _gameInfo; } }

    private void Start()
    {
        _startTime = Time.unscaledTime;
    }

    private void OnEnable()
    {
        _gameNameText.text = GameInfo.gameName;
        _playersText.text = string.Format("{0} - {1} PLAYERS", GameInfo.minNumberPlayers, GameInfo.maxNumberPlayers);
        _buttonEvent.Event += OnButtonPress;
        for (var i = 0; i < 4; i++)
        {
            var playerSelect = _playerSelects[i];
            if (i < GameInfo.maxNumberPlayers)
            {
                playerSelect.gameObject.SetActive(true);
                playerSelect.OnJoin += OnJoin;
                playerSelect.OnUnjoin += OnUnjoin;
            }
            else
            {
                playerSelect.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        _buttonEvent.Event -= OnButtonPress;
        foreach (var playerSelect in _playerSelects)
        {
            playerSelect.OnJoin -= OnJoin;
            playerSelect.OnUnjoin -= OnUnjoin;
        }
    }

    private void OnButtonPress(TrawnButton button, TrawnPlayer player)
    {
        if (button == TrawnButton.Menu && Time.unscaledTime - _startTime > 1f) _launcherScene.LoadScene();
    }

    private void OnJoin()
    {
        var numberJoined = GetNumberJoinedPlayers();
        if (numberJoined >= GameInfo.minNumberPlayers) StartCountdown();
    }

    private void OnUnjoin()
    {
        var numberJoined = GetNumberJoinedPlayers();
        if (numberJoined < GameInfo.minNumberPlayers) StopCountdown();
    }

    private void StartCountdown()
    {
        StopCountdown();
        _countdownCoroutine = StartCoroutine(Countdown());
    }

    private void StopCountdown()
    {
        _countdown.Stop();
        if (_countdownCoroutine != null) StopCoroutine(_countdownCoroutine);
        _countdownCoroutine = null;
    }

    private IEnumerator Countdown()
    {
        yield return _countdown.DoCountdown(3);
        _countdownCoroutine = null;
        StartGame();
    }

    private void StartGame()
    {
        var activePlayerSelects = _playerSelects.Where((s) => s.HasJoined);
        _currentPlayers.value = activePlayerSelects.Select((s) => s.PlayerIndex).ToArray();
        if (GameInfo.instructions.Length > 0) _instructionsScene.LoadScene();
        else GameInfo.sceneToLoad.LoadScene();
    }

    private int GetNumberJoinedPlayers()
    {
        return _playerSelects.Where((s) => s.HasJoined).ToArray().Length;
    }

}
