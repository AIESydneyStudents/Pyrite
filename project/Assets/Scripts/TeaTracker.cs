using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeaTracker : MonoBehaviour
{
    public int teaCollected;
    public PlayerData data;
    public TextMeshProUGUI teaCountTxt;

    private void Start()
    {
        Load();
        teaCountTxt.text = "Tea Collected : " + teaCollected.ToString();
    }
    private void Update()
    {
        teaCountTxt.text = "Tea Collected : " + teaCollected.ToString();
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
