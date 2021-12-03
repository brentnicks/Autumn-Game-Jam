using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseStage : MonoBehaviour
{
    public GameObject NextStage;

    public void LeftButtonPressedf()
    {
        NextStage.GetComponent<NextStage>().LeftButtonPressed();
    }

    public void MiddleButtonPressed()
    {
        NextStage.GetComponent<NextStage>().MiddleButtonPressed();
    }

    public void RightButtonPressed()
    {
        NextStage.GetComponent<NextStage>().RightButtonPressed();
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}