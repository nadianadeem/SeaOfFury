using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private float lowerBound;
    private int upperBound;
    private int currentPoint;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(patrolPoints[currentPoint].position, transform.position);
        if (distance < 3f)
        {
            currentPoint++;
        }

        if (currentPoint >= patrolPoints.Length)
        {
            currentPoint = 0;
        }

        agent.SetDestination(patrolPoints[currentPoint].position);
    }
}
