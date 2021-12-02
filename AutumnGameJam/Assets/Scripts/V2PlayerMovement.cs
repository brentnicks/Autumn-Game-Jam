using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2PlayerMovement : MonoBehaviour
{
    public GameObject player;
    
    public Animator animator;
    public float speed;
    public float jumpHeight;

    [HideInInspector] public bool canJump = true;

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, player.GetComponent<Rigidbody2D>().velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (canJump == true && Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpHeight));
            canJump = false;
        }
    }
}
