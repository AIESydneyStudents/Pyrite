using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayLivesUi : MonoBehaviour
{
    private GameMaster gameMaster;
    public TextMeshProUGUI playerLivesTxt;
    // Start is called before the first frame update

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();


        playerLivesTxt.text = "Lives:" + gameMaster.playerLives.ToString();



    }




}
