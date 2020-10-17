using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField]
    private CollectibleItemSet collectibleItemSet;
    private UniqueID uniqueID;

    // Start is called before the first frame update
    void Start()
    {
        uniqueID = GetComponent<UniqueID>();
        collectibleItemSet = FindObjectOfType<CollectibleItemSet>();
        if (collectibleItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleItemSet.CollectedItems.Add(uniqueID.ID);
            Destroy(gameObject);
        }
    }
}