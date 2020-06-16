using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameSaveInfo data = new GameSaveInfo(player);

        bf.Serialize(stream, data);
        stream.Close();

    }

    public static GameSaveInfo LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            BinaryFormatter bs = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameSaveInfo data = bs.Deserialize(stream) as GameSaveInfo;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}


