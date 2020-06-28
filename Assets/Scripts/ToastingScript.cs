using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastingScript : MonoBehaviour
{
    bool isPlayerInRange;
    public Transform player;
    AudioSource m_AudioSource;
    void Update()
    {
        if (isPlayerInRange && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(theToasting());
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
