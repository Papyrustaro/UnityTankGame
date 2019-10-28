﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyHitTank : MonoBehaviour
{
    private EnemyStatus es;
    private ScoreManager sm;
    private SingleMissionManager smm;
    private SingleSurvivalManager ssm;

    private void Awake()
    {
        if(MainGameController.gameNumber == 1)
        {
            smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
        }else if(MainGameController.gameNumber == 2)
        {
            ssm = GameObject.Find("SingleSurvivalManager").GetComponent<SingleSurvivalManager>();
        }
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            TankStatus ts = other.gameObject.GetComponent<TankStatus>();
            if (ts.GetIsAlive())
            {
                //singlemission
                if (MainGameController.gameNumber == 1)
                {
                    smm.EnemyDestroy(other.gameObject.name);
                }
                ts.SetIsAlive(false);
                es = GameObject.Find(other.gameObject.name).GetComponent<EnemyStatus>();
                sm.AddScore(es);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            TankStatus ts = other.gameObject.GetComponent<TankStatus>();
            if (ts.GetIsAlive())
            {
                //singlemission
                if (MainGameController.gameNumber == 1)
                {
                    smm.PlayerDestroy();
                }
                else if (MainGameController.gameNumber == 2)
                {
                    ssm.PlayerDestroy();
                }
                ts.SetIsAlive(false);
                other.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
