using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.AI;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject opponent;
    public NavMeshAgent agent;
    public float patrolSpeed;
    public float chaseSpeed;
    public Material npcMaterial;

    //public float speed = 2.0f;
    //public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<EnemyAI>().GetPlayer();
        agent = NPC.GetComponent<NavMeshAgent>();
        npcMaterial = NPC.GetComponent<Renderer>().material;
    }
}
