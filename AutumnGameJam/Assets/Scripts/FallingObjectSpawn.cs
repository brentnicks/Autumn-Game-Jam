using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{
    public float spawnTimer;
    float timer = 0;
    public GameObject[] objects;

    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z), Quaternion.identity);
            timer = spawnTimer;
        }
    }
}
