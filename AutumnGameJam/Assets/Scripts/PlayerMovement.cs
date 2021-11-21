using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float jumpHeight;
    [HideInInspector] public bool canJump = true;

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, player.GetComponent<Rigidbody2D>().velocity.y);

        if (canJump == true && Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            canJump = false;
        }
    }
}
