using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyHitEnemy : MonoBehaviour
{
    private SingleMissionManager smm;
    private SingleSurvivalManager ssm;
    private ScoreManager sm;

    private void Awake()
    {
        //戦車選択画面
        try
        {
            if (MainGameController.gameNumber == 1)
            {
                smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
            }
            else if (MainGameController.gameNumber == 2)
            {
                ssm = GameObject.Find("SingleSurvivalManager").GetComponent<SingleSurvivalManager>();
            }
            sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }
        catch (NullReferenceException)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Enemy") && other.CompareTag("Body"))
        {
            //singlemission
            if (MainGameController.gameNumber == 1)
            {
                smm.EnemyDestroy(other.transform.root.gameObject.name);
            }

            EnemyStatus es = other.transform.root.gameObject.GetComponent<EnemyStatus>();
            sm.AddScore(es);
            Destroy(other.transform.root.gameObject);
        }
    }
}
