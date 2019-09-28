using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject DeleteAllDataButton;
    public GameObject DeleteTemporaryButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)){
            DeleteAllDataButton.SetActive(true);
            DeleteTemporaryButton.SetActive(true);
        }
    }
}
