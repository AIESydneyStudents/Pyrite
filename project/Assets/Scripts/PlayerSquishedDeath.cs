using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSquishedDeath : MonoBehaviour
{
    public bool touchingWall1;
    public bool touchingWall2;




    private void Update()
    {
        if (touchingWall1 == true && touchingWall2 == true)
        {
            //gameMaster.playerLives -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void SetTouchingWall1True()
    {
        touchingWall1 = true;
    }
    public void SetTouchingWall1False()
    {
        touchingWall1 = false;
    }

    public void SetTouchingWall2True()
    {
        touchingWall2 = true;
    }
    public void SetTouchingWall2False()
    {
        touchingWall2 = false;
    }
}
