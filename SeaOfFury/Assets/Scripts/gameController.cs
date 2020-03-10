using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public float[] speeds = new float[4] {0.0f, 0.06f, 0.02f, 0.01f};

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
        if (Input.GetAxis("Vertical") > 0)
        {
            speeds[0] = speeds[0] + (speeds[2] * Time.deltaTime);
        }
        else
        {
            speeds[0] = speeds[0] - (speeds[3] * Time.deltaTime);
        }
        
        if (speeds[0] > 0)
        {
            transform.Translate(0, 0, speeds[0]);
        }
        if (speeds[0] > speeds[1]){
            speeds[0] = speeds[1];
        }

        if (speeds[0] < 0)
        {
            speeds[0] = 0;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            animationController.SetBool("rightAniTrigger", true);
            transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime * 2, Space.World); 
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            animationController.SetBool("leftAniTrigger", true);
            transform.Rotate(new Vector3(0, -15, 0) * Time.deltaTime * 2, Space.World);
        }
        else
        {
            animationController.SetBool("rightAniTrigger", false);
            animationController.SetBool("leftAniTrigger", false);
        }

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
