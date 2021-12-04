using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public GameObject projectile;
    public float timeBetweenAttacks;
    public GameObject EndGameWinUI;
    private int health = 3;
    GameObject player;
    bool isDead = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            player = collision.gameObject;
            StartCoroutine(RangedAttack());
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            player = collision.gameObject;
            StopAllCoroutines();
            Debug.Log("exit");
        }
    }

    public void TakeDamage()
    {
        --health;
        if (health <= 0)
        {
            StopAllCoroutines();
            animator.Play("Boss_Die");
            isDead = true;
            EndGameWinUI = GameObject.Find("GamePlayCanvas").transform.GetChild(3).gameObject;
            EndGameWinUI.SetActive(true);
        }
    }

    IEnumerator RangedAttack()
    {
        while (isDead == false)
        {
            yield return new WaitForSeconds(timeBetweenAttacks);
            if (player.transform.position.x >= transform.parent.position.x)
            {
                transform.parent.rotation = Quaternion.Euler(0, 0, 0);
                Debug.Log(player.transform.position.x > transform.parent.position.x);
            }
            else if (player.transform.position.x < transform.parent.position.x)
            {
                transform.parent.rotation = Quaternion.Euler(0, 180, 0);
                Debug.Log(player.transform.position.x > transform.parent.position.x);
            }
            animator.Play("Boss_Attack");
            Instantiate(projectile, transform.position, Quaternion.Euler(Vector3.zero));/*Quaternion.Euler(0f,0f,Vector3.Angle(player.transform.position, transform.right))*/
        }
    }
}
