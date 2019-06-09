using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LobbyPlayerMenu : MonoBehaviour
{

    public event Action OnJoin;
    public event Action OnUnjoin;

    [SerializeField]
    private TrawnButtonEvent _buttonEvent;
    [SerializeField]
    private int _playerIndex;
    [SerializeField]
    private GameObject _joinedObject;
    [SerializeField]
    private GameObject _unjoinedObject;
    private bool _hasJoined;

    public int PlayerIndex { get { return _playerIndex; } }

    public bool HasJoined { get { return _hasJoined; } }

    private void OnEnable()
    {
        LayoutForJoined();
        _buttonEvent.Event += OnButtonPress;
    }

    private void OnDisable()
    {
        _buttonEvent.Event -= OnButtonPress;
    }

    private void OnButtonPress(TrawnButton button, TrawnPlayer player)
    {
        if ((int)player != _playerIndex) return;
        if (!TrawnButtonHelper.IsActionButton(button)) return;
        if (!_hasJoined)
        {
            Join();
        }
        else if (button == TrawnButton.Green)
        {
            Unjoin();
        }
    }

    public void Join()
    {
        _hasJoined = true;
        LayoutForJoined();
        if (OnJoin != null) OnJoin();
    }

    public void Unjoin()
    {
        _hasJoined = false;
        LayoutForJoined();
        if (OnUnjoin != null) OnUnjoin();
    }

    private void LayoutForJoined()
    {
        _joinedObject.SetActive(_hasJoined);
        _unjoinedObject.SetActive(!_hasJoined);
    }

}
