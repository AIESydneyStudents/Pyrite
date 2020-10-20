using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    Animator anim;

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
        anim = GetComponent<Animator>();
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
            anim.SetBool("isWalking", true);
        }
        else if(data.canPatrol)
        {
            Patrol();
            anim.SetBool("isWalking", true);
        }
        else if(data.canGuard)
        {
            Guard();
            anim.SetBool("isWalking", false);
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

    private void Guard()
    {
        myMaterial.color = Color.blue;
        navAgent.SetDestination(transform.position);
        //navAgent.SetDestination(waypoints[currentPoint].transform.position);
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
