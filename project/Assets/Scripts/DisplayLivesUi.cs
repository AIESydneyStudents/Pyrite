using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayLivesUi : MonoBehaviour
{
    private GameMaster gameMaster;
    // public TextMeshProUGUI playerLivesTxt;
    public Image llHeart;
    public Image lHeart;
    public Image mHeart;
    public Image rHeart;

    // Start is called before the first frame update

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        if(gameMaster.playerLives == 3)
        {
            llHeart.enabled = true;
            lHeart.enabled = true;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (gameMaster.playerLives == 2)
        {
            llHeart.enabled = false;
            lHeart.enabled = true;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (gameMaster.playerLives == 1)
        {
            llHeart.enabled = false;
            lHeart.enabled = false;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (gameMaster.playerLives == 0)
        {
            llHeart.enabled = false;
            lHeart.enabled = false;
            mHeart.enabled = false;
            rHeart.enabled = true;
        }

      //  playerLivesTxt.text = gameMaster.playerLives.ToString();

    }




}
