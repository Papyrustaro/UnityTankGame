using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour, TriggerFuncInterface
{
    /*----------------------------*/
    private PutObject po;
    private EnemyController ec;
    private EnemyShotManager esm;
    /*----------------------------*/

    void Awake()
    {
        po = transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        ec = GetComponent<EnemyController>();
        ec.SetTriggerFunc(BodyEnter, BodyExit, BodyStay, NearEnter, NearExit, NearStay);
        esm = GetComponent<EnemyShotManager>();
    }

    public void BodyEnter(Collider other)
    {
    }
    public void BodyExit(Collider other)
    {
    }
    public void BodyStay(Collider other)
    {
    }
    public void NearEnter(Collider other)
    {
    }
    public void NearExit(Collider other)
    {
    }
    public void NearStay(Collider other)
    {
    }
}
