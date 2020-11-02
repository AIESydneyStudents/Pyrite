using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTeaScore : MonoBehaviour
{
    private TeaTracker teaTracker;
    private GameObject playerBody;
    Vector3 scaleChange;
    public float PlayerScaleValue;
    private void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
        teaTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeaTracker>();
        scaleChange = new Vector3(0, 0, PlayerScaleValue);
    }

    public void IncreaseTeaScoreOnPickup()
    {
        if (teaTracker != null)
        {
            playerBody.transform.localScale += scaleChange;
            teaTracker.teaCollected += 1;
            AudioManager.instance.Play("TeaCollected");
        }

    }

}
