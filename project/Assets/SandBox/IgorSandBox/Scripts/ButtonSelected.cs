using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonSelected : MonoBehaviour, ISelectHandler
{
    public ParticleSystem partSys;
    public GameObject but;
    public EventSystem eventSys;

    public void OnSelect(BaseEventData eventData)
    {
        if (eventSys.currentSelectedGameObject == but)
        {
            partSys.Play();

        }
        
        //if(eventData.selectedObject == this)
        //Debug.Log(this.gameObject.name + " was selected");

    }

    // Start is called before the first frame update
    void Start()
    {
        partSys.Stop();
    }

    // Update is called once per frame
    void Update()
    {



    }
}
