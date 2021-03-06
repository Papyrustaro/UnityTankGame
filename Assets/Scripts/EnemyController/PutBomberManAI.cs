﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutBomberManAI : MonoBehaviour
{
    private PutObject po;
    private float countTime = 0f;
    public float putInterval = 7f;

    private void Awake()
    {
        po = GetComponent<PutObject>();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime > putInterval)
        {
            po.PutBombermanPrefab();
            countTime = 0f;
        }
    }

}
