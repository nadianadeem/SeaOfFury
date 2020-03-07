using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyCannonManager : MonoBehaviour
{   
    public GameObject player;
    public gameMaster gm;

    public GameObject enemy;
    public enemyGameMaster enemyGameMaster;
    // Start is called before the first frame update

    void Awake(){
        enemy = GameObject.FindGameObjectWithTag("attacker");
        enemyGameMaster = enemy.GetComponent<enemyGameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        gm = player.GetComponent<gameMaster>();
    }

    void Start(){
        Destroy(gameObject, 5.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            gm.player.health = gm.player.takeHealth(gm.player.health, enemyGameMaster.attacker.damage);
        }
    }
}
