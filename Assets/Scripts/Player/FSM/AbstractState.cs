﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class AbstractState : MonoBehaviour
    {
        /*'NONE' is the default state. Ideally, every state, when added to FSM list, gets moved from 'NONE' to 'ACTIVE'
         *'ENTERED' occurs on EnterState(), 'UPDATING' occurs on UpdateState(), 'EXITING' occurs on ExitState()
         * The Position enum is not necessary for its function, but it serves as a possible way of observing its position in its 'life'
         * and for bug-testing.
         */

        //Thinking of adding this information into a scriptable object. Since all states will be using this (not at the same time), it might be worthwhile to
        //put this into a scriptable object where only one instance of this information exists (good memory-wise, albeit not too much). Unsure if it will work, however, needs
        // testing.
        /*
        #region CameraProperties
        [SerializeField]
        private float RotationSpeed = 1;        
        private Transform Target, Player;
        private float mouseX, mouseY;
        #endregion
        */
        [SerializeField]
        private CameraProperties properties;

        enum Position
        {
            NONE,
            ACTIVE,
            ENTERED,
            UPDATING,
            EXITING
        }
        public int StateType { get; protected set; }
        Position pos = Position.NONE;
        
        //Each state is different and includes a different implementation of Update State.
        public abstract void UpdateState();

        public virtual void EnterState()
        {
            pos = Position.ACTIVE;
            Debug.Log("Entered " + this.ToString());
        }

        public virtual void ExitState()
        {
            pos = Position.EXITING;
            Debug.Log("Exiting " + this.ToString());
        }

        #region CameraMovement
        protected void CheckCameraInput()
        {
            properties.mouseX += Input.GetAxis("Mouse X") * properties.RotationSpeed;
            properties.mouseY -= Input.GetAxis("Mouse Y") * properties.RotationSpeed;

            properties.mouseY = Mathf.Clamp(properties.mouseY, -35, 60);

            //transform.LookAt(properties.Target);

            properties.Target.rotation = Quaternion.Euler(properties.mouseY, properties.mouseX, 0);
            properties.Player.rotation = Quaternion.Euler(0, properties.mouseX, 0);
        }
        #endregion

    }

}
