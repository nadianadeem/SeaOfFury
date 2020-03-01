using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonPower : MonoBehaviour
{
    public Rigidbody cannonBallRB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shot");
        if(other.gameObject.tag == "attacker"){
            Debug.Log("hit something");
            Destroy(other.gameObject);
        }
    }
}
