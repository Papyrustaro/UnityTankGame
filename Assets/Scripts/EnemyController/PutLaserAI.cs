using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutLaserAI : MonoBehaviour
{
    private GameObject target;
    private PutObject po;
    private float countTime = 0f;
    public float putInterval = 7f;

    private void Awake()
    {
        po = GetComponent<PutObject>();
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > putInterval)
        {
            transform.LookAt(target.transform);
            po.PutLaserPrefab();
            countTime = 0f;
        }
    }
}
