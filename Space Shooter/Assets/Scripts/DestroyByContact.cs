﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'Game Controller' script");
        }
    }


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary" || other.tag == "Asteroid" || other.tag == "Enemy" || other.tag == "Enemy Bolt") {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.End();
            gameController.GameOver();
            
        }
        else {
            gameController.AddScore(scoreValue); 
        }
        if (other.tag == "Laser Bolt")
        {
            Destroy(gameObject);           
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
       
    }
}
