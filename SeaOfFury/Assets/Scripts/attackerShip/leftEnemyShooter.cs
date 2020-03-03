using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class leftEnemyShooter : MonoBehaviour
{
    public GameObject cannonBall;
    private Rigidbody cannonBallRB;

    public Transform shotPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("attack", 2.0f, 5.0f);
    }

    void attack()
    {
        shotPosition.rotation = transform.rotation;
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPosition.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(-transform.right * -150);
    }
    

    // Update is called once per fram
}
