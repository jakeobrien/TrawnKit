using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{

    [SerializeField]
    private SceneReference _lobbyScene;
    [SerializeField]
    private TrawnButtonEvent _buttonEvent;
    [SerializeField]
    private TrawnPlayerReference _winningPlayer;
    [SerializeField]
    private GameObject _bg;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private GameObject _winner;
    [SerializeField]
    private float[] _winnerXPositions;

    private bool _interactionEnabled;

    private void Start()
    {
        _bg.SetActive(false);
        _gameOver.SetActive(false);
        _menu.SetActive(false);
        _winner.SetActive(false);
    }

    private void OnEnable()
    {
        _buttonEvent.Event += OnButtonPress;
    }

    private void OnDisable()
    {
        _buttonEvent.Event -= OnButtonPress;
    }

    public void Show()
    {
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        _bg.SetActive(true);
        _gameOver.SetActive(true);
        yield return new WaitForSeconds(1f);
        var playerIndex = (int)_winningPlayer.value;
        var pos = _winner.transform.localPosition;
        pos.x = _winnerXPositions[playerIndex];
        _winner.transform.localPosition = pos;
        _winner.GetComponent<PlayerTint>().SetPlayer(_winningPlayer.value);
        _winner.SetActive(true);
        yield return new WaitForSeconds(3f);
        _menu.SetActive(true);
        _interactionEnabled = true;
    }

    private void OnButtonPress(TrawnButton button, TrawnPlayer player)
    {
        if (!_interactionEnabled) return;
        if (button == TrawnButton.Menu) _lobbyScene.LoadScene();
        if (button == TrawnButton.Blue) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
