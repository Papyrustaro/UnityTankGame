using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShotAI : MonoBehaviour
{
    public int bulletBounceNum = 0;
    public float checkInterval = 0.25f;
    private EnemyController ec;
    private EnemyShotManager esm;
    private float countTime = 0f;
    private GameObject target;
    private GameObject cannon;
    private bool toPlayerNotWall; //自分とプレイヤーの間に障害物がないか 

    private void Awake()
    {
        ec = GetComponent<EnemyController>();
        esm = GetComponent<EnemyShotManager>();
        cannon = transform.Find("Cannon").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > checkInterval)
        {
            if (ec.GetRaycastToPlayer().transform.CompareTag("Player"))
            {
                toPlayerNotWall = true;
            }
            else
            {
                toPlayerNotWall = false;
            }
        }

        if (toPlayerNotWall)
        {
            cannon.transform.LookAt(target.transform);
        }
        else
        {
            ec.TurnCannonAdd(1f);
        }

        if(countTime > checkInterval)
        {
            try
            {
                if (toPlayerNotWall)
                {
                    esm.Shot();
                }
                else if (ec.GetRaycastCannon(bulletBounceNum).transform.root.CompareTag("Player"))
                {
                    esm.Shot();
                }
            }catch(Exception e)
            {
                Debug.Log(e);
            }
            countTime = 0f;
        }

    }
}
