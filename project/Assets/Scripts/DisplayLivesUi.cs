using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayLivesUi : MonoBehaviour
{
    public Image llHeart;
    public Image lHeart;
    public Image mHeart;
    public Image rHeart;

    public PlayerData playerData;

    // Start is called before the first frame update

    void Start()
    {
        if(playerData.PlayerLives == 3)
        {
            llHeart.enabled = true;
            lHeart.enabled = true;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (playerData.PlayerLives == 2)
        {
            llHeart.enabled = false;
            lHeart.enabled = true;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (playerData.PlayerLives == 1)
        {
            llHeart.enabled = false;
            lHeart.enabled = false;
            mHeart.enabled = true;
            rHeart.enabled = true;
        }
        if (playerData.PlayerLives == 0)
        {
            llHeart.enabled = false;
            lHeart.enabled = false;
            mHeart.enabled = false;
            rHeart.enabled = true;
        }
    }
}
