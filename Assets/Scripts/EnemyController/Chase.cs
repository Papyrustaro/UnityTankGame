using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Chase : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //targetの位置を目的地に設定
        agent.destination = target.transform.position;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
