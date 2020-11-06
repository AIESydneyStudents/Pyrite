using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public void Destroy(float destroyAfterXSeconds)
    {
        Destroy(gameObject,destroyAfterXSeconds);
    }
}
