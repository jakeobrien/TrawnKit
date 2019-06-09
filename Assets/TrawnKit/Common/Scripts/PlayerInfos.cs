using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Common/PlayerInfos")]
public class PlayerInfos : DontUnloadScriptableObject
{

    [SerializeField]
    private PlayerInfo[] _playerInfos;

    public PlayerInfo GetInfo(TrawnPlayer player)
    {
        foreach (var info in _playerInfos)
        {
            if (info.player == player) return info;
        }
        return null;
    }

    public Color GetColor(TrawnPlayer player)
    {
        var info = GetInfo(player);
        if (info == null) return Color.white;
        return info.color;
    }

    public string GetName(TrawnPlayer player)
    {
        var info = GetInfo(player);
        if (info == null) return "";
        return info.name;
    }

    public int GetScore(TrawnPlayer player)
    {
        var info = GetInfo(player);
        if (info == null) return 0;
        return info.score;
    }

}
