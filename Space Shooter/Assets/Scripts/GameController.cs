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
    public int highScore;
    public int lastHighScore;
    private int score; 
    void Start() {
        score = 0;
        highScore = lastHighScore;
        UpdateScore();
        UpdateHighScore();
        StartCoroutine (SpawnWaves());
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
        if (score <= highScore) return;
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
}
