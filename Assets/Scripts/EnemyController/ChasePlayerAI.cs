using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerAI : MonoBehaviour
{
    private GameObject player;
    private EnemyController ec;
    private EnemyMoveAI emai;
    private bool IsChasePlayer = false;

    private float countTime = 0f;

    private void Awake()
    {
        ec = GetComponent<EnemyController>();
        emai = transform.Find("CheckWall").gameObject.GetComponent<EnemyMoveAI>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > 1f && emai.GetIsNormalMove())
        {
            if (ec.GetRaycastToPlayer().transform.root.gameObject.CompareTag("Player"))
            {
                emai.SetIsNormalMove(false);
                this.IsChasePlayer = true;
            }
            else
            {
                emai.SetIsNormalMove(true);
                this.IsChasePlayer = false;
            }
        }

        if (IsChasePlayer)
        {
            ec.Move(player.transform.position - this.transform.position);
        }
    }

}
