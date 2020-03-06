using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCannonManager : MonoBehaviour
{
    public float exitRate = 5.0f;
    public float exitTime = 5.0f;
    public GameObject enemy;
    public enemyGameMaster gm;
    // Start is called before the first frame update
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shot");
        if(other.gameObject.tag == "attacker"){
            gm = other.GetComponent<enemyGameMaster>();
            Debug.Log("hit something");
            gm.attacker.health = gm.attacker.takeHealth(gm.attacker.health, gm.attacker.damage);
        }
    }
}
