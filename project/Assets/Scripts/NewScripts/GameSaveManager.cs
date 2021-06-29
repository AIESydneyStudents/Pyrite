using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{
    public PlayerData playerData;
    public IDRuntimeSet teaRuntimeSet;

    private void Awake()
    {       
        if (playerData.savedScene == "")
            playerData.savedScene = "Tutorial";

        if (!playerData.hasCheckpoint)
        {
            playerData.teaCollected = 0;
            teaRuntimeSet.Initialize();
        }
    }

    public void SaveData()
    {
        SaveGame(playerData, "PlayerData");
        SaveGame(teaRuntimeSet, "PlayerTeaRuntimeSet");
    }

    public void LoadData()
    {
        LoadGame(playerData, "PlayerData");
        LoadGame(teaRuntimeSet, "PlayerTeaRuntimeSet");
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public bool DoesSaveFileExist(string fileName)
    {
        return (File.Exists(Application.persistentDataPath + "/game_save/" + fileName + ".txt"));
    }


    public void SaveGame<T>(T objectToSave, string fileName)
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_save/" + fileName + ".txt");
        var json = JsonUtility.ToJson(objectToSave);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame<T>(T objectToLoad, string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/game_save/" + fileName + ".txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/" + fileName + ".txt", FileMode.Open);
            Debug.Log("file open");
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectToLoad);
            file.Close();
            Debug.Log("file close");

        }
    }
}
