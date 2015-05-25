using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Using cái thư viện này để dùng những thứ trong Canvas

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValue;
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
    public int lastHighScore;
    private int score; 
    void Start() {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        UpdateHighScore();
        StartCoroutine (SpawnWaves());
    }
    void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
                highScore = lastHighScore;

            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver) {
                restartText.text = "Press R for Restart";
                restart = true;
                highScore = lastHighScore;
                break;
            } 
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
            lastHighScore = highScore;
            UpdateHighScore();
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
