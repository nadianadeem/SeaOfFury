using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovement : MonoBehaviour
{
    public float constantSpeed = 0.05f;
    public float backwardSpeed = 0.025f;
    public float speed = 5.0f;
    public Rigidbody shipRB;

    // Start is called before the first frame update
    void Start()
    {
        shipRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("forward");
            shipRB.velocity = (transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Backward");
            shipRB.velocity = (-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            transform.Rotate(new Vector3(0, 2, 0) * Time.deltaTime * 2, Space.World); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            transform.Rotate(new Vector3(0, -2, 0) * Time.deltaTime * 2, Space.World);
        }

        if (Input.GetAxis("Vertical") == -1)
        {
            shipRB.AddForce(-transform.forward * speed);
        }

        if (Input.GetAxis("Vertical") == 1)
        {
            shipRB.AddForce(transform.forward * speed);
        }

        if (Input.GetAxis("Horizontal") == -1)
        {
            transform.Rotate(new Vector3(0, 2, 0) * Time.deltaTime * 2, Space.World);
        }

        if (Input.GetAxis("Horizontal") == 1)
        {
            transform.Rotate(new Vector3(0, -2, 0) * Time.deltaTime * 2, Space.World);
        }
    }
}
