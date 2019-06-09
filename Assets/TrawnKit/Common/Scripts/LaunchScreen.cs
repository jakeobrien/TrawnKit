using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScreen : MonoBehaviour
{

    [SerializeField]
    private SceneReference _lobbyScene;
    [SerializeField]
    private TrawnButtonEvent _buttonEvent;

    private void OnEnable()
    {
        _buttonEvent.Event += OnButtonPress;
    }

    private void OnDisable()
    {
        _buttonEvent.Event -= OnButtonPress;
    }

    private void OnButtonPress(TrawnButton button, TrawnPlayer player)
    {
        if (button == TrawnButton.Menu) Application.Quit();
        else if (button == TrawnButton.Blue) StartGame();
    }

    private void StartGame()
    {
        _lobbyScene.LoadScene();
    }
}
