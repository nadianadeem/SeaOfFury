using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCannonManager : MonoBehaviour
{
    public float exitRate = 5.0f;
    public float exitTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shot");
        if(other.gameObject.tag == "Player"){
            Debug.Log("hit player");
            Destroy(other.gameObject);
        }
    }
}
