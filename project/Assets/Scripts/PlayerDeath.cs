using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private GameMaster gameMaster;
    private GameObject player;
    private PlayerMovement playerMovement;
    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void Death()
    {
        if (playerMovement.isDashing == false)
        {
            gameMaster.playerLives -= 1;
            player.SetActive(false);
            Invoke("LoadCurrentScene", 2f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player && playerMovement.isDashing == false)
    //    {
    //        gameMaster.playerLives -= 1;
    //        player.SetActive(false);
    //        Invoke("LoadCurrentScene", 2f);
    //    }
    //    else
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
    void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
