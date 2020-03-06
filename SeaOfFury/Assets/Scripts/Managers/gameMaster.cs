﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameMaster : MonoBehaviour
{
    public GameObject gameOverText;

    public healthBar playerHealth;

    public playerClass player;


    // Start is called before the first frame update
    void Start()
    {
        player = new playerClass();
        playerHealth.SetMaxHealth(player.health);
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.SetHealth(player.health);
        if (player.health <= 0){
            gameOverText.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "terrain"){
            player.health = player.takeHealth(player.health, 25);
            transform.Translate(Vector3.back * 1.0f);
        }
    }
}
