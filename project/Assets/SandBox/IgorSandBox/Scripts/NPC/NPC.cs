using Assets.SandBox.IgorSandBox.Scripts.FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.SandBox.IgorSandBox.Scripts.NPC
{
    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
    public class NPC : MonoBehaviour
    {
        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStateMachine;
        public void Awake()
        {
            navMeshAgent = this.GetComponent<NavMeshAgent>();
            finiteStateMachine = this.GetComponent<FiniteStateMachine>();
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
