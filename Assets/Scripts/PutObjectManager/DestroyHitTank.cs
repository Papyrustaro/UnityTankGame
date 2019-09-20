using System.Collections;
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

        if (other.transform.root.gameObject.CompareTag("Enemy"))
        {
            //singlemission
            if (MainGameController.gameNumber == 1)
            {
                smm.EnemyDestroy(other.transform.root.gameObject.name);
            }

            es = GameObject.Find(other.transform.root.gameObject.name).GetComponent<EnemyStatus>();
            sm.AddScore(es);
            Destroy(other.transform.root.gameObject);
        }
        if (other.transform.root.gameObject.CompareTag("Player"))
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

            other.transform.root.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
