using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject fallingGameSpawner;
    public GameObject player;
    public GameObject[] Stages;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(player))
        {
            fallingGameSpawner.transform.position = new Vector3(0, gameObject.transform.position.y + 50, 0);
            Instantiate(Stages[Random.Range(0,Stages.Length-1)], fallingGameSpawner.transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
