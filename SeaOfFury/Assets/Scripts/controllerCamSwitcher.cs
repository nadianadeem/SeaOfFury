using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerCamSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera leftCamera;
    public Camera rightCamera;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("leftCannonCam"))
        {
            leftCamera.enabled = true;
            rightCamera.enabled = false;
            mainCamera.enabled = false;
        }

        if (Input.GetButtonDown("frontCannonCam"))
        {
            rightCamera.enabled = false;
            mainCamera.enabled = true;
            leftCamera.enabled = false;
        }

        if (Input.GetButtonDown("rightCannonCam"))
        {
            rightCamera.enabled = true;
            mainCamera.enabled = false;
            leftCamera.enabled = false;
        }
    }
}
