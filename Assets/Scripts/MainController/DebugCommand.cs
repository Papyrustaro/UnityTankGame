using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommand : MonoBehaviour
{
    private EnemyStatus es;
    private ScoreManager sm;
    private SingleMissionManager smm;

    private void Awake()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //シングルミッション
        if (MainGameController.gameNumber == 1)
        {
            smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        //singlemission
        if (MainGameController.gameNumber == 1)
        {
            smm.EnemyDestroy(enemy.name);
        }

        sm.AddScore(enemy.GetComponent<EnemyStatus>().GetScoreValue());
        Destroy(enemy);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }
}
