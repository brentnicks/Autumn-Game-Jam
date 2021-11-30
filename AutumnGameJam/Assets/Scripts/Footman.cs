using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footman : MonoBehaviour
{

    public GameObject groundDetection;
    public float speed;
    public float waitTime;


   private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3 (speed * transform.right.x, GetComponent<Rigidbody2D>().velocity.y, 0);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            StartCoroutine(Patrol(waitTime, speed));
        }
    }


    IEnumerator Patrol(float waitTime, float speed)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, GetComponent<Rigidbody2D>().velocity.y, 0); ;
        yield return new WaitForSeconds(waitTime);
        gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        //GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, GetComponent<Rigidbody2D>().velocity.y, 0);
    }
}
