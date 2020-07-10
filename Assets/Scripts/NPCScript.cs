using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// following Donovan Keith's code
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
public class NPCScript : MonoBehaviour
{
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float speed = 2f;
    public float maxRotation = 45f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of theobject
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // spin around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
