using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextStage : MonoBehaviour
{
    public GameObject ChooseUI;

    public GameObject player;
    public GameObject gm;
    public GameObject instantiatePosition;
    public GameObject[] Stages;
    public Sprite[] StagesImages;
    public Camera mainCamera;
    private Vector3 cameraTargetPosition;
    [HideInInspector] public int stageNumber = 1;
    public GameObject stageNumberText;
    
    public GameObject button1;
    public GameObject button2;

    int option1;
    int option2;

    List<int> usedStages = new List<int>();

    private void Start()
    {
        cameraTargetPosition = mainCamera.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.Equals(player) && stageNumber < 4)
        {
            Time.timeScale = 0;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerAttack>().enabled = false;
            //Change camera target position
            gm.transform.position = new Vector3(gm.transform.position.x, gameObject.transform.position.y + 21.5f, 0);
            //Instantiate(Stages[Random.Range(0,Stages.Length-1)], instantiatePosition.transform.position, Quaternion.identity);
            cameraTargetPosition = new Vector3(gm.transform.position.x, mainCamera.transform.position.y + 21.5f, -20);

            ++stageNumber;
            stageNumberText.GetComponent<Text>().text = stageNumber.ToString();

            //Choose Next Level
            option1 = Random.Range(0, Stages.Length);
            while (usedStages.Contains(option1)) option1 = Random.Range(0, Stages.Length);
            option2 = Random.Range(0, Stages.Length);
            while (option2 == option1 || usedStages.Contains(option2)) option2 = Random.Range(0, Stages.Length);
            //Debug.Log(option1 + " " + option2 + " " + option3);
            button1.GetComponent<Image>().sprite = StagesImages[option1];
            button2.GetComponent<Image>().sprite = StagesImages[option2];
            ChooseUI.SetActive(true);
        }
    }

    private void Update()
    {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraTargetPosition, 6f * Time.deltaTime);
    }

    public void LeftButtonPressed()
    {
        Debug.Log("Left");
        usedStages.Add(option1);
        SpawnNextStage(option1);
    }

    public void MiddleButtonPressed()
    {
        Debug.Log("Middle");
        usedStages.Add(option2);
        SpawnNextStage(option2);
    }

    public void SpawnNextStage(int option)
    {
        Instantiate(Stages[option], instantiatePosition.transform.position, transform.rotation);
        ChooseUI.SetActive(false);
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
    }

}
