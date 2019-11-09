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
        //シングルミッション
        if (MainGameController.gameNumber == 1)
        {
            smm = GameObject.Find("SingleMissionManager").GetComponent<SingleMissionManager>();
        }
    }

    private void Start()
    {
        //Time.timeScale = 0f;
    }

    public void OnPressSeceret()
    {
        Debug.Log("AAA");
    }
    public void DestroyEnemy(GameObject enemy)
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
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
        Debug.Log("全データを消去しました。");
    }

    public void DeleteTemporaryData()
    {
        InitAllData.InitData();
    }
}
