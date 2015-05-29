using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    public float lifeTime;
    
    public void Start() {
        Destroy(gameObject, lifeTime);
    }
}
