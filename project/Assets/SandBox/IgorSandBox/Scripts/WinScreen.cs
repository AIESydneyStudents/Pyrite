using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI teaScoreTxt;
    public TeaTracker teaTracker;
    public GameObject[] star;
    public GameObject winTeaCup;
    public GameObject winScreen;
    float teaCollected;

    public int firstStarLimit;
    public int secondStarLimit;
    public int thirdStarLimit;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    float fillRate;

    private void Start()
    { 
        slider.value = 0;
        slider.maxValue = teaTracker.numberOfTeaLeaves;
        
        fill.color = gradient.Evaluate(1f);
        teaTracker = FindObjectOfType<TeaTracker>();

        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);

        if (SceneManager.GetActiveScene().name == "Level_01")
            fillRate = 1f;

        if (SceneManager.GetActiveScene().name == "Tutorial")
            fillRate = 0.2f;

    }

    
    public void GetTeaAmount()
    {
        teaCollected = teaTracker.teaCollected;
    }


    private void FixedUpdate()
    {
        if (winScreen.activeSelf == true)
        {
            if (slider.value < teaCollected)
            {
                slider.value = slider.value + fillRate; // (teaTracker.teaCollected * Time.deltaTime);

                teaTracker.teaCollected = teaTracker.teaCollected - fillRate;
                fill.color = gradient.Evaluate(slider.normalizedValue);
                
                int teaVal = (int)slider.value;
                teaScoreTxt.text = "Leaves collected: " + teaVal.ToString();


                if (slider.value >= firstStarLimit)
                    star[0].SetActive(true);

                if (slider.value >= secondStarLimit)
                    star[1].SetActive(true);

                if (slider.value >= thirdStarLimit)
                    star[2].SetActive(true);
            }
            winTeaCup.SetActive(true);
        }
    }

    public void PlayWinSound()
    {
        AudioManager.instance.Play("WinSound");
    }
}
