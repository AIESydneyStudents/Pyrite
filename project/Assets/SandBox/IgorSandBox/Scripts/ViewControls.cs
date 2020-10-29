using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ViewControls : MonoBehaviour
{
    public GameObject firstButton;
    public void SetButton()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
