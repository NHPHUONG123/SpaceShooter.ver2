using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {
    public float lifeTime;
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && other.tag == "Boundary")
        {
            return;
        }
        else Start();
    }
    void Start() {
        Destroy(gameObject, lifeTime);
    }
}
