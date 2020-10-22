using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


/// <SaveLoad>
/// Handles everything to do with saving and loading takes in a type and file name.
public class SaveLoad : MonoBehaviour
{
    //saves file of given type into binary file
    public static void Save<T>(T objectToSave, string fileName)
    {
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path + fileName + ".txt", FileMode.Create))
        {
            formatter.Serialize(fileStream, objectToSave);
        }
    }

    //loads file of given type and returns its values
    public static T Load<T>(string fileName)
    {
        string path = Application.persistentDataPath + "/saves/";
        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream fileStream = new FileStream(path + fileName + ".txt", FileMode.Open))
        {
            returnValue = (T)formatter.Deserialize(fileStream);
        }
        return returnValue;
    }

    //checks if a file exists with given "fileName"
    public static bool SaveExists(string fileName)
    {
        string path = Application.persistentDataPath + "/saves/" + fileName + ".txt";
        return File.Exists(path);
    }

    //Deletes all files in saves file
    public static void SeriouslyDeleteAllSaveFiles()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }
}
