using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winningText;

    public GameObject map;

    public healthBar playerHealth;

    public playerClass player;
    public int score = 0;
    public Text Score;


    // Start is called before the first frame update
    void Start()
    {
        player = new playerClass();
        playerHealth.SetMaxHealth(player.health);
        gameOverText.SetActive(false);
        winningText.SetActive(false);
        map.SetActive(false);
        Time.timeScale = 1;
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
