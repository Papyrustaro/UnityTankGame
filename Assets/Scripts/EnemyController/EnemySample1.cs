using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample1 : MonoBehaviour , TriggerFuncInterface
{
    /*----------------------------*/
    private PutObject po;
    private EnemyController ec;
    private EnemyShotManager esm;
    /*----------------------------*/

    private float countTime = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        /*----------------------------*/
        po = transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        ec = GetComponent<EnemyController>();
        ec.SetTriggerFunc(BodyEnter, BodyExit, BodyStay, NearEnter, NearExit, NearStay);
        esm = GetComponent<EnemyShotManager>();
        /*----------------------------*/
    }
    void Start()
    {
        ec.TurnCannonAdd(45);
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime >= 2f)
        {
            //Debug.Log(ec.GetRaycastCannon(2).collider.gameObject);
            if (ec.GetRaycastHit().transform.CompareTag("Player"))
            {
                esm.Shot();
            }
            
            countTime = 0f;
        }
    }


    public void BodyEnter(Collider other)
    {
    }

    public void BodyExit(Collider other)
    {
    }
    public void BodyStay(Collider other)
    {
    }
    public void NearEnter(Collider other)
    {
    }
    public void NearExit(Collider other)
    {
    }
    public void NearStay(Collider other)
    {
    }
}
