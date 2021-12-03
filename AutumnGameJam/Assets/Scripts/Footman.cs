using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{

    public GameObject groundDetection;
    public float speed;
    public float waitTime;
    public Animator animator;
    Rigidbody2D rb;
    [HideInInspector] public bool moving = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && moving == true)
        {
            rb.velocity = new Vector3(speed * transform.right.x, rb.velocity.y, 0);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            moving = false;
            StopAllCoroutines();
            StartCoroutine(Patrol(waitTime, speed));
        }
    }

    IEnumerator Patrol(float waitTime, float speed)
    {
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        yield return new WaitForSeconds(waitTime);
        gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        moving = true;
        //GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, GetComponent<Rigidbody2D>().velocity.y, 0);
    }

    /*public void Attack()
    {
        //rb.velocity = Vector2.zero;
        StartCoroutine(PauseAndHit());
    }*/

    public IEnumerator PauseAndHit()
    {
        while (Physics2D.OverlapBoxAll(transform.GetChild(1).position, new Vector2(1.6f,1.6f), 0, LayerMask.GetMask("Player")).Length > 0)
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            yield return new WaitForSeconds(0.5f);
            animator.Play("Footman_Attack");
            if (Physics2D.OverlapBoxAll(transform.GetChild(1).position, new Vector2(1.6f, 1.6f), 0, LayerMask.GetMask("Player")).Length > 0)
            {
                GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamaage();
            }
            yield return new WaitForSeconds(0.5f);
        }
        rb.velocity = new Vector3(speed * transform.right.x, rb.velocity.y, 0);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.GetChild(1).position, new Vector3(1.6f, 1.6f, 0));
    }
}
