using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTeaScore : MonoBehaviour
{
    private TeaTracker teaTracker;
    private void Start()
    {
        teaTracker = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TeaTracker>();
    }

    public void IncreaseTeaScoreOnPickup()
    {
        teaTracker.teaCollected += 1;
    }

}
