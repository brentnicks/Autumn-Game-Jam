using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public float attackCD;
    public Transform AttackPosition;
    float timer;


    private void Start()
    {
        timer = attackCD;
    }
    private void Update()
    {
        if (timer <= 0 && Input.GetButtonDown("Fire1"))
        {
            Collider2D[] hitResults = Physics2D.OverlapBoxAll(AttackPosition.position, new Vector3 (1.55f,1.8f,0), 0, LayerMask.GetMask("Enemy"));
            foreach (Collider2D collider in hitResults)
            {
                Debug.Log(collider.gameObject);
                Destroy(collider.gameObject);
            }
            //if (hitResults.Length > 0)
            timer = attackCD;
            Debug.Log(hitResults.Length);
            animator.Play("Player_Attack");
        }
        else timer -= Time.deltaTime;
        //Debug.Log(timer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(AttackPosition.position, new Vector3(1.55f,1.8f,0));
    }
}
