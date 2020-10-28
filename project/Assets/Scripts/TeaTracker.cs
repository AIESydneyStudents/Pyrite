using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeaTracker : MonoBehaviour
{
    public int teaCollected;
    public PlayerData data;
    public TextMeshProUGUI teaCountTxt;
    private GameMaster gameMaster;
    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        Load();
        teaCountTxt.text = "Tea Collected : " + teaCollected.ToString();
    }
    private void Update()
    {
        teaCountTxt.text = "Tea : " + teaCollected.ToString() + "/" + gameMaster.numberOfTeaLeaves;
    }
    void Load()
    {
        if (SaveLoad.SaveExists("PlayerData"))
        {
            data = SaveLoad.Load<PlayerData>("PlayerData");
            teaCollected = data.teaCollected;
        }
    }
}
