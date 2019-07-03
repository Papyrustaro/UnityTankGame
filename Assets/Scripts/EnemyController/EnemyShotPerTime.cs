using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotPerTime : MonoBehaviour
{
    public float shotInterval;
    private float countTime = 0f;
    private EnemyShotManager esm;

    private void Start()
    {
        esm = GetComponent<EnemyShotManager>();
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        if(shotInterval <= countTime)
        {
            esm.Shot();
            countTime = 0f;
        }
    }
}
