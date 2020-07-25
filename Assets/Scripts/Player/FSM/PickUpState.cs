using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PickUpState : AbstractState
    {
        //This state instantly updates back to its previous state. 
        public float pickUpRadius;  //Temporary, for playtesting.
        private new void OnEnable()
        {
            base.OnEnable();
            StateType = 4;
        }

        public override void UpdateState()
        {
            CheckForObject();
            fsmRef.EnterState(fsmRef.previousState);
        }

        void CheckForObject()
        {
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, pickUpRadius, properties.objectMask);
            Debug.Log("<color=blue>Checking object </color>");
            foreach (Collider coll in colliders)
            {
                PlayerInfo.Object pickedUpObj = coll.GetComponent<PlayerInfo.Object>();
                Debug.Log("<color=red>Collided with object </color>" + pickedUpObj.gameObject.name);
                properties.Inventory.Add(pickedUpObj);
                
                pickedUpObj.Disappear();
            }
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, pickUpRadius);
        }
    }

}
