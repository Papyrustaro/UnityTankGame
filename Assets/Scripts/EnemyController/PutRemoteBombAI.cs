using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRemoteBombAI : MonoBehaviour
{
    private float countTime = 0f;
    private PutObject po;
    private EnemyController ec;
    private GameObject target;

    private void Awake()
    {
        po = GetComponent<PutObject>();
        ec = transform.root.gameObject.GetComponent<EnemyController>();
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
