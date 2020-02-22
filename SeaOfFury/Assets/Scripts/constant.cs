using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constant : MonoBehaviour
{
    public Rigidbody shipRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shipRB.AddForce(0,1,0);
    }
}
