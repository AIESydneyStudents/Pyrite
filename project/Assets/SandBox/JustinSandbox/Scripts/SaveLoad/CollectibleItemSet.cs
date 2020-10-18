using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <CollectibleItemSet>
/// Saves or loads all the items picked up that are in the collected items hash list.
public class CollectibleItemSet : MonoBehaviour
{
    private GameMaster gameMaster;
    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();


        if (gameMaster.playerLives < 0)
            SaveLoad.SeriouslyDeleteAllSaveFiles();

        GameEvents.SaveInitiated += Save;
        Load();
    }


    void Save()
    {
        SaveLoad.Save(CollectedItems, "CollectedItems");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("CollectedItems"))
        {
            CollectedItems = SaveLoad.Load<HashSet<string>>("CollectedItems");
        }
        else
            CollectedItems.Clear();
    }
}