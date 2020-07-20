using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : AbstractState
    {
        Animator playerAnim;
        

        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 0;
        }

        public override void UpdateState()
        {
            CheckCameraInput();
            CheckControllerInput();
        }

        private void CheckControllerInput()
        {

            if( (Input.GetAxis("Horizontal") != 0f) || (Input.GetAxis("Vertical") != 0f) )
            {
                fsmRef.EnterState(1);   //1: Move state
            }
            //Temporary
            PlayerGravity();
        }

    }

}
