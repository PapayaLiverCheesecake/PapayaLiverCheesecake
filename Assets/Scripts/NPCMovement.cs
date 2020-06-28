using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// following Donovan Keith's code
// http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    #region MovementProperties
    NavMeshAgent Agent;
    [SerializeField]
    List<Point> PatrolPoints;
    int PatrolIndex;
    int PatrolIndexMax;

    //Test, erase later
    public GameObject player;

    [SerializeField]
    float WaitTime;
    float DeltaTime;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position & rotation of theobject
        //posOffset = transform.position;

        Agent = this.GetComponent<NavMeshAgent>();

        //Start on first linked point
        PatrolIndex = 0;
        PatrolIndexMax = PatrolPoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        //Agent.SetDestination(player.transform.position);
        
        if (DeltaTime >= WaitTime)
        {
            Patrol();
            DeltaTime = 0f;
        }
        else if(Agent.remainingDistance <= 1.0f)
        {
            //Debug.Log("Distance is less than 1!");
            //Start timer and wait
            DeltaTime += Time.deltaTime;
            /*if(DeltaTime >= WaitTime)
            {
                Debug.Log("Time is up! Move!");
                Patrol();
            }*/
        }
    }

    #region Movement
    //Patrol looks at the patrol points and picks the next one to walk to; rolls back to the first point in list.
    //Can pause movement using isStopped property.
    void Patrol()
    {
        if(PatrolIndexMax >= 1)
        {
            Agent.SetDestination(PatrolPoints[PatrolIndex].transform.position);
            PatrolIndex = (PatrolIndex + 1) % PatrolIndexMax;
        }
        else
        {
            Debug.Log("Could not find point to move to.");
        }
    }

    #endregion

}
