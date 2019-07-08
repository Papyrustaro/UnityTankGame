using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SingleMissionManager : MonoBehaviour
{
    public GameObject[] enemyPrefabSetStage;
    public int enemyNumSetStage;

    public GameObject missionTitlePanel;
    public GameObject missionClearFlagPanel;
    public GameObject missionFailFlagPanel;
    private Text missionNumberText;
    private Text enemyCounterText;
    private Text playerLifeText;


    private void Awake()
    {
        Time.timeScale = 0f;
        missionNumberText = missionTitlePanel.transform.Find("MissionNumberText").gameObject.GetComponent<Text>();
        enemyCounterText = missionTitlePanel.transform.Find("EnemyCounterText").gameObject.GetComponent<Text>();
        playerLifeText = missionTitlePanel.transform.Find("PlayerLifeText").gameObject.GetComponent<Text>();
        if (SingleMissionStaticData.loadNewStage)
        {
            SetAfterNewStage();
        }
        DisplayMissionTitle();
    }

    private void Start()
    {
        for(int i = 0; i < enemyNumSetStage; i++)
        {
            if (SingleMissionStaticData.enemyIsDeath[i])
            {
                Destroy(enemyPrefabSetStage[i]);
            }
        }
        StartCoroutine(DelayMethod(5f, () =>
        {
            Time.timeScale = 1f;
        }));
    }

    public void DisplayMissionTitle()
    {
        missionNumberText.text = "ミッション " + SingleMissionStaticData.missionNumber;
        enemyCounterText.text = "敵戦車 あと" + SingleMissionStaticData.remainEnemyNum + "体";
        playerLifeText.text = "残機 " + SingleMissionStaticData.playerLife;
        missionTitlePanel.transform.parent.gameObject.SetActive(true);
        StartCoroutine(DelayMethod(3f, () =>
        {
            missionTitlePanel.transform.parent.gameObject.SetActive(false);
        }));
    }
    public void DisplayMissionClearFlag()
    {
        missionClearFlagPanel.SetActive(true);
    }
    public void DisplayMissionFailFlag()
    {
        missionFailFlagPanel.SetActive(true);
    }

    public void EnemyDestroy(string enemyName)
    {
        SingleMissionStaticData.remainEnemyNum--;
        if (SingleMissionStaticData.remainEnemyNum <= 0)
        {
            SetBeforeNewStage();
        }
        for (int i = 0; i < enemyNumSetStage; i++)
        {
            if(enemyPrefabSetStage[i].name == enemyName)
            {
                SingleMissionStaticData.enemyIsDeath[i] = true;
                break;
            }
        }
    }

    //ミッションクリアしたときの処理
    public void SetBeforeNewStage()
    {
        Time.timeScale = 0f;
        SingleMissionStaticData.missionNumber++;
        SingleMissionStaticData.loadNewStage = true;
        StartCoroutine(DelayMethod(1f, () =>
        {
            DisplayMissionClearFlag();
        }));
        StartCoroutine(DelayMethod(3f, () =>
        {
            SceneManager.LoadScene("SingleMission" + SingleMissionStaticData.missionNumber);
        }));
    }

    //次のミッションに移動したときの処理
    public void SetAfterNewStage()
    {
        SingleMissionStaticData.enemyIsDeath = new bool[enemyNumSetStage];
        SingleMissionStaticData.remainEnemyNum = enemyNumSetStage;
        SingleMissionStaticData.loadNewStage = false;
    }
    public void PlayerDestroy()
    {
        Time.timeScale = 0f;
        SingleMissionStaticData.playerLife--;
        StartCoroutine(DelayMethod(1f, () =>
        {
            DisplayMissionFailFlag();
        }));
        StartCoroutine(DelayMethod(3f, () =>
        {
            SceneManager.LoadScene("SingleMission" + SingleMissionStaticData.missionNumber);
        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }

}
