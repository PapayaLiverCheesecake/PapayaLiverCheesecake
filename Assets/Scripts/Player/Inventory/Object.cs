using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    //Object scripts are attached to, well, objects in the world. 
    public class Object : Thing
    {
       
        //When picked up, the objects should disappear from the level.
        public void Disappear()
        {
            this.gameObject.SetActive(false);
        }
    }

}
