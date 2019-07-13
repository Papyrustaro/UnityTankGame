using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombComeNear : MonoBehaviour
{
    private LandMine lm;
    private float countTime = 0f;
    private void Start()
    {
        lm = transform.parent.GetComponent<LandMine>();
    }
    private void Update()
    {
        countTime += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (countTime >= 1f && (other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            lm.SetColorRed();
            StartCoroutine(DelayMethod(0.5f, () =>
            {
                lm.Bomb();
            }));
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
