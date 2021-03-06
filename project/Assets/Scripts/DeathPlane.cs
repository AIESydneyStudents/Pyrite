﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private Animator anim;
    private Cinemachine.CinemachineVirtualCamera cam;

    public GameObject defaultEyes;
    public GameObject defaultMouth;
    public GameObject deathFace;

    public PlayerData playerData;

    public GameEvent saveEvent;
    public GameEvent loadEvent;





    Controls Controls
    {
        get { return ControlsManager.instance; }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody>();
        anim = player.GetComponentInChildren<Animator>();
        cam = GameObject.FindGameObjectWithTag("VirCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            AudioManager.instance.Play("DeathFromFall");
            Controls.Player.Disable();
            defaultEyes.SetActive(false);
            defaultMouth.SetActive(false);
            deathFace.SetActive(true);
            anim.Play("StarJump");
            player.transform.LookAt(cam.transform);

            StartCoroutine(WaitForSeconds());

            if (playerData.PlayerLives > 0)
            {
                Invoke("LoadCurrentScene", 3f);
                loadEvent.Raise();
                playerData.PlayerLives -= 1;
                saveEvent.Raise();
            }
            else
            {
                Invoke("LoadGameOverScene", 3f);
            }
        }
    }

    IEnumerator WaitForSeconds()
    {
        rb.velocity = new Vector3(0, 10, 0);
        player.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        cam.m_LookAt = null;
        cam.m_Follow = null;
        rb.velocity = new Vector3(0, -15, 0);
    }


    void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void LoadGameOverScene()
    {
        playerData.PlayerLives = 3;
        playerData.hasCheckpoint = false;
        playerData.canDash = false;
        playerData.canDoubleJump = false;
        playerData.canGrapple = false;
        playerData.canGroundSlam = false;
        playerData.canWallJump = false;
        playerData.jumpImg = false;
        playerData.swingImg = false;
        playerData.dashImg = false;
        saveEvent.Raise();
        SceneManager.LoadScene("GameOver");
    }
}

