using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
        teaTracker = FindObjectOfType<TeaTracker>();

        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
    }

    public void YouWin()
    {
        int leavesCollected = teaTracker.teaCollected;

        float percentage = (float)leavesCollected / (float)teaTracker.numberOfTeaLeaves * 100f;

        teaScoreTxt.text = "YOU WIN!";


        if (percentage >= firstStarLimit && percentage < secondStarLimit)
        {
            star[0].SetActive(true);
        }
        else if (percentage >= secondStarLimit && percentage < thirdStarLimit)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
        }
        else if (percentage == 100)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
    }


    private void Update()
    {
        if (winScreen.activeSelf == true)
        {
            if (slider.value < teaTracker.teaCollected)
            {
                slider.value = slider.value + (teaTracker.teaCollected * Time.deltaTime);
                fill.color = gradient.Evaluate(slider.normalizedValue);
            }
        }
    }
}
