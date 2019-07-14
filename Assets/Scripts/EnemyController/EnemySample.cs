using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySample : MonoBehaviour, TriggerFuncInterface
{
    /*----------------------------*/
    private PutObject po;
    private EnemyController ec;
    private EnemyShotManager esm;
    /*----------------------------*/

    private int a = 0;
    private float countTime = 0f;
    private float Interval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        /*----------------------------*/
        po = transform.Find("Cannon").gameObject.GetComponent<PutObject>();
        ec = GetComponent<EnemyController>();
        ec.SetTriggerFunc(BodyEnter, BodyExit, BodyStay, NearEnter, NearExit, NearStay);
        esm = GetComponent<EnemyShotManager>();
        /*----------------------------*/
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (a == 0) ec.MoveRight();
        if (a == 1) ec.MoveUp();
        if (a == 2) ec.MoveLeft();
        if (a == 3) ec.MoveDown();
        if (countTime >= Interval)
        {
            po.PutLaserPrefab();
            po.PutProtectDomePrefab();
            countTime = 0f;
        }
    }
    public void BodyEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("DestroyableWall"))
        {
            Debug.Log("AAA");
            a = (a + 1) % 4;
            ec.TurnCannonAdd(-90);
        }
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
