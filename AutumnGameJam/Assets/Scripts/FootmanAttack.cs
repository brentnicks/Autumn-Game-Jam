using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootmanAttack : MonoBehaviour
{
    GameObject Footman;

    bool canAttack = true;

        private void Start()
    {
        Footman = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && canAttack)
        {
            canAttack = false;
            Footman.GetComponent<Footman>().moving = false;
            StartCoroutine(Footman.GetComponent<Footman>().PauseAndHit());
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
