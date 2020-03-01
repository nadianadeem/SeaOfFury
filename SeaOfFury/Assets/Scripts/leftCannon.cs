using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftCannon : MonoBehaviour
{
    public int speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    public Camera leftCam;

    public GameObject cannonBall;
    private Rigidbody cannonBallRB;
    public Transform shotPosition;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(leftCam.enabled == true)
        {
            if(Input.GetMouseButton(0))
            {
                xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                yDegrees -= Input.GetAxis("Mouse X") * speed * friction;
                fromRotation = transform.rotation;
                toRotation = Quaternion.Euler(0, yDegrees, 0);
                transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)){
            shootCannon();
        }
    }

    void shootCannon()
    {
        shotPosition.rotation = transform.rotation;
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPosition.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(-transform.right * -150);
    }
}
