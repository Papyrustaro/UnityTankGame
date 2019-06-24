using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    private bool mainCameraON = true;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainCameraON = false;
        }else if(Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainCameraON = true;
        }
    }
}
