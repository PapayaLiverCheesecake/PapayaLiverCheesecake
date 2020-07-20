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
        }

        public override void UpdateState()
        {
            CheckCameraInput();
            CheckControllerInput();

        }

        void Start()
        {
            
        }


        private void CheckControllerInput()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 playerMovement = transform.right * x + transform.forward * y; //Localized, for direction player is facing
                                                                                      
            controller.Move(Vector3.Normalize(playerMovement) * Speed * Time.deltaTime);  //Built in function to character controller.
                                                                                          //Playing animations
            if (x == 0f && y == 0f)   //No input
                fsmRef.EnterState(0);   //Back to idle

            //Temporary
            PlayerGravity();

        }

    }

}
