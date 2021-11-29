using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Time.timeScale = 0;
            Debug.LogError("Game Over!");
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
