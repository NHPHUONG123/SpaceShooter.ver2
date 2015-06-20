using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
    void OnTriggerExit(Collider other) {
        if (other.tag == "Laser Bolt" || other.tag == "Enemy") {
            return;
        }
        Destroy(other.gameObject); 
    }
}
