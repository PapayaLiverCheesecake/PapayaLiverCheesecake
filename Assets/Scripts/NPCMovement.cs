using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// following Donovan Keith's code
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
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


    #region MovementProperties
    NavMeshAgent Agent;
    [SerializeField]
    List<Vector3> PatrolPoints;
    int PatrolIndex;
    int PatrolIndexMax;

    [SerializeField]
    float WaitTime;
    float DeltaTime;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of theobject
        posOffset = transform.position;

        Agent = this.GetComponent<NavMeshAgent>();

        //Start on first linked point
        PatrolIndex = 0;
        PatrolIndexMax = PatrolPoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        IdleAnimation();
        if(DeltaTime >= WaitTime)
        {
            Patrol();
        }
        //Updating time;
        DeltaTime += Time.deltaTime;

    }

    #region Movement
    //Patrol looks at the patrol points and picks the next one to walk to; rolls back to the first point in list.
    //Can pause movement using isStopped property.
    void Patrol()
    {
        if(PatrolIndexMax >= 1)
        {
            Agent.SetDestination(PatrolPoints[PatrolIndex]);
            PatrolIndex = (PatrolIndex + 1) % PatrolIndexMax;
        }
        else
        {
            Debug.Log("Could not find point to move to.");
        }
    }

    #endregion

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
