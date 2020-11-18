﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTea : MonoBehaviour
{
    public TeaTracker teaTracker;
   // public int maxLeaves = 100;
   // public int minLeaves = 0;
    public int currentLeaves;
    public TeaLeafBar teaLeafBar;

    // Start is called before the first frame update
    void Start()
    {
        //currentLeaves = minLeaves;
        teaLeafBar.SetMaxLeaves(teaTracker.numberOfTeaLeaves);
        //teaLeafBar.SetTeaAmount(minLeaves);
    }

    // Update is called once per frame
    void Update()
    {
        //currentLeaves = teaTracker.numberOfTeaLeaves;
        teaLeafBar.SetTeaAmount(teaTracker.teaCollected);
    }

    //public void CollectTeaLeaf(int leaves)
    //{
    //    currentLeaves += leaves;

    //    teaLeafBar.SetTeaAmount(currentLeaves);
    //}
}
