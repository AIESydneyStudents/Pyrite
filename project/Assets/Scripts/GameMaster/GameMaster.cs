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
    public string savedScene;


    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("StartPos") != null)
        playerStartPos = GameObject.FindGameObjectWithTag("StartPos").transform;
        if (playerLives < 0)
            SaveLoad.SeriouslyDeleteAllSaveFiles();


        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        if (playerStartPos != null)
        lastCheckPointPos = playerStartPos.position;
                    


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
