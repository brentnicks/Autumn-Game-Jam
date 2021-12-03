using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb.velocity = Quaternion.Euler(0f, 0f, Vector3.Angle(player.transform.position, transform.up)) * new Vector2(speed, 0);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamaage();
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
