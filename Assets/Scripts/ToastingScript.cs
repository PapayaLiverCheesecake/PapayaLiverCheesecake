using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfo;

public class ToastingScript : MonoBehaviour
{
    bool isPlayerInRange;
    public Transform player;
    public LayerMask playerLayer;
    public AudioSource m_AudioSource_Clink;
    public AudioSource m_AudioSource_Glug;

    public int NPCNumber;
    public QuestHolder playerQuests;

    void Update()
    {
        if(!playerQuests.QuestList[NPCNumber - 1].QuestCompleted)
        {
            if (IsPlayerInRange() && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(theToasting());
                playerQuests.SetQuestBool(NPCNumber, true);
                Debug.Log("Toasted!");
            }

        }
        
    }

    public bool IsPlayerInRange()
    {
        return Physics.CheckBox(this.transform.position, new Vector3(6, 8, 6), Quaternion.identity, playerLayer);
    }

    /*void OnTriggerEnter (Collider other)
    {

        if (other.transform == player)
        {
            isPlayerInRange = true;
            Debug.Log("COLLIDED");
        }
    }*/
    IEnumerator theToasting()
    {
        m_AudioSource_Clink.Play();
        yield return new WaitForSeconds(0.5f);
        m_AudioSource_Glug.Play();

    }

}
