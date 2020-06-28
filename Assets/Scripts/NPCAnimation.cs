using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    #region AnimationProperties
    //public float degreesPerSecond = 15.0f;
    // Rotation variables    
    public float speed = 2f;
    public float maxRotation = 45f;

    // Position variables
    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of theobject
        posOffset = transform.position;
    }

    void Update()
    {
        IdleAnimation();
    }

    #region AnimationMethods
    void IdleAnimation()
    {
        // spin around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * speed), 0f);
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;

    }
    #endregion


}
