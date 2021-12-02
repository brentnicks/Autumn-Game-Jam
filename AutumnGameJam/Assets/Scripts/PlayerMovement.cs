using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float jumpHeight;
    public Animator animator;

    [HideInInspector] public bool grounded;

    void Update()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, player.GetComponent<Rigidbody2D>().velocity.y);
        animator.SetFloat("Speed", Mathf.Abs (Input.GetAxisRaw("Horizontal") * speed));
        
        if (Input.GetAxisRaw("Horizontal") > 0) transform.rotation = new Quaternion(0, 0, 0, 0);

        if (Input.GetAxisRaw("Horizontal") < 0) transform.rotation = new Quaternion(0, 180, 0, 0);

        if (grounded == true && Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, jumpHeight));
        }

        if (grounded == false)
        {
            animator.SetBool("Jump", true);
        }
        else animator.SetBool("Jump", false);

    }
}