using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutShooterAI : MonoBehaviour
{
    private PutObject po;
    private float countTime = 0f;
    public float putInterval = 7f;
    private RaycastHit hit;

    private void Awake()
    {
        po = GetComponent<PutObject>();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > putInterval)
        {
            PutShooter();
        }
    }

    private void PutShooter()
    {
        GameObject head = transform.Find("Head").gameObject;
        GameObject turret = transform.Find("Turret").gameObject;
        Physics.Raycast(turret.transform.position, turret.transform.position - head.transform.position, out hit, 100f);

        if(hit.distance > 5f)
        {
            po.PutBatteryPrefab();
            countTime = 0f;
        }
        else
        {
            countTime = putInterval - 2f;
        }
    }
}
