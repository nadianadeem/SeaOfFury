using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonShooter : MonoBehaviour
{
    public AudioSource cannonSound;
    //A struct is created to hold all the values needed to rotate the cannon.
    public struct cannonInfo{
        public int speed;
        public float friction;
        public float lerpSpeed;
        public float xDegrees;
        public float yDegrees;
    }

    //The quaternions are created to get the current position and the position
    //that the cannon needs to move to.
    public Quaternion fromRotation;
    public Quaternion toRotation;

    //The struct is created so values can be stored in the variables.
    public cannonInfo CannonInfo;
    
    //The camera is stored in this script so the user can see the cannon.
    public Camera rightCam;

    //The series of values stored are for the shooting mechanic.
    //The game objects are instantiated.
    //The rigidbody is created to add force to the cannon ball.
    //The shot position is where the cannon ball is shot from.
    public GameObject cannonBall;
    public GameObject explosion;
    public GameObject cannon;
    private Rigidbody cannonBallRB;
    public Transform shotPosition;

    //These two variable try to stop the player from rapidly shooting cannon balls.
    public float fireRate = 5.0f;
    public float nextRate = 0.0f;
    void Update()
    {
        //If the "Q" key or or A button is pressed and is not restricted from the fire rate then added to the fire rate 
        //and shoot the cannon.
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextRate)
        {
            cannonSound.Play();
            nextRate = nextRate + fireRate;
            shootCannon();
        }

        if (Input.GetButtonDown("shoot") && Time.time > nextRate)
        {
            cannonSound.Play();
            nextRate = nextRate + fireRate;
            shootCannon();
        }
    }

    //This is method instantiates both the cannon and explosion from the shotPosition specified in the editor.
    void shootCannon()
    {
        shotPosition.rotation = transform.rotation;
        Instantiate(explosion, shotPosition.position, shotPosition.rotation);
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPosition.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        //Adds force to the cannon ball so it shoots away from the player's ship.
        cannonBallRB.AddForce(transform.right * 200);
    }
}
