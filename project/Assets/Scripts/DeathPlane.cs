using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private GameMaster gameMaster;
    private GameObject player;
    private void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            AudioManager.instance.Play("DeathFromFall");
            gameMaster.playerLives -= 1;
            player.SetActive(false);
            if (gameMaster.playerLives >= 0)
                Invoke("LoadCurrentScene", 2f);
            else
                Invoke("LoadGameOverScene", 2f);
        }
    }
    void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
