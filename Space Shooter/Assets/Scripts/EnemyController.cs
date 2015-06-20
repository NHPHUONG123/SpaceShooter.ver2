using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public float fireRate;
    private float nextFire;
    public GameObject shotEnemy;
    public Transform shotEnemySpawn;
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shotEnemy, shotEnemySpawn.position, shotEnemySpawn.rotation);// as GameObject;
            GetComponent<AudioSource>().Play();        

        }
    }

}
