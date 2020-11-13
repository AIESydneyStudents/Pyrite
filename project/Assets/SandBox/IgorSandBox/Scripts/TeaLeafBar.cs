using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaLeafBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxLeaves(int leaves)
    {
        slider.maxValue = leaves;
        slider.value = leaves;
    }

    public void SetTeaAmount(int leaves)
    {
        slider.value = leaves;
    }
}
