using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            foreach (GameObject Hearts in collision.GetComponent<PlayerHealth>().hearts.ToArray())
            {
                collision.GetComponent<PlayerHealth>().TakeDamaage();
            }
        }

    }
}
