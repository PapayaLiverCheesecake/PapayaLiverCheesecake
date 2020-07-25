using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : AbstractState
    {
        Animator playerAnim;

        public override void EnterState()
        {
            base.EnterState();
            ForcePlayerToGround();//
        }
        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 0;
        }

        public override void UpdateState()
        {
            CheckCameraInput();
            CheckInput();
            
        }

        private void CheckInput()
        {

            //Player is falling? Then fall
            properties.isGrounded = Physics.CheckSphere(properties.groundCheck.position, properties.groundCheckRad, properties.groundMask);
            if(Input.GetButtonDown("Fire2"))    //Right click, or F
            {
                Debug.Log("<color=yellow>Pressed F or right Click!</color>");
                fsmRef.EnterState(4);
            }
            else if (!properties.isGrounded)
            {
                fsmRef.EnterState(3);
            }
            //Jumping is detected, JUMP!
            else if (Input.GetButtonDown("Jump") && properties.isGrounded)
            {
                fsmRef.EnterState(2);
            }
            //Only movement is detected, MOVE!
            else if ( (Input.GetAxis("Horizontal") != 0f) || (Input.GetAxis("Vertical") != 0f) )  
            {
                fsmRef.EnterState(1);   //1: Move state
            }
            
            
        }

    }

}
