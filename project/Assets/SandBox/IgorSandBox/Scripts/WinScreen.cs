using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI teaScoreTxt;
    public TeaTracker teaTracker;
    //public IgorTeaCount igorTeaCount;
    public GameObject[] star;

    public int firstStarLimit;
    public int secondStarLimit;
    public int thirdStarLimit;
    

    private void Start()
    {
        //igorTeaCount = FindObjectOfType<IgorTeaCount>();
        teaTracker = FindObjectOfType<TeaTracker>();

        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
    }

    public void YouWin()
    {
       // int leavesLeft = GameObject.FindGameObjectsWithTag("TeaCollectable").Length;

        int leavesCollected = teaTracker.teaCollected;

        float percentage = (float)leavesCollected / (float)teaTracker.numberOfTeaLeaves * 100f;

        teaScoreTxt.text = "YOU WIN!";


        if(percentage >= firstStarLimit && percentage < secondStarLimit)
        {
            star[0].SetActive(true);
        }
        else if(percentage >= secondStarLimit && percentage < thirdStarLimit)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
        }
        else if(percentage == 100)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
    }
}
