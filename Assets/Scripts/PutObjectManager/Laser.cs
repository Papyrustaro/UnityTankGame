using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : MonoBehaviour
{
    private GameObject laser;
    private PutObject po;
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
        try
        {
            po.DestroyLaser();
        }
        catch (MissingReferenceException)
        {
        }
        Destroy(this.gameObject);
    }

    public void SetPutter(PutObject po)
    {
        this.po = po;
    }


    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
