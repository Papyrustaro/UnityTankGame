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
    public GameObject resultUIPanel;
    public GameObject scoreLabel;
    private Text missionNumberText;
    private Text enemyCounterText;
    private Text playerLifeText;

    public int allMissionNum = 3;


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

    private void Update()
    {
        SingleMissionStaticData.countTime += Time.deltaTime;
    }

    public void DisplayMissionTitle()
    {
        missionNumberText.text = "ミッション " + (SingleMissionStaticData.missionNumber + 1);
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
            try{
                if (enemyPrefabSetStage[i].name == enemyName)
                {
                    SingleMissionStaticData.enemyIsDeath[i] = true;
                    break;
                }
            }catch (MissingReferenceException)
            {
            }
        }
    }

    //ミッションクリアしたときの処理
    public void SetBeforeNewStage()
    {
        Time.timeScale = 0f;
        SingleMissionStaticData.missionNumber++;
        SingleMissionStaticData.loadNewStage = true;
        if(allMissionNum > SingleMissionStaticData.missionNumber)
        {
            StartCoroutine(DelayMethod(1f, () =>
            {
                DisplayMissionClearFlag();
            }));
            StartCoroutine(DelayMethod(3f, () =>
            {
                SceneManager.LoadScene("SingleMission" + SingleMissionStaticData.missionNumber);
            }));
        }
        else
        {
            StartCoroutine(DelayMethod(1f, () =>
            {
                DisplayResult();
            }));
        }
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
        if(SingleMissionStaticData.playerLife > 0)
        {
            StartCoroutine(DelayMethod(1f, () =>
            {
                DisplayMissionFailFlag();
            }));
            StartCoroutine(DelayMethod(3f, () =>
            {
                SceneManager.LoadScene("SingleMission" + SingleMissionStaticData.missionNumber);
            }));
        }
        else
        {
            StartCoroutine(DelayMethod(1f, () =>
            {
                DisplayResult();
            }));
        }
    }

    public void DisplayResult()
    {
        resultUIPanel.SetActive(true);
        scoreLabel.SetActive(false);

        GameObject titleText = resultUIPanel.transform.Find("TitleText").gameObject;
        GameObject destroyScoreText = resultUIPanel.transform.Find("DestroyScoreText").gameObject;
        GameObject lifeScoreText = resultUIPanel.transform.Find("LifeScoreText").gameObject;
        GameObject timeScoreText = resultUIPanel.transform.Find("TimeScoreText").gameObject;
        GameObject sumScoreText = resultUIPanel.transform.Find("SumScoreText").gameObject;
        GameObject sumScoreValueText = resultUIPanel.transform.Find("SumScoreValueText").gameObject;
        GameObject lineText = resultUIPanel.transform.Find("Line").gameObject;

        int timeScore = 600 - (int)SingleMissionStaticData.countTime;
        int minute = (int)(SingleMissionStaticData.countTime / 60);
        int second = (int)SingleMissionStaticData.countTime - minute;

        destroyScoreText.GetComponent<Text>().text = "撃墜点: " + SingleMissionStaticData.playerScore.ToString();
        lifeScoreText.GetComponent<Text>().text = "残機数: " + SingleMissionStaticData.playerLife * 100 + " (" + SingleMissionStaticData.playerLife + ")";
        timeScoreText.GetComponent<Text>().text = "かかった時間: " + timeScore + " (" + minute + "分" + second + "秒)";

        sumScoreValueText.GetComponent<Text>().text = (SingleMissionStaticData.playerScore + (SingleMissionStaticData.playerLife * 100) + timeScore).ToString();

        StartCoroutine(DelayMethod(2f, () =>
        {
            titleText.SetActive(false);
        }));
        StartCoroutine(DelayMethod(3f, () =>
        {
            destroyScoreText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(4f, () =>
        {
            lifeScoreText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(5f, () =>
        {
            timeScoreText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(6f, () =>
        {
            lineText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(7f, () =>
        {
            sumScoreText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(8f, () =>
        {
            sumScoreValueText.SetActive(true);
        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }

}
