﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    Animator anim;

    private NavMeshAgent navAgent;

    public Transform[] waypoints;

    Vector3 startPos;
    public float damping = 3f;
    private int currentPoint;
    private int startPoint;
    private int endPoint;
    public GameObject player;
    float distance;
    public float accuracy = 0f;
    bool arrived = false;
    bool alerted = false;

    [SerializeField] EnemyData data;
    //private Material myMaterial;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        //myMaterial = GetComponent<Renderer>().material;
        currentPoint = 0;
        startPoint = 0;
        endPoint = 1;
        startPos = transform.position;
        arrived = false;
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < data.detectRange && data.canChase)
        {
            Alert();
            Invoke("Chase", 1f);
            // Chase();
        }
        else if (data.canPatrol)
        {
            Patrol();

        }
        else if (data.canGuard)
        {
            Guard();

        }
    }


    /// <DrawingLinesDebug>
    /// draws lines in scene view to show the path of the platforms
    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
        }

    }

    private void Alert()
    {
        if (alerted == false)
            anim.Play("Alert");
        alerted = true;
    }

    private void Guard()
    {
        //myMaterial.color = Color.blue;

        if (Vector3.Distance(startPos, transform.position) > accuracy)
        {
            anim.SetBool("isWalking", true);
            navAgent.SetDestination(startPos);
        }
        else
        {
            anim.SetBool("isWalking", false);
            alerted = false;
            //navAgent.SetDestination(transform.position);

            var rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }

    private void Chase()
    {
            //myMaterial.color = Color.red;
            anim.SetBool("isWalking", true);
            navAgent.speed = data.chaseSpeed;
            navAgent.SetDestination(player.transform.position);
    }

    private void Patrol()
    {
        alerted = true;
        // myMaterial.color = Color.green;
        navAgent.speed = data.patrolSpeed;
        if (waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentPoint].transform.position, transform.position) < accuracy)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Length)
            {
                currentPoint = 0;
            }
        }
        anim.SetBool("isWalking", true);
        navAgent.SetDestination(waypoints[currentPoint].transform.position);
    }

    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), Time.deltaTime);
    }
}