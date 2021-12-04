using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlash : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    GameObject player;
    [HideInInspector] public float angle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Vector2 direction = player.transform.position - transform.position;
        direction = player.transform.InverseTransformDirection(direction);//new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.velocity = direction.normalized * speed;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamaage();
        }
    }
}
