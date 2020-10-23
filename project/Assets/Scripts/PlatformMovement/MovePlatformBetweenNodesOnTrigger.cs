using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBetweenNodesOnTrigger : MonoBehaviour
{
    public Transform[] PlatformPoints;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    private float numberOfPoints;
    private int currentPoint;
    private bool playerOnPlatform;


    void Start()
    {
        nextPos = startPos.position;

        numberOfPoints = PlatformPoints.Length;
        currentPoint = 0;
    }

    private void FixedUpdate()
    {
        if (playerOnPlatform == true)
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
        }
        else if (playerOnPlatform == false)
        {
            nextPos = startPos.position;
            currentPoint = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    public void PlayerOnPlatform()
    {
        playerOnPlatform = true;
    }
    public void PlayerOffPlatform()
    {
        playerOnPlatform = false;
    }

    /// <DrawingLinesDebug>
    /// draws lines in scene view to show the path of the platforms
    private void OnDrawGizmos()
    {
        for (int i = 0; i < PlatformPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(PlatformPoints[i].position, PlatformPoints[i + 1].position);
        }

    }
}
