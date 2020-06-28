using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerInfo;

public class ToastingScript : MonoBehaviour
{
    bool isPlayerInRange;
    public Transform player;
    AudioSource m_AudioSource;

    public int NPCNumber;
    public QuestHolder playerQuests;

    void Update()
    {
        if (isPlayerInRange && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(theToasting());
            playerQuests.SetQuestBool(NPCNumber, true);
        }
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRange = true;
        }
    }
    IEnumerator theToasting()
    {
        m_AudioSource.Play();
        yield return new WaitForSeconds(0.5f);


    }

}
