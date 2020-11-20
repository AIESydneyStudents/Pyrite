using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaLeafBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxLeaves(float leaves)
    {
        slider.maxValue = leaves;
        slider.value = leaves;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetTeaAmount(float leaves)
    {
        slider.value = leaves;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
