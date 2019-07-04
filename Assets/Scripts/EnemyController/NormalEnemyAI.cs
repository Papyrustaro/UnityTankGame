using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAI : MonoBehaviour
{
    private EnemyShotManager esm;
    private RaycastHit hit;
    private LookAtMouseCursor lamc;
    public float shotInterval = 1f;
    private float countTime = 0f;
    private GameObject head;
    private GameObject turret;
    void Start()
    {
        esm = GetComponent<EnemyShotManager>();
        lamc = GameObject.FindWithTag("Player").transform.Find("Cannon").GetComponent<LookAtMouseCursor>();
        head = this.transform.Find("Cannon/Head").gameObject;
        turret = this.transform.Find("Cannon/Turret").gameObject;

    }
    private void Update()
    {
        countTime += Time.deltaTime;
        if(shotInterval <= countTime)
        {
            if (Physics.Raycast(this.transform.position, turret.transform.position - head.transform.position, out hit, 50f))
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
