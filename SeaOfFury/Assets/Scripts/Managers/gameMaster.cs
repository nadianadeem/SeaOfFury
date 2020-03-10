using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winningText;
    public GameObject rain;


    public GameObject map;

    public boatMovement bm;

    public healthBar playerHealth;

    public playerClass player;
    public int score = 0;
    public Text Score;

    void startRaining(){
        rain.SetActive(true);
        bm.speeds[1] = 0.08f;
        bm.speeds[3] = 0.005f;
    }

    void stopRaining(){
        rain.SetActive(false);
        bm.speeds[1] = 0.06f;
        bm.speeds[3] = 0.01f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1080, 720, true);
        player = new playerClass();
        playerHealth.SetMaxHealth(player.health);
        gameOverText.SetActive(false);
        winningText.SetActive(false);
        map.SetActive(false);
        rain.SetActive(false);
        Time.timeScale = 1;
        InvokeRepeating("startRaining", 60, 121);
        InvokeRepeating("stopRaining", 120, 60);
    }

    // Update is called once per frame
    void Update()
    {
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
