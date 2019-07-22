using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PutRemoteBombAI : MonoBehaviour
{
    private float countTime = 0f;
    private PutObject po;
    private EnemyController ec;
    private GameObject target;
    private GameObject remoteBomb;
    private bool isPutBomb = false;

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
        if (!isPutBomb)
        {
            PutBomb();
        }
        countTime += Time.deltaTime;

        if(countTime > 0.5f && isPutBomb)
        {
            //爆弾が攻撃によって爆破されたとき
            try
            {
                ec.TurnCannon(target.transform.position - remoteBomb.transform.position);
                if (Vector3.Distance(target.transform.position, remoteBomb.transform.position) < 5f)
                {
                    po.PutRemoteBombPrefab();
                    isPutBomb = false;
                }
            }
            catch (MissingReferenceException)
            {
                isPutBomb = false;
            }
            countTime = 0f;
        }
    }

    private void PutBomb()
    {
        po.PutRemoteBombPrefab();
        remoteBomb = po.GetRemoteBomb();
        isPutBomb = true;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
