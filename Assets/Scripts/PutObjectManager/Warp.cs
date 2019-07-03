using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Warp : MonoBehaviour
{
    public GameObject exitWarpPrefab;
    private bool warpAble = true;
    private MeshRenderer mr;
    private Warp exitWarp;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        exitWarp = exitWarpPrefab.GetComponent<Warp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitOb = other.gameObject.transform.root.gameObject;
        if (warpAble && (hitOb.CompareTag("Player") || hitOb.CompareTag("Enemy")))
        {
            SetUseNotAble();
            exitWarp.SetUseNotAble();
            hitOb.transform.position = exitWarpPrefab.transform.position;
            StartCoroutine(DelayMethod(3f, () =>
            {
                SetUseAble();
                exitWarp.SetUseAble();
            }));
        }
    }

    private void SetUseAble()
    {
        warpAble = true;
        mr.material.color = new Color(0.77f, 0.59f, 0.84f, 0.74f);
    }
    private void SetUseNotAble()
    {
        warpAble = false;
        mr.material.color = new Color(0.77f, 0.59f, 0.84f, 0.25f);
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
