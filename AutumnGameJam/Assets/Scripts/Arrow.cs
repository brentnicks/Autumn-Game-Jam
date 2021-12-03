using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
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
