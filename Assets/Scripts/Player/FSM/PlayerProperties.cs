using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    //[CreateAssetMenu(fileName = "PlayerProperties", menuName = "ScriptableObjects/PlayerPropertiesSO", order = 1)]
    public class PlayerProperties : MonoBehaviour
    {
        #region CameraProperties
        public float RotationSpeed = 1;
        //Target is a specific point on the player that we want to level our camera around. Literally an empty game object.
        public Transform Target, Player;
        public float mouseX, mouseY;
        #endregion

        #region Physics
        public Vector3 velocity;
        public float gravity = -20f;
        public float jumpHeight = 3.0f;
        public bool isGrounded;
        public Transform groundCheck;
        public float groundCheckRad = 0.4f; //Radius of sphere used to check.
        public LayerMask groundMask;    //Allows us to control which objects the sphere checks for.
        public LayerMask objectMask;    //Sets objects that are pickable.
        #endregion

        public List<Object> Inventory = new List<Object>();


    }

}
