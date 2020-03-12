using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyCannonManager : MonoBehaviour
{   
    //Both the player and enemy objects are added to the script along with both game master scripts.
    public GameObject player;
    public gameMaster gm;
    public GameObject enemy;
    public enemyGameMaster enemyGameMaster;
    
    //Just before the object is instantiated, both the enemy and player with their respective game master scripts
    //are set as the variables declared above.
    void Awake(){
        enemy = GameObject.FindGameObjectWithTag("attacker");
        enemyGameMaster = enemy.GetComponent<enemyGameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        gm = player.GetComponent<gameMaster>();
    }

    //Once the object is instantiated it will then be destoryed in 5 seconds time.
    //This is to save memory so the game doesn't crash from all the cannon balls that are fired.
    void Start(){
        Destroy(gameObject, 5.0f);
    }

    //When the enemy's cannon ball hits the player the health variable
    //in the player's game master script has the damage
    //stored in the game master script taken away from it.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            gm.player.health = gm.player.takeHealth(gm.player.health, enemyGameMaster.attacker.damage);
        }
    }
}
