using System.Collections;
using UnityEngine;
using System;


public static class PlayersQuery
{

    public static bool IsPlayerActive(TrawnPlayer player, IntArrayVariable currentPlayers)
    {
        var i = (int)player;
        return Array.IndexOf(currentPlayers.Value, i) >= 0;
    }

}
