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

    // Start is called before the first frame update
    void Start()
    {
        //Set the values for the rotation of the cannon.
        CannonInfo.speed = 3;
        CannonInfo.friction = 1;
        CannonInfo.lerpSpeed = 2;
    }

    void FixedUpdate()
    {
        //If the player is looking through the right camera...
        if (rightCam.enabled == true)
        {
            //And the left mouse button is held down.
            if (Input.GetMouseButton(0))
            {
                if (cannon.transform.eulerAngles.y > 304 || cannon.transform.eulerAngles.y < 10)
                {
                    //xDegrees and yDegrees equals the axis of the mouse with the speed and friction multiplied.
                    CannonInfo.xDegrees -= Input.GetAxis("Mouse X") * CannonInfo.speed * CannonInfo.friction;
                    CannonInfo.yDegrees -= Input.GetAxis("Mouse Y") * CannonInfo.speed * CannonInfo.friction;
                    //Stores the current rotation of the cannon.
                    fromRotation = transform.rotation;
                    //The 'toRotation' is the angle of the variable 'yDegrees'.
                    toRotation = Quaternion.Euler(0, CannonInfo.xDegrees, 0);
                    //This method moves the cannon using the Lerp method from the starting position 
                    //of the cannon to the desired rotation at the speed defined at the start.
                    transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * CannonInfo.lerpSpeed);

                    //xDegrees and yDegrees equals the axis of the mouse with the speed and friction multiplied.
                    CannonInfo.xDegrees -= Input.GetAxis("cannonCamX") * CannonInfo.speed * CannonInfo.friction;
                    CannonInfo.yDegrees -= Input.GetAxis("cannonCamY") * CannonInfo.speed * CannonInfo.friction;
                    //Stores the current rotation of the cannon.
                    fromRotation = transform.rotation;
                    //The 'toRotation' is the angle of the variable 'yDegrees'.
                    toRotation = Quaternion.Euler(0, CannonInfo.xDegrees, 0);
                    //This method moves the cannon using the Lerp method from the starting position 
                    //of the cannon to the desired rotation at the speed defined at the start.
                    transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * CannonInfo.lerpSpeed);
                }

            if (cannon.transform.eulerAngles.y < 304 && cannon.transform.eulerAngles.y > 250)
            {
                transform.rotation = Quaternion.Euler(0, 306, 0);
            }
                
            if (cannon.transform.eulerAngles.y < 15)
            {
                transform.rotation = Quaternion.Euler(0, 7, 0);
            }
            }
        }
    }

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
