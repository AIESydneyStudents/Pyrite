using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCollected : MonoBehaviour
{
    public PlayerData playerData;

    public GameEvent teaLeafCollectedEvent;

    public GameObject teaImg;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("TeaAnimSpawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerData.teaCollected += 1;
            teaLeafCollectedEvent.Raise();
            AudioManager.instance.Play("TeaCollected");
            SpawnTeaCollectable();
        }
    }


    public void SpawnTeaCollectable()
    {
        GameObject teaClone = Instantiate(teaImg);
        teaClone.transform.SetParent(canvas.transform, false);
    }
}
