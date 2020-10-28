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

        if (gameMaster.playerLives < 0)
            playerLivesTxt.text = "Lives:" + 3;
        else
            playerLivesTxt.text = "Lives:" + gameMaster.playerLives.ToString();



    }
    private void Update()
    {
    }




}
