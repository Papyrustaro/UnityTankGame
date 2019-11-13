using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButtonPress : MonoBehaviour
{
    public int buttonNum;
    private SecretButtonManager sbm;
    public GameObject buttonCanvas;

    private void Awake()
    {
        sbm = buttonCanvas.GetComponent<SecretButtonManager>();
    }

    public void OnPress()
    {
        sbm.InputValue(this.buttonNum);
    }
}
