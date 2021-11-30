using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public GameObject spawnPoint;
    public float attackRate;
    private float timer;

    private void Start()
    {
        timer = attackRate;
    }

    private void Update()
    {
        if (timer <= 0)
        {
            Instantiate(arrow, spawnPoint.transform.position, transform.rotation);
            timer = attackRate;
        }
        else timer -= Time.deltaTime;
    }

}
