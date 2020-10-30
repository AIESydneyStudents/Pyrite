using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public static Controls instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = new Controls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
