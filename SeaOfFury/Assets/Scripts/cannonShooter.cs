using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonShooter : MonoBehaviour
{
    public struct cannonInfo{
        public int speed;
        public float friction;
        public float lerpSpeed;
        public float xDegrees;
        public float yDegrees;
    }

    public Quaternion fromRotation;
    public Quaternion toRotation;

    public cannonInfo CannonInfo;
    
    public Camera rightCam;

    public GameObject cannonBall;
    public GameObject explosion;
    private Rigidbody cannonBallRB;
    public Transform shotPosition;

    public float fireRate = 5.0f;
    public float nextRate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CannonInfo.speed = 5;
        CannonInfo.friction = 1;
        CannonInfo.lerpSpeed = 3;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(rightCam.enabled == true)
        {
            if(Input.GetMouseButton(0))
            {
                CannonInfo.xDegrees -= Input.GetAxis("Mouse Y") * CannonInfo.speed * CannonInfo.friction;
                CannonInfo.yDegrees -= Input.GetAxis("Mouse X") * CannonInfo.speed * CannonInfo.friction;
                fromRotation = transform.rotation;
                toRotation = Quaternion.Euler(0, CannonInfo.yDegrees, 0);
                transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * CannonInfo.lerpSpeed);
            }

            CannonInfo.xDegrees -= Input.GetAxis("cannonCamX") * CannonInfo.speed * CannonInfo.friction;
            CannonInfo.yDegrees -= Input.GetAxis("cannonCamY") * CannonInfo.speed * CannonInfo.friction;
            fromRotation = transform.rotation;
            toRotation = Quaternion.Euler(0, CannonInfo.yDegrees, 0);
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * CannonInfo.lerpSpeed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time > nextRate)
        {
            nextRate = nextRate + fireRate;
            shootCannon();
        }

        if (Input.GetButtonDown("shoot") && Time.time > nextRate)
        {
            nextRate = nextRate + fireRate;
            shootCannon();
        }
    }

    void shootCannon()
    {
        shotPosition.rotation = transform.rotation;
        Instantiate(explosion, shotPosition.position, shotPosition.rotation);
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPosition.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(transform.right * 200);
    }
}
