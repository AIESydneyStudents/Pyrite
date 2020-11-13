using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class OptionsMenu : MonoBehaviour
{
    //public AudioMixer AudioMixer;
    Resolution[] resolutions;
    public Toggle fullScreenToggleBtn;
    public TMP_Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public GameObject firstButton;


    private void Start()
    {
        SetButton();

        List<string> options = new List<string>();

        fullScreenToggleBtn.isOn = GamePrefs.IsFullscreen;

        LoadSettings();
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        GamePrefs.IsFullscreen = isFullscreen;
    }


    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 5;
        
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
      
    }

    public void SetButton()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}