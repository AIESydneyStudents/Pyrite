using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenNodes : MonoBehaviour
{
    public Transform[] PlatformPoints;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    private float numberOfPoints;
    private int currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;

        numberOfPoints = PlatformPoints.Length;
        currentPoint = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        if (transform.position == PlatformPoints[currentPoint].position)
        {

            if (currentPoint < numberOfPoints - 1)
            {
                nextPos = PlatformPoints[currentPoint + 1].position;
                currentPoint += 1;
            }
            else
            {
                nextPos = startPos.position;
                currentPoint = 0;
            }
           
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < PlatformPoints.Length -1; i++)
        {
            Gizmos.DrawLine(PlatformPoints[i].position, PlatformPoints[i+1].position);
        }
        
    }
}
