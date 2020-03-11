using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    //The ending UI text for the game
    //One of these are shown once the player either dies or destroys all boats.
    public GameObject gameOverText;
    public GameObject winningText;
    
    //This is the particle system for the rain, this is toggled on and off.
    public GameObject rain;

    //The map is the ending screen for the game.
    public GameObject map;

    //The boat movement script of the player is stored here.
    //this is to change the speed value when it rains.
    public boatMovement bm;

    //The health bar is a UI slider element that shows the player's health visually.
    public healthBar playerHealth;

    //The player class object is stored here once the game has started.
    public playerClass player;
    
    //This integer keeps track of the score that the player gains.
    public int score = 0;
    
    //The text variable score is where the player is visually shown their score.
    //This is update throughout.
    public Text Score;

    //This method switches the rain particle system to active so
    //the player visually knows that their is a storm.
    void startRaining(){
        rain.SetActive(true);
        //When it rains the player speeds up and the declaration is decreased.
        //This is to give the player the feeling of losing control of the boat due to the storm.
        bm.speeds[1] = 0.08f;
        bm.speeds[3] = 0.005f;
    }

    //This method switches the rain particle system to inactive
    //so the player can no longer see it.
    void stopRaining(){
        rain.SetActive(false);
        //Once the rain has stopped the players values are reset back to the default values.
        bm.speeds[1] = 0.06f;
        bm.speeds[3] = 0.01f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //The resultion of the game is set here.
        Screen.SetResolution(1080, 720, true);
        //the object player is instantiated with the player class.
        player = new playerClass();
        //Using the mehtod in the UI slider the maximum value of the slider
        //is set to the health of the player, this is defined in the class.
        playerHealth.SetMaxHealth(player.health);
        //The ending texts, background and rain are set to inactive as 
        //the player should not see them yet.
        gameOverText.SetActive(false);
        winningText.SetActive(false);
        map.SetActive(false);
        rain.SetActive(false);
        //The time scale is set to one so the time is normal.
        Time.timeScale = 1;
        //These methods alternated using the invoke repeating functions.
        InvokeRepeating("startRaining", 60, 121);
        InvokeRepeating("stopRaining", 120, 60);
    }

    // Update is called once per frame
    void Update()
    {
        //The UI 
        Score.text = "Score " + score;
        playerHealth.SetHealth(player.health);
        if (player.health <= 0){
            gameOverText.SetActive(true);
            map.SetActive(true);
        }
        if (score == 1000){
            winningText.SetActive(true);
            map.SetActive(true);
        }
        
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "terrain"){
            player.health = player.takeHealth(player.health, 25);
            transform.Translate(Vector3.back * 1.0f);
        }
    }
}
