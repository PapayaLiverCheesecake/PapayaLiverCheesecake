using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    //[CreateAssetMenu(fileName = "PlayerProperties", menuName = "ScriptableObjects/PlayerPropertiesSO", order = 1)]
    public class CameraProperties : MonoBehaviour
    {
        #region CameraProperties
        public float RotationSpeed = 1;
        //Target is a specific point on the player that we want to level our camera around. Literally an empty game object.
        public Transform Target, Player;
        public  float mouseX, mouseY;
        #endregion


    }

}
