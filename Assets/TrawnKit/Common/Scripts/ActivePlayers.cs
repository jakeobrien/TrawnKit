using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ActivePlayers")]
public class ActivePlayers : ScriptableObject
{

    public const int MaxNumber = 4;

    [SerializeField]
    private IntArrayVariable _playerIndices;
    [SerializeField]
    private PlayerInfos _playerInfos;

    public int NumberPlayers { get { return _playerIndices.Value.Length; } }

    public PlayerInfo[] GetActivePlayers()
    {
        if (_playerIndices == null)
        {
            Debug.LogError("no player indices set");
            return null;
        }
        if (_playerInfos == null)
        {
            Debug.LogError("no player infos set");
            return null;
        }
        if (NumberPlayers == 0)
        {
            Debug.LogError("zero players");
            return null;
        }
        var infos = new PlayerInfo[NumberPlayers];
        var i = 0;
        for (var p = 0; p < MaxNumber; p++)
        {
            if (System.Array.IndexOf<int>(_playerIndices.Value, p) >= 0)
            {
                infos[i] = _playerInfos.GetInfo((TrawnPlayer)p);
                i++;
            }
        }
        return infos;
    }

}
