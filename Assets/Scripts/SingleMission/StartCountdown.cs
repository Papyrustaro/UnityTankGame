using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartCountdown : MonoBehaviour
{
    private Text countDownText;

    private void Awake()
    {
        countDownText = GetComponent<Text>();
    }
    private void Start()
    {
        StartCoroutine(DelayMethod(3f, () =>
        {
            countDownText.text = "3";
            SEManager.PlaySound(SEManager.countDownSound);
        }));
        StartCoroutine(DelayMethod(4f, () =>
        {
            countDownText.text = "2";
            SEManager.PlaySound(SEManager.countDownSound);
        }));
        StartCoroutine(DelayMethod(5f, () =>
        {
            countDownText.text = "1";
            SEManager.PlaySound(SEManager.countDownSound);
        }));
        StartCoroutine(DelayMethod(6f, () =>
        {
            this.transform.root.gameObject.SetActive(false);
        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
