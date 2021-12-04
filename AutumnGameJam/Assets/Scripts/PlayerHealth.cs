using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject EndGameDieUI;
    public List<GameObject> hearts;

    public void TakeDamaage()
    {
        Destroy(hearts[hearts.Count - 1]);
        hearts.RemoveAt(hearts.Count - 1);

        if (hearts.Count <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<Animator>().SetFloat("Speed", 0);
            GetComponent<Animator>().SetBool("Jump", false);
            StartCoroutine(WaitAndStop());
        }
    }
    private IEnumerator WaitAndStop()
    {
        yield return new WaitUntil(() => GetComponent<PlayerMovement>().grounded);
        GetComponent<Animator>().Play("Player_Die");
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
        EndGameDieUI.SetActive(true);
    }
}
