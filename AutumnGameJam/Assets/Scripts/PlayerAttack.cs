using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public float attackCD;
    float timer;
    bool canAttack;

    public float attackRadius;

    private void Start()
    {
        timer = attackCD;
    }
    private void Update()
    {
        if (timer <= 0 && Input.GetButtonDown("Fire1"))
        {
            Collider2D[] hitResults = Physics2D.OverlapCircleAll(transform.position, attackRadius, LayerMask.GetMask("Enemy"));
            foreach (Collider2D collider in hitResults)
            {
                Debug.Log(collider.gameObject);
            }
            //if (hitResults.Length > 0)
            timer = attackCD;
            Debug.Log(hitResults.Length);
        }
        else timer -= Time.deltaTime;
        //Debug.Log(timer);
        animator.SetFloat("Attack", timer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
