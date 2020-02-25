using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovement : MonoBehaviour
{
    public float startSpeed = 0;
    public float currentSpeed = 0;
    public float maxSpeed = 0.08f;

    public float acceleration = 0.02f;

    public float deceleration = 0.01f;
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
            Debug.Log("Right");
            transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * 2, Space.World); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            transform.Rotate(new Vector3(0, -10, 0) * Time.deltaTime * 2, Space.World);
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
