using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject flagUI;
    public GameObject inputFieldCanvas;
    private InputField inputField;

    private void Awake()
    {
        if(MainGameController.gameNumber == 1)
        {
            inputField = inputFieldCanvas.transform.Find("InputPlayerName").gameObject.GetComponent<InputField>();
        }
    }

    private void Start()
    {
        InitInputPlayerName();
    }

    public string GetInputPlayerName()
    {
        return inputField.text;
    }

    public void InitInputPlayerName()
    {
        inputField.text = "";
    }

    public void FocusInputField()
    {
        // フォーカス
        inputField.ActivateInputField();
        inputField.Select();
        //Debug.Log("aaa");
    }
}
