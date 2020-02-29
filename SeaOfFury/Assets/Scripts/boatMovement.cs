using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovement : MonoBehaviour
{
    public float currentSpeed = 0;
    public float maxSpeed = 0.08f;
    public float acceleration = 0.02f;
    public float deceleration = 0.01f;

    public Animator animationController;
    public Rigidbody shipRB;

    public Camera mainCamera;
    public Camera leftCamera;
    public Camera rightCamera;
    // Start is called before the first frame update
    void Start()
    {
        shipRB = GetComponent<Rigidbody>();
        mainCamera.enabled = true;
        leftCamera.enabled = false;
        rightCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = currentSpeed + (acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = currentSpeed - (deceleration * Time.deltaTime);
        }
        
        if (currentSpeed > 0)
        {
            transform.Translate(0, 0, currentSpeed);
        }
        if (currentSpeed > maxSpeed){
            currentSpeed = maxSpeed;
        }

        if (currentSpeed < 0)
        {
            currentSpeed = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animationController.SetBool("rightAniTrigger", true);
            Debug.Log("Right");
            transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * 2, Space.World); 
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animationController.SetBool("leftAniTrigger", true);
            Debug.Log("Left");
            transform.Rotate(new Vector3(0, -10, 0) * Time.deltaTime * 2, Space.World);
        }
        else
        {
            animationController.SetBool("rightAniTrigger", false);
            animationController.SetBool("leftAniTrigger", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            leftCamera.enabled = true;
            rightCamera.enabled = false;
            mainCamera.enabled = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            rightCamera.enabled = false;
            mainCamera.enabled = true;
            leftCamera.enabled = false;
        }

        if (Input.GetKey(KeyCode.T))
        {
            rightCamera.enabled = true;
            mainCamera.enabled = false;
            leftCamera.enabled = false;
        }
    }

    void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            currentSpeed = 0;
        }
    }
}
