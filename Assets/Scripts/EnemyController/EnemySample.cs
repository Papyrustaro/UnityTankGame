using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour
{
    private EnemyMovement em;
    private PutObject po;
    private TriggerNearEnemy tne;
    private TriggerAwayEnemy tae;
    private EnemyController ec;

    private float countTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<EnemyMovement>();
        po = transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        tne = transform.Find("Body").gameObject.GetComponent<TriggerNearEnemy>();
        tae = transform.Find("Cannon").gameObject.GetComponent<TriggerAwayEnemy>();
        tne.SetFunc(NearEnter, NearExit, NearStay);
        tae.SetFunc(AwayEnter, AwayExit, AwayStay);
        ec = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

        countTime += Time.deltaTime;
        if(countTime >= 1f)
        {
            if (ec.RayCastCannon())
            {
                Debug.Log(ec.GetRaycastHit().collider.gameObject.name);
                em.TurnCannonAdd(90);
            }
            countTime = 0f;
        }
    }

    private void NearEnter(Collider other)
    {
    }
    private void NearExit(Collider other)
    {
    }
    private void NearStay(Collider other)
    {
    }
    private void AwayEnter(Collider other)
    {
    }
    private void AwayExit(Collider other)
    {
    }
    private void AwayStay(Collider other)
    {
    }
}
