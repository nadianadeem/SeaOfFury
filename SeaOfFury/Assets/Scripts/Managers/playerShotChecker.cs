using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShotChecker : MonoBehaviour
{
    //The player object is added 
    //to the script along with both game master scripts for the player and enemy.
    public GameObject player;
    public gameMaster gameMaster;
    public enemyGameMaster gm;
    
    //Just before the object is instantiated, both the enemy and player with their respective game master scripts
    //are set as the variables declared above.
    //Once the object is instantiated it will then be destoryed in 5 seconds time.
    //This is to save memory so the game doesn't crash from all the cannon balls that are fired.
    void Start()
    {
        Destroy(gameObject, 2.0f);
        player = GameObject.FindGameObjectWithTag("Player");
        gameMaster = player.GetComponent<gameMaster>();
    }

    //When the player's cannon ball hits the enemy the health variable 
    //in the enemys's game master script has damage subtracted from it.
    //100 is added to the player's score to reward the user for hitting
    //the enemy ship.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("shot");
        if(other.gameObject.tag == "attacker"){
            Debug.Log("enemy");
            gm = other.GetComponent<enemyGameMaster>();
            gameMaster.score += 100;
            gm.attacker.health = gm.attacker.takeHealth(gm.attacker.health, gm.attacker.damage);
        }
    }
}
