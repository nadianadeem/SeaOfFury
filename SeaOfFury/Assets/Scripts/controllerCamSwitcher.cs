using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerCamSwitcher : MonoBehaviour
{
    //Stores all the camera used for the player's boat.
    public Camera mainCamera;
    public Camera leftCamera;
    public Camera rightCamera;

    // Update is called once per frame
    void Update()
    {
        //If the X button is pressed then the prevalent camera is swicted to the left camera.
        if (Input.GetButtonDown("leftCannonCam"))
        {
            leftCamera.enabled = true;
            rightCamera.enabled = false;
            mainCamera.enabled = false;
        }
        //If the Y button is pressed then the prevalent camera is swicted to the front camera.
        if (Input.GetButtonDown("frontCannonCam"))
        {
            rightCamera.enabled = false;
            mainCamera.enabled = true;
            leftCamera.enabled = false;
        }
        //If the B button is pressed then the prevalent camera is swicted to the right camera.
        if (Input.GetButtonDown("rightCannonCam"))
        {
            rightCamera.enabled = true;
            mainCamera.enabled = false;
            leftCamera.enabled = false;
        }
    }
}
