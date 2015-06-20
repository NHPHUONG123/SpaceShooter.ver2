using UnityEngine;
using System.Collections;

public class DestroyByShot : MonoBehaviour {
    private GameController gameController;
    public GameObject explosion;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'Game Controller' script");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary" || other.tag == "Asteroid" || other.tag == "Enemy") {
            return;
        }
        else if (other.tag == "Player") {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameController.End();
            gameController.GameOver();
        }
        Destroy(gameObject);
    }
    
}
