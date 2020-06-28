using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    public class Quest
    {
        public int ID { get; set; }
        public string Description { get; }
        public bool QuestCompleted { get; set; }

        public Quest(int _ID, string _Description)
        {
            this.ID = _ID;
            this.Description = _Description;
            this.QuestCompleted = false;
        }

        public Quest(int _ID, string _Description, bool _QuestCompleted)
        {
            this.ID = _ID;
            this.Description = _Description;
            this.QuestCompleted = _QuestCompleted;
        }


    }
}

