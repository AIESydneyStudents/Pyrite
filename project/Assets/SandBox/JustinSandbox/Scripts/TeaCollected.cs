using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCollected : MonoBehaviour
{
    public int teaCount = 0;

    public void TeaCounter()
    {
        teaCount += 1;

        Debug.Log("tea count = " + teaCount);
    }
}
