using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    //MoveState
    public class MoveState : AbstractState
    {   
        //Make Speed private when finalized. ***************
        public float Speed;
        
        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 1;
        }

        public override void EnterState()
        {
            base.EnterState();
            ForcePlayerToGround();
        }

        public override void UpdateState()
        {
            CheckCameraInput();
            CheckControllerInput();
            CheckInput();
        }


        private void CheckControllerInput()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 playerMovement = transform.right * x + transform.forward * y; //Localized, for direction player is facing
                                                                                      
            controller.Move(Vector3.Normalize(playerMovement) * Speed * Time.deltaTime);  //Built in function to character controller.

            if (Input.GetButtonDown("Fire2"))    //Right click, or F
            {
                Debug.Log("Pressed F or right Click!");
                fsmRef.EnterState(4);
            } 
            else if (x == 0f && y == 0f)   //No input
                    fsmRef.EnterState(0);   //Back to idle


        }
        //World input, not player's.
        private void CheckInput()
        {
            //Player is falling? Then fall
            properties.isGrounded = Physics.CheckSphere(properties.groundCheck.position, properties.groundCheckRad, properties.groundMask);
            if (!properties.isGrounded)
            {
                fsmRef.EnterState(3);
            }
            //Jumping is detected, JUMP!
            else if (Input.GetButtonDown("Jump") && properties.isGrounded)
            {
                fsmRef.EnterState(2);
            }
        }

    }

}
