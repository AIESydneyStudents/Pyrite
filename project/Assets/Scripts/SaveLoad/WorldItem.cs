using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <WorldItem>
/// checks if item exists in collectedItemSet(Saved bin file). if exists deletes the gameObject so it cannot be collected again.
public class WorldItem : MonoBehaviour
{
    private CollectibleItemSet collectibleItemSet;
    private UniqueID uniqueID;

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

    /// <AddsItemToCollectedItemSet>
    public void AddToCollectedItemSet()
    {
        collectibleItemSet.CollectedItems.Add(uniqueID.ID);
    }

}