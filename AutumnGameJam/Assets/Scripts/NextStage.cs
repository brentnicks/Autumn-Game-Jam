using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    public GameObject player;
    public GameObject gm;
    public GameObject[] Stages;
    public Camera camera;
    [HideInInspector] public int stageNumber = 1;
    public GameObject stageNumberText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(player))
        {
            gm.transform.position = new Vector3(0, gameObject.transform.position.y + 20.5f, 0);
            Instantiate(Stages[Random.Range(0,Stages.Length-1)], gm.transform.position, Quaternion.identity);
            camera.transform.position = new Vector3(0, camera.transform.position.y + 20.5f, -20);
            ++stageNumber;
            stageNumberText.GetComponent<Text>().text = stageNumber.ToString();

        }
    }
}
