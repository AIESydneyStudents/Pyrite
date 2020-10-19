using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent navAgent;
   
    public Transform[] waypoints;
    
    private int currentPoint;
    public GameObject player;
    float distance;
    public float accuracy = 0f;
    
    [SerializeField] EnemyData data;
    private Material myMaterial;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        myMaterial = GetComponent<Renderer>().material;
        currentPoint = 0;
    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < data.detectRange && data.canChase)
        {
            Chase();
        }
        else if(data.canPatrol)
        {
            Patrol();
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

    private void Chase()
    {
        myMaterial.color = Color.red;
        navAgent.speed = data.chaseSpeed;
        navAgent.SetDestination(player.transform.position);
    }

    private void Patrol()
    {
        myMaterial.color = Color.green;
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

        navAgent.SetDestination(waypoints[currentPoint].transform.position);
    }
}
