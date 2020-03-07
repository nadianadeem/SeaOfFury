using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class leftEnemyShooter : MonoBehaviour
{
    //The cannon ball is set in this variable so it can be instantiated.
    public GameObject cannonBall;
    
    //The rigidbody of the cannon ball is used to add force to the object
    //so it shoots out of the boat.
    private Rigidbody cannonBallRB;

    //This transform is where the cannon ball is instantiated.
    public Transform shotPosition;

    // Start is called before the first frame update
    void Start()
    {
        //This method runs the attack method at 2 seconds since the start of the game
        //and then every 5 seconds after.
        InvokeRepeating("attack", 2.0f, 5.0f);
    }

    //The attack methods creates the cannon ball and add force to it.
    void attack()
    {
        //The cannonball is created in the shot position and it set to the rotation of the cannon.
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPosition.position, transform.rotation) as GameObject;
        //The rigidbody is retrieved from the object created.
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        //Force is then added to the cannon so it fires and has
        //realistic projection.
        cannonBallRB.AddForce(-transform.right * -150);
    }
}
