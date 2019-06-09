using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TrawnButtonKey
{
    public TrawnPlayer player;
    public TrawnButton button;
    public string key;
}

[CreateAssetMenu(menuName="Common/TrawnInputKeys")]
public class TrawnInputKeys : DontUnloadScriptableObject
{

    public TrawnButtonKey[] ButtonKeys { get; private set; }
    private Dictionary<TrawnPlayer, Dictionary<TrawnButton, string>> _keyLookup;
    private Dictionary<TrawnPlayer, Dictionary<InputAxis, string>> _axisLookup;

    protected override void OnEnable()
    {
        base.OnEnable();
        SetupButtonInfos();
        SetupAxisInfos();
    }

    private void SetupButtonInfos()
    {
        var buttons = Enum.GetValues(typeof(TrawnButton));
        var players = Enum.GetValues(typeof(TrawnPlayer));
        var keys = new List<TrawnButtonKey>();
        _keyLookup = new Dictionary<TrawnPlayer, Dictionary<TrawnButton, string>>();
        foreach (TrawnPlayer player in players)
        {
            _keyLookup[player] = new Dictionary<TrawnButton, string>();
            foreach (TrawnButton button in buttons)
            {
                if (button == TrawnButton.Menu || player == TrawnPlayer.None) continue;
                var n = string.Format("P{0}-Btn{1}", (int)player, button);
                keys.Add(new TrawnButtonKey() { player = player, button = (TrawnButton)button, key = n });
                _keyLookup[player][button] = n;
            }
        }
        ButtonKeys = keys.ToArray();
    }

    private void SetupAxisInfos()
    {
        var axes = Enum.GetValues(typeof(InputAxis));
        var players = Enum.GetValues(typeof(TrawnPlayer));
        _axisLookup = new Dictionary<TrawnPlayer, Dictionary<InputAxis, string>>();
        foreach (TrawnPlayer player in players)
        {
            _axisLookup[player] = new Dictionary<InputAxis, string>();
            foreach (InputAxis axis in axes)
            {
                var n = string.Format("P{0}-{1}", (int)player, GetAxisKey(axis));
                _axisLookup[player][axis] = n;
            }
        }
    }

    public string GetKey(TrawnButton button, TrawnPlayer player = TrawnPlayer.None)
    {
        if (button == TrawnButton.Menu) return "Cancel";
        if (_keyLookup == null) return null;
        if (!_keyLookup.ContainsKey(player)) return null;
        if (_keyLookup[player] == null) return null;
        if (!_keyLookup[player].ContainsKey(button)) return null;
        return _keyLookup[player][button];
    }

    public string GetAxisKey(InputAxis axis, TrawnPlayer player)
    {
        if (_axisLookup == null) return null;
        if (!_axisLookup.ContainsKey(player)) return null;
        if (_axisLookup[player] == null) return null;
        if (!_axisLookup[player].ContainsKey(axis)) return null;
        return _axisLookup[player][axis];
    }

    private string GetAxisKey(InputAxis axis)
    {
        switch (axis)
        {
            case InputAxis.Horizontal: return "Horizontal";
            case InputAxis.Vertical: return "Vertical";
        }
        return null;
    }
}
