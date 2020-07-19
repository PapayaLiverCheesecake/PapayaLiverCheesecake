using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : AbstractState
    {
        Animator playerAnim;

        private void OnEnable()
        {
            StateType = 0;
        }

        public override void UpdateState()
        {
            CheckCameraInput();
        }


    }

}
