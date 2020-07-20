using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FallState : AbstractState
    {
        public float Speed; //Different speed when falling.
        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 3;
        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void UpdateState()
        {
            CheckCameraInput();

            ForcePlayerToGround();
            PlayerGravity();

            CheckInput();
        }

        private void CheckInput()
        {
            properties.isGrounded = Physics.CheckSphere(properties.groundCheck.position, properties.groundCheckRad, properties.groundMask);
            if (CheckControllerInput() && properties.isGrounded) //Go to move.
                fsmRef.EnterState(1);
            else if (properties.isGrounded) //Go to idle
                fsmRef.EnterState(0);

        }
       
        private bool CheckControllerInput()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 playerMovement = transform.right * x + transform.forward * y; //Localized, for direction player is facing

            controller.Move(Vector3.Normalize(playerMovement) * Speed * Time.deltaTime);  //Built in function to character controller.
                                                                                          //Playing animations
            if (x != 0.0f || y != 0.0f)  //If there is any input...
                return true;
            else
                return false;

        }

    }

}
