using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButtonManager : MonoBehaviour
{
    //数値としてのパスワード。0を先頭におかない前提
    private int openKeyNumber = 4193;
    private int digit = 1000;
    private int inputNumByButton = 0;

    public void InputValue(int n)
    {
        inputNumByButton += n * digit;
        Debug.Log("inputValue:" + inputNumByButton);
        digit /= 10;
        if(digit == 0)
        {
            if(openKeyNumber == inputNumByButton)
            {
                Debug.Log("secretON");
                for(int i = 21; i < 28; i++)
                {
                    PlayerPrefs.SetInt("UseableTank" + i, 1);
                }
                //成功
            }
            else
            {
                SEManager.PlaySound(SEManager.cannotSound);
            }
            digit = 1000;
            inputNumByButton = 0;
        }
    }
}
