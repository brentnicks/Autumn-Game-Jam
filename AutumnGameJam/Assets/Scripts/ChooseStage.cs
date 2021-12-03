using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour
{
    public GameObject NextStage;

    public void LeftButtonPressed()
    {
        NextStage.GetComponent<NextStage>().LeftButtonPressed();
    }

    public void MiddleButtonPressed()
    {
        NextStage.GetComponent<NextStage>().MiddleButtonPressed();
    }
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}