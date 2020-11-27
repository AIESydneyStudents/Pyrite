using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{

    private GameObject[] modelList;

    int currentModelIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentModelIndex = 0;
        modelList = GameObject.FindGameObjectsWithTag("Model");
        for (int i = 0; i < modelList.Length; i++)
        {
            modelList[i].SetActive(false);
        }
        modelList[currentModelIndex].SetActive(true);
    }


    public void NextModel()
    {
        if (currentModelIndex == modelList.Length - 1)
        {
            modelList[currentModelIndex].SetActive(false);
            currentModelIndex = 0;
            modelList[currentModelIndex].SetActive(true);
        }
        else
        {
            modelList[currentModelIndex].SetActive(false);
            currentModelIndex++;
            modelList[currentModelIndex].SetActive(true);
        }

    }

    public void PrevModel()
    {
        if (currentModelIndex == 0)
        {
            modelList[currentModelIndex].SetActive(false);
            currentModelIndex = modelList.Length - 1;
            modelList[currentModelIndex].SetActive(true);
        }
        else
        {
            modelList[currentModelIndex].SetActive(false);
            currentModelIndex--;
            modelList[currentModelIndex].SetActive(true);
        }
    }
}
