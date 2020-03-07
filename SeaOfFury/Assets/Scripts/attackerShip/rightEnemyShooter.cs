using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightEnemyShooter : MonoBehaviour
{
    //The cannon ball is set in this variable so it can be instantiated.
    public GameObject cannonBall;

    //The transform of the target is used to get the distance between the ships
    //and to move the AI towards the player.
    private Rigidbody cannonBallRB;

    public Transform shotPosition;

    // Start is called before the first frame update.
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
        cannonBallRB.AddForce(transform.right * 150);
    }
}
