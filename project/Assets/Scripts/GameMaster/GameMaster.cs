using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    public int playerLives;
    public PlayerData data;
    public Transform playerStartPos;
    public string savedScene;
    public float playerBodySize;
    public Material material;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if(GameObject.FindGameObjectWithTag("StartPos") != null)
        playerStartPos = GameObject.FindGameObjectWithTag("StartPos").transform;


        savedScene = "Tutorial";

        if (playerLives < 0)
        {
            savedScene = SceneManager.GetActiveScene().name;
            SaveLoad.SeriouslyDeleteAllSaveFiles();
        }

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
            savedScene = data.savedScene;           
        }
    }

}
