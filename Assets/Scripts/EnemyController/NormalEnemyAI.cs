using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    private EnemyShotManager esm;
    private RaycastHit hit;
    private LookAtMouseCursor lamc;
    private Radar radar;
    public float shotInterval = 1f;
    private float countTime = 0f;
    void Start()
    {
        esm = GetComponent<EnemyShotManager>();
        lamc = GameObject.FindWithTag("Player").transform.Find("Cannon").GetComponent<LookAtMouseCursor>();
        radar = this.transform.Find("Cannon").GetComponent<Radar>();

    }
    private void Update()
    {
        countTime += Time.deltaTime;
        if(shotInterval <= countTime)
        {
            if (Physics.Raycast(this.transform.position, radar.GetTarget().transform.position - this.transform.position, out hit, 50f))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    esm.Shot();
                    countTime = 0f;
                }
            }
        }
    }

}
