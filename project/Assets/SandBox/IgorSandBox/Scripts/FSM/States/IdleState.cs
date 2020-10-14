using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SandBox.IgorSandBox.Scripts.FSM.States
{
    [CreateAssetMenu(fileName ="IdleState", menuName ="Unity-FSM/States/Idle", order =1)]
    public class IdleState : AbstractFSMState
    {
        public override bool EnterState()
        {
            base.EnterState();

            UnityEngine.Debug.Log("ENTERED IDLE STATE");

            return true;
        }


        public override void UpdateState()
        {
            UnityEngine.Debug.Log("UPDATING IDLE STATE");
        }

        public override bool ExitState()
        {
            base.ExitState();

            UnityEngine.Debug.Log("EXITED IDLE STATE");

            return true;
        }
    }
}
