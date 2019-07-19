using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidAttack : MonoBehaviour
{
    private EnemyController ec;
    private EnemyMoveAI emAI;
    private GameObject attackObject;
    private bool isAvoidMove = false;
    private Vector3 avoidVector;
    private RaycastHit hit;

    private void Awake()
    {
        ec = transform.root.gameObject.GetComponent<EnemyController>();
        emAI = transform.parent.Find("CheckWall").GetComponent<EnemyMoveAI>();
    }

    public void Update()
    {
        if (isAvoidMove)
        {
            ec.Move(avoidVector);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet") || other.CompareTag("EnemyBullet") || other.CompareTag("SpecialBullet"))
        {
            Vector3 v = other.transform.Find("BulletHead").transform.position - other.transform.Find("BulletBody").transform.position;
            Vector3 v2 = Quaternion.Euler(0, 90f, 0) * v;
            Vector3 from = other.transform.position + v2 * 0.4f;
            Physics.Raycast(from, v, out hit, 100f);
            if(hit.transform.gameObject == transform.root.gameObject)
            {
                isAvoidMove = true;
                attackObject = other.gameObject;
                emAI.SetIsNormalMove(false);
                avoidVector = this.transform.position - other.transform.position;
                avoidVector = Quaternion.Euler(0, 90f, 0) * avoidVector;
                return;
            }

            from -= v2 * 2;
            Physics.Raycast(from, v, out hit, 100f);
            if (hit.transform.gameObject == transform.root.gameObject)
            {
                isAvoidMove = true;
                attackObject = other.gameObject;
                emAI.SetIsNormalMove(false);
                avoidVector = this.transform.position - other.transform.position;
                avoidVector = Quaternion.Euler(0, -90f, 0) * avoidVector;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == attackObject)
        {
            emAI.SetIsNormalMove(true);
            isAvoidMove = false;
        }
    }
}
