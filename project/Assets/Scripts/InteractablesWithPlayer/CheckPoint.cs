using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public PlayerData playerData;
    public GameEvent saveEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerData.respawnPosX = transform.position.x;
            playerData.respawnPosY = transform.position.y;
            playerData.respawnPosZ = transform.position.z;

            playerData.hasCheckpoint = true;

            playerData.savedScene = SceneManager.GetActiveScene().name;

            saveEvent.Raise();
            AudioManager.instance.Play("CheckPoint");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
