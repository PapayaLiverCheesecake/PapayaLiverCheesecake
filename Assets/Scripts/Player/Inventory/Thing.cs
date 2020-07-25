using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace PlayerInfo
{
    /// <summary>
    /// Base class for inventory items and quests, since they share traits.
    /// </summary>
    public class Thing : MonoBehaviour
    {
        //Id is set when an instance is created. Random
        public int Id { get; protected set; }
        public string Description { get; protected set; }


        void SetId()
        {
            System.Random rnd = new System.Random();
            Id = rnd.Next();
        }


    }
}
