using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <SavePlayerData>
/// saves player Pos data into gamemasters last savePoint so player starts at last save point even if game is exited.
public class SavePlayerData : MonoBehaviour
{
    private GameMaster gameMaster;
    public PlayerData data;

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        GameEvents.SaveInitiated += Save;
        Load();
    }


    void Save()
    {
        data = new PlayerData(gameMaster);
        SaveLoad.Save(data, "PlayerData");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("PlayerData"))
        {
            data = SaveLoad.Load<PlayerData>("PlayerData");
            gameMaster.lastCheckPointPos.x = data.respawnPos[0];
            gameMaster.lastCheckPointPos.y = data.respawnPos[1];
            gameMaster.lastCheckPointPos.z = data.respawnPos[2];
        }
    }
}
