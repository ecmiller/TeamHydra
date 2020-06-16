using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class GameSaveInfo
{
    //public int currentScene;
    public int playerHealth;
    public float[] position;
    public GameSaveInfo(Player player)
    {
        //currentScene = player.savedLevel;
        playerHealth = player.health;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
