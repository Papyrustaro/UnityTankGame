using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Warp : MonoBehaviour
{
    private GameObject pareWarpPrefab;
    private bool warpAble = false;
    private MeshRenderer mr;
    private Warp exitWarp;
    private PutObject po;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitOb = other.gameObject.transform.root.gameObject;
        if (warpAble && (hitOb.CompareTag("Player")))
        {
            SetUseNotAble();
            exitWarp.SetUseNotAble();
            hitOb.transform.position = pareWarpPrefab.transform.position;
            StartCoroutine(DelayMethod(3f, () =>
            {
                SetUseAble();
                exitWarp.SetUseAble();
            }));
        }
    }

    public void SetUseAble()
    {
        warpAble = true;
        mr.material.color = new Color(0.77f, 0.59f, 0.84f, 0.74f);
    }
    public void SetUseNotAble()
    {
        warpAble = false;
        mr.material.color = new Color(0.77f, 0.59f, 0.84f, 0.25f);
    }

    public void DestroyWarp()
    {
        try
        {
            po.DestroyWarp();
        }
        catch (MissingReferenceException)
        {
        }
        Destroy(pareWarpPrefab);
        Destroy(this.gameObject);
    }
    public void SetPareWarp(GameObject pareWarp)
    {
        this.pareWarpPrefab = pareWarp;
        this.exitWarp = pareWarpPrefab.GetComponent<Warp>();
        StartCoroutine(DelayMethod(1f, () =>
        {
            SetUseAble();
            exitWarp.SetUseAble();
        }));
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
