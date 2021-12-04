using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraAndUI : MonoBehaviour
{
    public GameObject UI;
    public GameObject mainCamera;
    public GameObject gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            UI.SetActive(true);
            mainCamera.GetComponent<V2CameraFollow>().enabled = false;
            mainCamera.transform.position = new Vector3(gm.transform.position.x, gm.transform.position.y, mainCamera.transform.position.z);

        }
    }
}
