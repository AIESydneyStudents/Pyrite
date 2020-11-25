using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetFirstButton : MonoBehaviour
{
    public GameObject firstButton;
    public void SetButton()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    private void Update()
    {
       if( EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
