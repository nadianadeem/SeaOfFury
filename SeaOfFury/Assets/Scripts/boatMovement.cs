﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovement : MonoBehaviour
{
    //An array is created to hold the current speed, maximum speed, acceleration and deceleration.
    public float[] speeds = new float[4] {0.0f, 0.06f, 0.02f, 0.01f};

    //The animator for the player ship is stored in the script.
    //this is to switch between the animations of the sails moving.
    public Animator animationController;
    //The rigidbody of the player is stored in the script so the player can move.
    public Rigidbody shipRB;

    //All the cameras are stored in the script so the user can switch
    //between them if they want to fire cannons with a more accurate view.
    public Camera mainCamera;
    public Camera leftCamera;
    public Camera rightCamera;

    // Start is called before the first frame update.
    void Start()
    {
        //The rgidbody of the object the script is on is stored in shipRB.
        shipRB = GetComponent<Rigidbody>();
        //The game starts with the main camera in the view.
        mainCamera.enabled = true;
        leftCamera.enabled = false;
        rightCamera.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //When the "W" key is pressed down the current speed of the ship is increased.
        if (Input.GetKey(KeyCode.W))
        {
            speeds[0] = speeds[0] + (speeds[2] * Time.deltaTime);
        }
        //If the "W" is not pressed down the current of the speed is decreased.
        else
        {
            speeds[0] = speeds[0] - (speeds[3] * Time.deltaTime);
        }
        
        //If the current speed of the ship is bigger than 0.
        if (speeds[0] > 0)
        {
            //The object is translated in the z-axis (forward) by the current speed.
            transform.Translate(0, 0, speeds[0]);
        }
        //If the current speed is above the maximum speed. The speed is set to the maximum speed.
        if (speeds[0] > speeds[1]){
            speeds[0] = speeds[1];
        }

        //If the current speed is below zero, set to zero so the play doesn't begin to reverse.
        if (speeds[0] < 0)
        {
            speeds[0] = 0;
        }

        //If the "D" key is pressed the boat is rotated 15 Degrees.
        //The sails are rotated right using the animator and it's triggers.
        if (Input.GetKey(KeyCode.D))
        {
            animationController.SetBool("rightAniTrigger", true);
            transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime * 2, Space.World); 
        }
        
        //If the "A" key is pressed the boat is rotated -15 Degrees.
        //The sails are rotated left using the animator and it's triggers.
        else if(Input.GetKey(KeyCode.A))
        {
            animationController.SetBool("leftAniTrigger", true);
            transform.Rotate(new Vector3(0, -15, 0) * Time.deltaTime * 2, Space.World);
        }
        //If neither of the keys are pressed, both triggers are false 
        //so the animator returns the ship to it's normal state.
        else
        {
            animationController.SetBool("rightAniTrigger", false);
            animationController.SetBool("leftAniTrigger", false);
        }

        //If the "E" key is pressed then the left camera is enabled.
        //This achieved by disabling all other cameras.
        if (Input.GetKey(KeyCode.E))
        {
            leftCamera.enabled = true;
            rightCamera.enabled = false;
            mainCamera.enabled = false;
        }

        //If the "R" key is pressed then the main camera is enabled.
        //This achieved by disabling all other cameras.
        if (Input.GetKey(KeyCode.R))
        {
            rightCamera.enabled = false;
            mainCamera.enabled = true;
            leftCamera.enabled = false;
        }

        //If the "T" key is pressed then the right camera is enabled.
        //This achieved by disabling all other cameras.
        if (Input.GetKey(KeyCode.T))
        {
            rightCamera.enabled = true;
            mainCamera.enabled = false;
            leftCamera.enabled = false;
        }
    }
}
