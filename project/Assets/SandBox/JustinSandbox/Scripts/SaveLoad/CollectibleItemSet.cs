using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemSet : MonoBehaviour
{
    private GameMaster gameMaster;
    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();

    private void Awake()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        GameEvents.SaveInitiated += Save;
    

        if (gameMaster.playerLives < 0)
            SaveLoad.SeriouslyDeleteAllSaveFiles();
        Load();
        Debug.Log("LOAD");
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
            Debug.Log(CollectedItems.Count);
        }
        else
            CollectedItems.Clear();
    }
}