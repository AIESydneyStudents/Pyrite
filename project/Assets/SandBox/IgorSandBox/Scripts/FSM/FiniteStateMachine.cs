using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SandBox.IgorSandBox.Scripts.FSM
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField]
        AbstractFSMState startingState;

        AbstractFSMState currentState;

        public void Awake()
        {
            currentState = null;
        }

        public void Start()
        {
            if (startingState != null)
            {
                EnterState(startingState);
            }
        }

        public void Update()
        {
            if(currentState != null)
            {
                currentState.UpdateState();
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstractFSMState nextState)
        { 
            if(nextState == null)
            {
                return;
            }

            currentState = nextState;
            currentState.EnterState();
        }

        #endregion
    }
}
