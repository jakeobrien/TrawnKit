using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    [SerializeField]
    private int _winScore;
    [SerializeField]
    private ActivePlayers _activePlayers;
    [SerializeField]
    private GameOverView _gameOverView;
    [SerializeField]
    private TrawnPlayerReference _winningPlayer;
    [SerializeField]
    private Player _playerPrefab;
    private PlayerInfo[] _players;
    private bool _isGameOver;


    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        _players = _activePlayers.GetActivePlayers();
        CreatePlayers();
    }

    private void Update()
    {
        CheckForWinner();
    }

    private void CreatePlayers()
    {
        foreach (var info in _players)
        {
            info.score = 0;
            var pos = Random.insideUnitCircle.normalized * 8f;
            var player = Instantiate(_playerPrefab, pos, Quaternion.identity);
            player.SetPlayerInfo(info);
        }
    }

    private bool CheckForWinner()
    {
        foreach (var player in _players)
        {
            if (player.score >= _winScore)
            {
                StartCoroutine(Win(player));
                return true;
            }
        }
        return false;
    }

    private IEnumerator Win(PlayerInfo player)
    {
        if (_isGameOver) yield break;
        _isGameOver = true;
        yield return null;
        _winningPlayer.value = player.player;
        _gameOverView.Show();
    }
}
