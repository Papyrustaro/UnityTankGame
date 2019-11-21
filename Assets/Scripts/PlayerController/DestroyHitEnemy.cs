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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TankStatus ts = collision.gameObject.GetComponent<TankStatus>();
            if (ts.GetIsAlive())
            {
                ts.SetIsAlive(false);
                //singlemission
                if (MainGameController.gameNumber == 1)
                {
                    smm.EnemyDestroy(collision.gameObject.name);
                }
                EnemyStatus es = collision.gameObject.GetComponent<EnemyStatus>();
                sm.AddScore(es);
                SEManager.PlayDestroyTankSound();
                EffectManager.ShowBombEffect(collision.gameObject.transform.position);
                Destroy(collision.gameObject);
            }
        }
    }
}
