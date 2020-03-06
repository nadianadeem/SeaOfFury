using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGameMaster : MonoBehaviour
{
    public attackerClass attacker;
    // Start is called before the first frame update
    void Start()
    {
        attacker = new attackerClass();
    }

    // Update is called once per frame
    void Update()
    {
        if (attacker.health == 0){
                Destroy(gameObject);
            }
    }
}
