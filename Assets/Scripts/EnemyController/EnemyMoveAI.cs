using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMoveAI : MonoBehaviour
{
    private EnemyController ec;
    // Start is called before the first frame update
    private int a = 0;
    private bool exitWall = true;
    private GameObject hitWall;
    private Vector3 returnV;
    private float countTime = 0f;
    private bool isNormalMove = true;

    private void Awake()
    {
        ec = transform.root.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (isNormalMove)
        {
            if (exitWall)
            {
                if (countTime > 1f)
                {
                    a = UnityEngine.Random.Range(0, 4);
                    countTime = 0f;
                }
                if (a == 0) ec.MoveUp();
                else if (a == 1) ec.MoveRight();
                else if (a == 2) ec.MoveDown();
                else ec.MoveLeft();
            }
            else
            {
                ec.Move(returnV);
                /*if (a == 0) ec.MoveDown();
                else if (a == 1) ec.MoveLeft();
                else if (a == 2) ec.MoveUp();
                else ec.MoveRight();*/
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //自分との衝突防ぐ←毎回調べるのは非効率
        if (other.transform.root.gameObject == transform.root.gameObject)
        {
            return;
        }
        if (other.CompareTag("Wall") || other.CompareTag("DestroyableWall") || other.CompareTag("Body"))
        {
            returnV = this.transform.position - other.ClosestPointOnBounds(this.transform.position);
            exitWall = false;
            hitWall = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!exitWall)
        {
            if(other.gameObject == hitWall)
            {
                exitWall = true;
                int t;
                do
                {
                    t = UnityEngine.Random.Range(0, 4);
                } while (t == a);
                a = t;
            }
        }
    }

    public void SetIsNormalMove(bool flag)
    {
        this.isNormalMove = flag;
    }

    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for (int i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
}
