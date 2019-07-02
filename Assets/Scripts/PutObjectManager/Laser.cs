using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : MonoBehaviour
{
    private GameObject laser;
    private void Start()
    {
        laser = this.gameObject.transform.Find("Laser").gameObject;
        StartCoroutine(DelayMethod(3f, () =>
        {
            ShotLaser();
        }));
        StartCoroutine(DelayMethod(4f, () =>
        {
            DestroyLaser();
        }));
    }

    private void ShotLaser()
    {
        laser.SetActive(true);
    }
    private void DestroyLaser()
    {
        Destroy(this.gameObject);
    }


    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
