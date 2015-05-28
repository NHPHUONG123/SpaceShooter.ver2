using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject shot1;
    public Transform shot1Spawn;
    public GameObject shot2;
    public Transform shot2Spawn;
    public GameObject shot3;
    public Transform shot3Spawn;
    public GameObject shot4;
    public Transform shot4Spawn;
    public GameObject shot5;
    public Transform shot5Spawn;
    public GameObject shot6;
    public Transform shot6Spawn;
    public GameObject shot7;
    public Transform shot7Spawn;
    public GameObject shot8;
    public Transform shot8Spawn;
    public GameObject shot9;
    public Transform shot9Spawn;
    public float speed;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);// as GameObject;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot1, shot1Spawn.position, shot1Spawn.rotation);
            Instantiate(shot2, shot2Spawn.position, shot2Spawn.rotation);
            Instantiate(shot3, shot3Spawn.position, shot3Spawn.rotation);
            Instantiate(shot4, shot4Spawn.position, shot4Spawn.rotation);
            Instantiate(shot5, shot5Spawn.position, shot5Spawn.rotation);
            Instantiate(shot6, shot6Spawn.position, shot6Spawn.rotation);
            Instantiate(shot7, shot7Spawn.position, shot7Spawn.rotation);
            Instantiate(shot8, shot8Spawn.position, shot8Spawn.rotation);
            Instantiate(shot9, shot9Spawn.position, shot9Spawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3 (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
