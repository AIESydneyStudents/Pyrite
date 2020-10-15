using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCollected : MonoBehaviour
{
    public int teaCount;
    public void TeaCounter()
    {
        teaCount += 1;

        Debug.Log("tea count = " + teaCount);
    }
}
