using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constant : MonoBehaviour
{
    //A public rigidbody is created to add force to it.
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        //constantly adds force down on the ships is make sure it's on the plane.
        rb.AddForce(0,1,0);
    }
}
