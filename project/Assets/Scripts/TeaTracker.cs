﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeaTracker : MonoBehaviour
{
    public int teaCollected;
    public PlayerData data;
    public TextMeshProUGUI teaCountTxt;

    public int numberOfTeaLeaves;

    private void Start()
    {
        Load();
        teaCountTxt.text = "Tea Collected : " + teaCollected.ToString();
        numberOfTeaLeaves = GameObject.FindGameObjectsWithTag("TeaCollectable").Length;
    }
    private void Update()
    {
        teaCountTxt.text = "Tea : " + teaCollected.ToString() + "/" + numberOfTeaLeaves;
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
