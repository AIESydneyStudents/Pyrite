using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI teaScoreTxt;
    //public TeaTracker teaTracker;
    public IgorTeaCount igorTeaCount;
    public GameObject[] star;

    private void Start()
    {
        igorTeaCount = FindObjectOfType<IgorTeaCount>();

        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
    }

    public void YouWin()
    {
        teaScoreTxt.text = "YOU WIN!";
        if(igorTeaCount.myTeaLeafCount == 1)
        {
            star[0].SetActive(true);
        }
        else if(igorTeaCount.myTeaLeafCount == 2)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);

        }
        else if(igorTeaCount.myTeaLeafCount >= 3)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);

        }
    }
}
