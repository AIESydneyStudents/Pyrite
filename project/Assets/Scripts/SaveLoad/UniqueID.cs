using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <UniqueID>
/// gives every item with the attached script an ID based of its position name and index
public class UniqueID : MonoBehaviour
{
    public string ID { get; private set; }
    void Awake()
    {
        ID = transform.position.sqrMagnitude + "-" + name + "-" + transform.GetSiblingIndex();
    }
}
