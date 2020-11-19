using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTea : MonoBehaviour
{
    public TeaTracker teaTracker;
    public int currentLeaves;
    public TeaLeafBar teaLeafBar;

    // Start is called before the first frame update
    void Start()
    {
        teaLeafBar.SetMaxLeaves(teaTracker.numberOfTeaLeaves);
    }

    // Update is called once per frame
    void Update()
    {
        teaLeafBar.SetTeaAmount(teaTracker.teaCollected);
    }

}
