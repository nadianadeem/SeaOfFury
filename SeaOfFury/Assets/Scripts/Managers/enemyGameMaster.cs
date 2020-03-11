using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGameMaster : MonoBehaviour
{
    //A public variable which is defined as an attacker class is created but nothing is stored yet.
    //This is so other scripts can access the variables created for the attacker class.
    
    public attackerClass attacker;
    // Start is called before the first frame update
    void Start()
    {
        //When a ship is created they all have their own respective attacker class.
        attacker = new attackerClass();
    }

    // Update is called once per frame
    void Update()
    {
        //if the attacker has no health left it is destroyed.
        if (attacker.health == 0){
                Destroy(gameObject);
            }
    }
}
