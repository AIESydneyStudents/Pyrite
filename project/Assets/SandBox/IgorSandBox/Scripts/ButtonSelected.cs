using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelected : MonoBehaviour, ISelectHandler
{
    private GameObject button;

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
