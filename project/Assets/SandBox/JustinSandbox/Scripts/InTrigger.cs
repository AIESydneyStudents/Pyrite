using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class TriggerStay : UnityEvent { };
public class InTrigger : MonoBehaviour
{
    public TriggerStay whileInTrigger;
    public TriggerStay onTriggerExit;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            whileInTrigger.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onTriggerExit.Invoke();
        }
    }
}
