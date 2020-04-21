using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public enemyPatrol eP;
    //The lookRadius is how far the enemy can detect the player.
    public float lookRadius = 10f;

    //Stores the transform of the player.
    Transform target;
    //Stores the nav mesh for the enemy ship.
    NavMeshAgent agent;

    // Start is called before the first frame update.
    void Start()
    {
        //Target is set to the transform of the player ship.
        target = playerManager.instance.player.transform;
        //Agent stores the navmesh agent of the object that the script is tied to.
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {

        //The distance between the player and enemy is calculated and is stored in the variable distance.
        float distance = Vector3.Distance(target.position, transform.position);

        //If the player is within the radius...
        if (distance <= lookRadius)
        {
            eP.patrolling = false;
            agent.SetDestination(target.position);
        }
        else
        {
            eP.patrolling = true;
        }

    }
}
