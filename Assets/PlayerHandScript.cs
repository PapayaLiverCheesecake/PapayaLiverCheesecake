using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandScript : MonoBehaviour
{
    Animator m_Animator;
    //bool ifLeftClick = true;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(ToastingAnim());
        }
    }
    IEnumerator ToastingAnim()
    {
        m_Animator.SetBool("ifLeftClick", true);
        yield return new WaitForSeconds(0.5f);
        m_Animator.SetBool("ifLeftClick", false);
    }
}
