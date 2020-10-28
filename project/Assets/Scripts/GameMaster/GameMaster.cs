using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    public int playerLives;
    public PlayerData data;
    public Transform playerStartPos;

    public int numberOfTeaLeaves;


    private void Awake()
    {      
        if (playerLives < 0)
            SaveLoad.SeriouslyDeleteAllSaveFiles();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        lastCheckPointPos = playerStartPos.position;

        numberOfTeaLeaves = GameObject.FindGameObjectsWithTag("TeaCollectable").Length;
        Debug.Log(numberOfTeaLeaves);

        Load();
    }

    //loads playerData file and passes its value into player lives
    void Load()
    {
        if (SaveLoad.SaveExists("PlayerData"))
        {
            data = SaveLoad.Load<PlayerData>("PlayerData");
            playerLives = data.PlayerLives;
        }
    }

}
