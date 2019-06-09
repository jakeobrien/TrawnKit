using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[CreateAssetMenu(menuName="Common/TrawnInput")]
public class TrawnInput : ScriptableObject
{

    [SerializeField]
    private TrawnInputKeys _inputKeys;

    public bool GetButtonDown(TrawnButton button, TrawnPlayer player = TrawnPlayer.None)
    {
        var key = _inputKeys.GetKey(button, player);
        if (key == null) return false;
        return Input.GetButtonDown(key);
    }

    public bool GetButtonUp(TrawnButton button, TrawnPlayer player = TrawnPlayer.None)
    {
        var key = _inputKeys.GetKey(button, player);
        if (key == null) return false;
        return Input.GetButtonUp(key);
    }

    public bool GetButton(TrawnButton button, TrawnPlayer player = TrawnPlayer.None)
    {
        var key = _inputKeys.GetKey(button, player);
        if (key == null) return false;
        return Input.GetButton(key);
    }

    public Vector2 GetStickInput(TrawnPlayer player)
    {
        return new Vector2(GetAxis(InputAxis.Horizontal, player),
                           GetAxis(InputAxis.Vertical, player));
    }

    public float GetAxis(InputAxis axis, TrawnPlayer player)
    {
        return Input.GetAxis(_inputKeys.GetAxisKey(axis, player));
    }

}
