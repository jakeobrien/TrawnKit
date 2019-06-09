using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private TrawnInput _trawnInput;
    [SerializeField]
    private GameObject _visibleRoot;
    [SerializeField]
    private SceneReference _lobbyScene;

    [SerializeField]
    private Image _holdToQuitMeter;
    [SerializeField]
    private float _quitHoldTime;

    private bool _isPaused;
    private float _lastPauseChangeTime;
    private bool _isHoldingQuit;
    private float _quitHoldStartTime;

    private void Start()
    {
        _visibleRoot.SetActive(false);
    }

    private void Update()
    {
        if (Time.unscaledTime - _lastPauseChangeTime < 0.7f) return;
        if (!_isPaused) ListenForPause();
        else PauseUpdate();
    }

    private void ListenForPause()
    {
        if (_trawnInput.GetButtonUp(TrawnButton.Menu)) SetPaused(true);
    }

    private void SetPaused(bool paused)
    {
        _holdToQuitMeter.enabled = false;
        _lastPauseChangeTime = Time.unscaledTime;
        _isPaused = paused;
        Time.timeScale = paused ? 0f : 1f;
        _visibleRoot.SetActive(paused);
    }

    private void PauseUpdate()
    {
        if (_trawnInput.GetButtonDown(TrawnButton.Menu))
        {
            _isHoldingQuit = true;
            _quitHoldStartTime = Time.unscaledTime;
            _holdToQuitMeter.enabled = true;
        }

        if (_trawnInput.GetButtonUp(TrawnButton.Menu))
        {
            SetPaused(false);
            _holdToQuitMeter.enabled = false;
            _isHoldingQuit = false;
        }

        if (_isHoldingQuit)
        {
            var t = (Time.unscaledTime - _quitHoldStartTime) / _quitHoldTime;
            _holdToQuitMeter.fillAmount = t;
            if (t >= 1f) Quit();
        }
    }

    private void Quit()
    {
        Time.timeScale = 1f;
        _lobbyScene.LoadScene();
        _lastPauseChangeTime = Time.unscaledTime;
    }

}
