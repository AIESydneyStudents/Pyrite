using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <GameEvents>
/// allows other scripts to save on an event
public class GameEvents : MonoBehaviour
{
    public static System.Action SaveInitiated;

    public static void OnSaveInitiated()
    {
        if (SaveInitiated != null)
        SaveInitiated.Invoke();
    }
}
