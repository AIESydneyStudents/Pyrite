using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI teaScoreTxt;
    public TeaTracker teaTracker;
    public GameObject[] star;
    public GameObject winScreen;
    

    public int firstStarLimit;
    public int secondStarLimit;
    public int thirdStarLimit;

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    { 
        slider.value = 0;
        slider.maxValue = teaTracker.numberOfTeaLeaves;
        fill.color = gradient.Evaluate(1f);
        teaTracker = FindObjectOfType<TeaTracker>();

        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
    }

    //IEnumerator ShowStars()
    //{
    //    int leavesCollected = teaTracker.teaCollected;

    //    if (leavesCollected >= firstStarLimit && leavesCollected < secondStarLimit)
    //    {
           
    //            star[0].SetActive(true);
            
    //    }
    //    else if (leavesCollected >= secondStarLimit && leavesCollected <= thirdStarLimit)
    //    {
    //        star[0].SetActive(true);
    //        yield return new WaitForSeconds(1.0f);
    //        star[1].SetActive(true);
    //    }
    //    else if (leavesCollected == teaTracker.numberOfTeaLeaves)
    //    {
    //        star[0].SetActive(true);
    //        yield return new WaitForSeconds(1.0f);

    //        star[1].SetActive(true);
    //        yield return new WaitForSeconds(1.0f);

    //        star[2].SetActive(true);
    //        yield return new WaitForSeconds(1.0f);

    //    }
    //}



    private void FixedUpdate()
    {
        if (winScreen.activeSelf == true)
        {
            if (slider.value < teaTracker.teaCollected)
            {
                slider.value = slider.value + 0.2f; // (teaTracker.teaCollected * Time.deltaTime);
                fill.color = gradient.Evaluate(slider.normalizedValue);
                int val = (int)slider.value;
                teaScoreTxt.text = "Leaves collected: " + val.ToString();

                //if (slider.value >= teaTracker.teaCollected)
                //{
                //    StartCoroutine(ShowStars());
                //}

                if (slider.value >= firstStarLimit)
                    star[0].SetActive(true);
                if (slider.value >= secondStarLimit)
                    star[1].SetActive(true);
                if (slider.value >= thirdStarLimit)
                    star[2].SetActive(true);
            }
            
        }
    }
}
