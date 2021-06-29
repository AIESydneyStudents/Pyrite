using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGameObjectToSetOnTrigger : MonoBehaviour
{

    public IDRuntimeSet gameObjectRuntimeSet;
    public UniqueID id;

    private void Start()
    {
        id = gameObject.GetComponent<UniqueID>();
        if (gameObjectRuntimeSet.Contains(id.ID))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObjectRuntimeSet.AddToList(id.ID);
        }
    }
}
