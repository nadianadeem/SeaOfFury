using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCannonManager : MonoBehaviour
{

    public GameObject player;
    public gameMaster gameMaster;
    public GameObject enemy;
    public enemyGameMaster gm;
    // Start is called before the first frame update
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
        player = GameObject.FindGameObjectWithTag("Player");
        gameMaster = player.GetComponent<gameMaster>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shot");
        if(other.gameObject.tag == "attacker"){
            gm = other.GetComponent<enemyGameMaster>();
            gameMaster.score += 100;
            gm.attacker.health = gm.attacker.takeHealth(gm.attacker.health, gm.attacker.damage);
        }
    }
}
