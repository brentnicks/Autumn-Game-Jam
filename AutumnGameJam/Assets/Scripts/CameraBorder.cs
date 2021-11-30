using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Time.timeScale = 0;
            Debug.LogError("Game Over!");
        }
        Destroy(collision.gameObject);
    }
}
