using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeaImg : MonoBehaviour
{
    //public Transform startPos;
    public GameObject teaImg;
    private GameObject teaClone;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("TeaAnimSpawn");
    }

    public void SpawnTeaCollectable()
    {
        teaClone = Instantiate(teaImg);
        teaClone.transform.SetParent(canvas.transform, false);
        //teaClone.transform.position = startPos.transform.position;
        //teaClone.transform.rotation = startPos.transform.rotation;
    }
}