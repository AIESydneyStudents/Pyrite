using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeaLeafBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public PlayerData PlayerData;
    public TextMeshProUGUI teaCountTxt;
    public IntSO numberOfLeaves;

    private void Awake()
    {
        numberOfLeaves.value = GameObject.FindGameObjectsWithTag("TeaCollectable").Length;
    }
    private void Start()
    {
        SetMaxLeaves(numberOfLeaves.value);
        SetTeaAmount();
    }

    public void SetMaxLeaves(float leaves)
    {
        slider.maxValue = leaves;
        slider.value = leaves;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetTeaAmount()
    {
        slider.value = PlayerData.teaCollected;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        teaCountTxt.text = PlayerData.teaCollected.ToString() + "/" + numberOfLeaves.value;
    }
}
