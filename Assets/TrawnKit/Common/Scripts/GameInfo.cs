using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Launcher/GameInfo")]
public class GameInfo : ScriptableObject
{

    public string gameName;
    public SceneReference sceneToLoad;
    public int minNumberPlayers;
    public int maxNumberPlayers;
    public bool showScores;
    public string[] instructions;

}
