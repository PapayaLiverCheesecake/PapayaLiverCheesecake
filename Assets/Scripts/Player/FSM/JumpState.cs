﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class JumpState : AbstractState
    {
        public float Speed;

        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 2;
        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void UpdateState()
        {
            CheckCameraInput();
            CheckControllerInput();

            //ForcePlayerToGround();
            properties.velocity.y = Mathf.Sqrt(properties.jumpHeight * -2f * properties.gravity);
            controller.Move(properties.velocity * Time.deltaTime);

            fsmRef.EnterState(3);
        }
        public override void ExitState()
        {
            base.ExitState();
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
