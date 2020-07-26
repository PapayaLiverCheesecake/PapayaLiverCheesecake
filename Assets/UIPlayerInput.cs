using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerInput : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    bool active = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("<color=magenta>UI Change </color>");
            active = !active;
            canvas.enabled = active;
            if(active)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
