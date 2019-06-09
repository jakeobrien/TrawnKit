using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    [SerializeField]
    private SceneReference _lobbyScene;
    [SerializeField]
    private TrawnInput _tronInput;
    [SerializeField]
    private Reference<GameState> _gameState;
    [SerializeField]
    private GameEvent<GameState> _gameStateChanged;
    private float _lastChangeTime;

    public void ChangeState(GameState newState)
    {
        if (newState == _gameState.value) return;
        _gameState.value = newState;
        _gameStateChanged.Fire(newState);
    }

    private void Update()
    {
        if (Time.unscaledTime - _lastChangeTime < 0.7f) return;

    }

}
