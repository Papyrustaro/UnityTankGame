using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SecretButtonManager : MonoBehaviour
{
    //数値としてのパスワード。0を先頭におかない前提
    private int openKeyNumber = 4193;
    private int digit = 1000;
    private int inputNumByButton = 0;

    public GameObject keyNumText;
    public GameObject numButtons;
    public GameObject announce;
    private Text announceText;

    private void Awake()
    {
        announceText = announce.GetComponent<Text>();
    }

    public void InputValue(int n)
    {
        inputNumByButton += n * digit;
        //Debug.Log("inputValue:" + inputNumByButton);
        digit /= 10;
        if(digit == 0)
        {
            if(openKeyNumber == inputNumByButton)
            {
                PlayerPrefs.SetInt("UseableTank27", 1);
                //成功
                announceText.text = "戦車が解放されました";
                SEManager.PlaySound(SEManager.correctSound);
                StartCoroutine(DelayMethod(2f, () =>
                {
                    announceText.text = "";
                }));
            }
            else
            {
                announceText.text = "キーが違います";
                SEManager.PlaySound(SEManager.incorrectSound);
                StartCoroutine(DelayMethod(2f, () =>
                {
                    announceText.text = "";
                }));
            }
            digit = 1000;
            inputNumByButton = 0;
        }
    }

    public void OnPressSecret()
    {
        numButtons.SetActive(false);
        keyNumText.SetActive(true);
        StartCoroutine(DelayMethod(3f, () =>
        {
            keyNumText.SetActive(false);
            numButtons.SetActive(true);
        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
