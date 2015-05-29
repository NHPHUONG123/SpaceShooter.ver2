using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {
    void OnTriggerExit(Collider other) {
        if (other.tag == "Laser Bolt") {
            return;
        }
        Destroy(other.gameObject); 
    }
}
