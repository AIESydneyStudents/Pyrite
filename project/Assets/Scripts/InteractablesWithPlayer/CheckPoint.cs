using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gameMaster;
    public PlayerData data;
    private GameObject playerBody;

    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameMaster.savedScene = SceneManager.GetActiveScene().name;
            gameMaster.lastCheckPointPos = transform.position;
            gameMaster.playerBodySize = playerBody.transform.localScale.z;
            GameEvents.OnSaveInitiated();
            data = SaveLoad.Load<PlayerData>("PlayerData");
            AudioManager.instance.Play("CheckPoint");
        }
    }
}
