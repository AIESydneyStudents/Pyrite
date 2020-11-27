using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitObj : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;

    private void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

}
