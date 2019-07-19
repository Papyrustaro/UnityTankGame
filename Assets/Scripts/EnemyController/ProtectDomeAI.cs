using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectDomeAI : MonoBehaviour
{
    private PutObject po;
    private float countTime = 0f;
    public float putInterval = 3f;
    private void Awake()
    {
        po = GetComponent<PutObject>();
    }

    private void Update()
    {
        countTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(countTime < putInterval)
        {
            return;
        }

        //自分が発射した瞬間の弾には反応しない
        if (other.CompareTag("EnemyBullet"))
        {
            GameObject bulletBody = other.transform.gameObject.transform.Find("BulletBody").gameObject;
            GameObject bulletHead = other.transform.gameObject.transform.Find("BulletHead").gameObject;
            if ((bulletBody.transform.position - transform.position).magnitude < (bulletHead.transform.position - transform.position).magnitude)
            {
                return;
            }
        }

        if (other.CompareTag("Bullet") || other.CompareTag("EnemyBullet") || other.CompareTag("SpecialBullet"))
        {
            po.PutProtectDomePrefab();
            countTime = 0f;
        }
    }
}
