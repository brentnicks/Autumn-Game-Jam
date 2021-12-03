using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public GameObject projectile;
    public float timeBetweenAttacks;
    private int health = 3;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
        player = collision.gameObject;
        }
    }

    public void TakeDamage()
    {
        --health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RangedAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        Instantiate(projectile, transform.position, Quaternion.Euler(0f,0f,Vector3.Angle(player.transform.position, transform.up)));
    }
}
