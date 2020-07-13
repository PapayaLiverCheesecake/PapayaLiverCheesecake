using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_Jump : MonoBehaviour
{
    /// <summary>
    /// This script is used by some objects to give the player a jump boost when the player jumps from them.
    /// Ideally, the player would jump into it and get the boost, but this requires ugly code or a simple
    /// FSM. FSM shall be coded later if given time.
    /// </summary>
    
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private Rigidbody playerRb;
    [SerializeField]
    private Transform jumpPoint;
    [SerializeField]
    private float jumpMultiplier;

    [SerializeField]
    private float sizeX;
    [SerializeField]
    private float sizeY;
    [SerializeField]
    private float sizeZ;


    private void FixedUpdate()
    {
        if(IsPlayerInRange() && Input.GetButtonDown("Jump"))
        {
            Debug.Log("BOUNCE!");
            playerRb.AddForce(Vector3.up * jumpMultiplier);
            //playerRb.velocity += Vector3.up * jumpMultiplier;
        }
    }


    private bool IsPlayerInRange()
    {
        return Physics.CheckBox(jumpPoint.position, new Vector3(sizeX, sizeY, sizeZ), Quaternion.identity, playerLayer);
    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(jumpPoint.position, new Vector3(sizeX, sizeY, sizeZ));
    }

}
