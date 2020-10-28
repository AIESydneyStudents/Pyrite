using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //public AudioMixer AudioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;


    private void Start()
    {
        int currentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height + ": " + resolutions[i].refreshRate + "Hz";
            options.Add(Option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height && 
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPreference",
                   resolutionDropdown.value);
    }

    //public void SetVolume(float volume)
    //{
    //    AudioMixer.SetFloat("volume", volume);
    //}


    public void SetQuality(int qualityIndex)
    {
        //qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
        //qualityDropdown.value = qualityIndex;
        PlayerPrefs.SetInt("QualitySettingPreference",
                   qualityDropdown.value);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("FullscreenPreference",
                   Convert.ToInt32(Screen.fullScreen));

    }

    //public void SaveSettings()
    //{
    //    PlayerPrefs.SetInt("QualitySettingPreference",
    //               qualityDropdown.value);

    //    PlayerPrefs.SetInt("ResolutionPreference",
    //               resolutionDropdown.value);
        
        
    //    PlayerPrefs.SetInt("FullscreenPreference",
    //               Convert.ToInt32(Screen.fullScreen));
        
    //}

    public void LoadSettings(int currentResIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 5;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResIndex;
        
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
      
    }

}