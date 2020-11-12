using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public ParticleSystem partSys;
    public GameObject button;
    public EventSystem eventSys;
    

    public void OnSelect(BaseEventData eventData)
    {
        if (eventSys.currentSelectedGameObject == button)
        {
            partSys.Play();
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (eventSys.currentSelectedGameObject == button)
        {
            partSys.Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        partSys.Stop();
    }

}
