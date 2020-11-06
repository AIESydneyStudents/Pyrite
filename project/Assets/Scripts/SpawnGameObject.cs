using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{

    public void SpawnObj(GameObject objToSpawn)
    {
        Instantiate(objToSpawn, gameObject.transform.position, Quaternion.identity);
    }

}
