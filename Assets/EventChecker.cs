using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PlayerInfo
{
    public class EventChecker : MonoBehaviour
    {
        public QuestHolder holder;

        // Update is called once per frame
        void Update()
        {
            if (holder.AreWeDone())
                Loadlevel("EndScene");
        }



        public void Loadlevel(string level)
        {
            SceneManager.LoadScene(level);

        }
    }

}
