using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformBetweenNodesAfterWait : MonoBehaviour
{
    public Transform[] PlatformPoints;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    private float numberOfPoints;
    private int currentPoint;
    bool platformCanMove = true;
    public float platformWaitTime;
    private float timer;


    void Start()
    {
        nextPos = startPos.position;

        numberOfPoints = PlatformPoints.Length;
        currentPoint = 0;
    }

    private void Update()
    {
        if (platformCanMove == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                platformCanMove = true;
                timer = platformWaitTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if (platformCanMove == true)
        {
            if (transform.position == PlatformPoints[currentPoint].position)
            {
                if (currentPoint < numberOfPoints - 1)
                {
                    nextPos = PlatformPoints[currentPoint + 1].position;
                    currentPoint += 1;
                    platformCanMove = false;
                }
                else
                {
                    nextPos = startPos.position;
                    currentPoint = 0;
                    platformCanMove = false;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
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
