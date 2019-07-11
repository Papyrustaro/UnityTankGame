using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour
{
    private EnemyMovement em;
    private PutObject po;
    private TriggerNearEnemy tne;
    private TriggerAwayEnemy tae;

    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<EnemyMovement>();
        po = transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        tne = transform.Find("Body").gameObject.GetComponent<TriggerNearEnemy>();
        tae = transform.Find("Cannon").gameObject.GetComponent<TriggerAwayEnemy>();
        tne.SetFunc(NearEnter, NearExit, NearStay);
        tae.SetFunc(AwayEnter, AwayExit, AwayStay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NearEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            po.PutRemoteBombPrefab();
            em.TurnCannonAdd(90);
        }
    }
    private void NearExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            em.TurnCannonAdd(90);
        }
    }
    private void NearStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }
    private void AwayEnter(Collider other)
    {
        Debug.Log("awayEnter");
    }
    private void AwayExit(Collider other)
    {
        Debug.Log("awayExit");
    }
    private void AwayStay(Collider other)
    {
    }
}
