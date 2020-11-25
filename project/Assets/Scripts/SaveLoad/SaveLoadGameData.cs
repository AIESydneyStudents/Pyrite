using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <SavePlayerData>
/// saves player Pos data into gamemasters last savePoint so player starts at last save point even if game is exited.
public class SaveLoadGameData : MonoBehaviour
{
    private GameMaster gameMaster;
    public TeaTracker teaTracker;
    public PlayerData data;
    private PlayerMovement playerMovement;
    private GameObject player;
    public Transform startpos;

    private GameObject playerBody;

    private GameObject playerString;

    [SerializeField] Material stringMaterial;

    public GameObject jumpImg;
    public GameObject swingImg;
    public GameObject dashImg;


    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        teaTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeaTracker>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerString = GameObject.FindGameObjectWithTag("PlayerTeaString");

        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
       

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

            playerBody.transform.localScale = new Vector3(15, 15, 15);

            gameMaster.lastCheckPointPos = startpos.position;
            player.transform.position = gameMaster.lastCheckPointPos;

            playerString.GetComponent<Renderer>().material = stringMaterial;
        }
        else if (gameMaster.playerLives >= 0)
        {
            player.transform.position = gameMaster.lastCheckPointPos;
        }
    }

    private void Update()
    {
        if (playerMovement.jumpImg == true)
            jumpImg.SetActive(true);
        else
            jumpImg.SetActive(false);

        if (playerMovement.swingImg == true)
            swingImg.SetActive(true);
        else
            swingImg.SetActive(false);

        if (playerMovement.dashImg == true)
            dashImg.SetActive(true);
        else
            dashImg.SetActive(false);
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


            gameMaster.savedScene = data.savedScene;

            playerMovement.canDoubleJump = data.canDoubleJump;
            playerMovement.canSlide = data.canSlide;
            playerMovement.canGlide = data.canGlide;
            playerMovement.canDash = data.canDash;
            playerMovement.canSpin = data.canSpin;
            playerMovement.canWallJump = data.canWallJump;
            playerMovement.canGroundSlam = data.canGroundSlam;
            playerMovement.canGrapple = data.canGrapple;

            playerMovement.jumpImg = data.jumpImg;
            playerMovement.swingImg = data.swingImg;
            playerMovement.dashImg = data.dashImg;

            playerString.GetComponent<Renderer>().material = gameMaster.material;
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

        playerMovement.jumpImg = false;
        playerMovement.swingImg = false;
        playerMovement.dashImg = false;
    }
    public void DeleteFiles()
    {
        SaveLoad.SeriouslyDeleteAllSaveFiles();
    }
}
