using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <SavePlayerData>
/// saves player Pos data into gamemasters last savePoint so player starts at last save point even if game is exited.
public class SaveLoadGameData : MonoBehaviour
{
    private GameMaster gameMaster;
    public TeaTracker teaTracker;
    public PlayerData data;
    public PlayerMovement playerMovement;
    private GameObject player;
    public Transform startpos;

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        teaTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeaTracker>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        GameEvents.SaveInitiated += Save;
        Load();

        if (gameMaster.playerLives < 0)
        {
            DeleteFiles();
            gameMaster.playerLives = 3;
            teaTracker.teaCollected = 0;
        }
    }

    private void Start()
    {
        if (!SaveLoad.SaveExists("PlayerData"))
        {
            SetPowerUpsFalse();

            gameMaster.lastCheckPointPos = startpos.position;
            player.transform.position = gameMaster.lastCheckPointPos;
        }
        else if (gameMaster.playerLives >= 0)
        {
            player.transform.position = gameMaster.lastCheckPointPos;
        }
    }


    void Save()
    {
        data = new PlayerData(gameMaster, teaTracker, playerMovement);
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

            playerMovement.canDoubleJump = data.canDoubleJump;
            playerMovement.canSlide = data.canSlide;
            playerMovement.canGlide = data.canGlide;
            playerMovement.canDash = data.canDash;
            playerMovement.canSpin = data.canSpin;
            playerMovement.canWallJump = data.canWallJump;
            playerMovement.canGroundSlam = data.canGroundSlam;
            playerMovement.canGrapple = data.canGrapple;
        }
    }
    void SetPowerUpsFalse()
    {
        playerMovement.canDoubleJump = false;
        playerMovement.canSlide = false;
        playerMovement.canGlide = false;
        playerMovement.canDash = false;
        playerMovement.canSpin = false;
        playerMovement.canWallJump = false;
        playerMovement.canGroundSlam = false;
        playerMovement.canGrapple = false;
    }
    public void DeleteFiles()
    {
        SaveLoad.SeriouslyDeleteAllSaveFiles();
    }
}
