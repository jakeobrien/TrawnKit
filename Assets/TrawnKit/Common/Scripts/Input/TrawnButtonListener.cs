using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrawnButtonListener : MonoBehaviour
{

    [SerializeField]
    private bool _listenForDown = true;
    [SerializeField]
    private bool _listenForUp;
    [SerializeField]
    private TrawnButtonEvent _buttonDownEvent;
    [SerializeField]
    private TrawnButtonEvent _buttonUpEvent;
    [SerializeField]
    private TrawnInputKeys _inputKeys;

    private void Update()
    {
        if (_buttonDownEvent == null) return;
        if (_listenForDown && Input.GetButtonDown(_inputKeys.GetKey(TrawnButton.Menu))) _buttonDownEvent.Fire(TrawnButton.Menu, TrawnPlayer.None);
        if (_listenForUp && Input.GetButtonUp(_inputKeys.GetKey(TrawnButton.Menu))) _buttonUpEvent.Fire(TrawnButton.Menu, TrawnPlayer.None);
        foreach (var key in _inputKeys.ButtonKeys)
        {
            if (_listenForDown && Input.GetButtonDown(key.key))
            {
                _buttonDownEvent.Fire(key.button, key.player);
            }
            if (_listenForUp && Input.GetButtonUp(key.key))
            {
                _buttonUpEvent.Fire(key.button, key.player);
            }
        }
    }

}
