﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Using cái thư viện này để dùng những thứ trong Canvas

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public GameObject hazard2;
    public Vector3 spawnValue;
    public Vector3 spawnValue1;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text highScoreText;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    public int highScore;
    private int score; 
    void Start() {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        if (PlayerPrefs.HasKey("High Score") == true) {
           highScore = PlayerPrefs.GetInt("High Score");
        }
        UpdateScore();
        UpdateHighScore();
        StartCoroutine (SpawnWaves());
    }
    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver)
                {
                    restartText.text = "Press R for Restart";
                    restart = true;
                    break;
                } 
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Vector3 spawnPosition1 = new Vector3(Random.Range(-spawnValue1.x, spawnValue.x), spawnValue1.y, spawnValue1.z);
                Quaternion spawnRotation1 = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                Instantiate(hazard2, spawnPosition1, spawnRotation1);
                yield return new WaitForSeconds(spawnWait);
 
            }
            yield return new WaitForSeconds(waveWait);
            
        }
    }
    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore() {
        scoreText.text = "Score: " + score.ToString();
    }
    public void End() {
        if (score < highScore) return;
        else
        {
            highScore = score;
            UpdateHighScore();
            PlayerPrefs.SetInt("High Score", highScore);
        }
    }
    void UpdateHighScore() {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
