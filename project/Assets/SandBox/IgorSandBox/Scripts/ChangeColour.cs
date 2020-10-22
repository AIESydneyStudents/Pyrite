using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeColour : MonoBehaviour
{
    private Material myMaterial;
    PlayerMovement playMov;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        playMov = FindObjectOfType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playMov.canDash)
        {
            myMaterial.color = Color.blue;
        }
        if (playMov.canDoubleJump)
        {
            myMaterial.color = Color.green;
        }
        if (playMov.canGrapple)
        {
            myMaterial.color = Color.red;
        }
    }
}