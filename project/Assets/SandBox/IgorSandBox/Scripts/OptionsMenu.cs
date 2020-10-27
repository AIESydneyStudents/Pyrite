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
    //public TMP_Dropdown qualityDropdown;


    private void Start()
    {
        int CurrentResolutionIndex = 0;
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
                CurrentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //public void SetVolume(float volume)
    //{
    //    AudioMixer.SetFloat("volume", volume);
    //}


    public void SetQuality(int qualityIndex)
    {
        //qualityIndex = qualityDropdown.value;
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}