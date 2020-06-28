using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInfo
{
    public struct Found_Index
    {
        public Found_Index(bool _found, int _index)
        {
            Found = _found;
            Index = _index;
        }
        public bool Found { get; set; }
        public int Index { get; set; }
    }

    public class QuestHolder : MonoBehaviour
    {
        List<Quest> QuestList;
        
        public QuestHolder()
        {
            //Since we do not have a save point right now. When initialized we can make the QuestHolder get the first quest which tells the player what to do.
            QuestList = new List<Quest>()
            {
                new Quest(1, "Drink with guest"),
                new Quest(2, "Drink with guest"),
                new Quest(3, "Drink with guest"),
                new Quest(4, "Drink with guest"),
                new Quest(5, "Drink with guest"),
                new Quest(6, "Drink with guest"),
                new Quest(7, "Drink with guest"),
                new Quest(8, "Drink with guest"),
                new Quest(9, "Drink with guest"),
                new Quest(10, "Drink with guest")
            };
        }

        public void AddQuest(int _id, string _description)
        {
            Quest tempQuest = new Quest(_id, _description);
            QuestList.Add(tempQuest);

            return;
        }

        //Simply makes sure that the quest is in quest system, and returns where in list it is located.
        public Found_Index FindQuest(int _id)
        {
            Found_Index f_ind = new Found_Index(false, -1);

            int counter = -1;
            foreach(Quest _quest in QuestList)
            {
                ++counter;
                if(_quest != null)
                {
                    if (_id == _quest.ID)
                    {
                        f_ind.Found = true;
                        f_ind.Index = counter;
                    }
                    else
                    {
                        f_ind.Found = false;
                        //No need to set Index, already at -1
                    }
                }
                else
                {
                    Debug.Log("<color=red>No quests in system. Something went wrong.</color>");
                    f_ind.Found = false;
                }
            }
            return f_ind;
        }

        //Sets a quest to completed;
        public bool SetQuestBool(int _id, bool _toComplete)
        {
            Found_Index f_ind = FindQuest(_id);

            if(f_ind.Found)
            {
                //Grab info to update list element: int ID, string Description, bool QuestCompleted
                int _questID = this.QuestList[f_ind.Index].ID;
                string _questDescription = this.QuestList[f_ind.Index].Description;
                bool _questCompleted = this.QuestList[f_ind.Index].QuestCompleted;
                
                this.QuestList[f_ind.Index] = new Quest(_questID, _questDescription, _questCompleted);

                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
