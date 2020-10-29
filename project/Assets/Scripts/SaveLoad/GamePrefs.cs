using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrefs
{

    public static bool IsFullscreen
    {
        get
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference", 0));
        }
        set
        {
            PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(value));
        }
    }

}
