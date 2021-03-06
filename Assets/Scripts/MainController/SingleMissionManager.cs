﻿using System.Collections;
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
    public GameObject rankingPanel;
    public GameObject inputPlayerName;
    public GameObject bulletNumCanvas;
    private Text missionNumberText;
    private Text enemyCounterText;
    private Text playerLifeText;
    public GameObject releaseAnnounceText;

    private InputManager im;
    public int allMissionNum = 20;
    private DebugCommand dc;
    private int playerScore;
    private bool isRankin;
    private bool releaseTankFlag;


    private void Awake()
    {
        SingleMissionStaticData.pauseAble = false;
        Time.timeScale = 0f;
        missionNumberText = missionTitlePanel.transform.Find("MissionNumberText").gameObject.GetComponent<Text>();
        enemyCounterText = missionTitlePanel.transform.Find("EnemyCounterText").gameObject.GetComponent<Text>();
        playerLifeText = missionTitlePanel.transform.Find("PlayerLifeText").gameObject.GetComponent<Text>();
        im = GetComponent<InputManager>();
        dc = GetComponent<DebugCommand>();
        if (SingleMissionStaticData.loadNewStage)
        {
            SetAfterNewStage();
        }
        DisplayMissionTitle();
    }

    private void Start()
    {
        //Debug.Log(this.enemyNumSetStage);
        //Debug.Log(SingleMissionStaticData.enemyNumSetStage);
        //Debug.Log(SingleMissionStaticData.enemyIsDeath.Length);
        //IOManager.WriteFile("enemyIsDeath.Length: " + SingleMissionStaticData.enemyIsDeath.Length.ToString());
        for(int i = 0; i < enemyNumSetStage; i++)
        {
            if (SingleMissionStaticData.enemyIsDeath[i])
            {
                Destroy(enemyPrefabSetStage[i]);
            }
        }
        StartCoroutine(DelayMethod(6f, () =>
        {
            Time.timeScale = 1f;
            SingleMissionStaticData.pauseAble = true;
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
        StartCoroutine(DelayMethod(2f, () =>
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
        //IOManager.WriteFile("ssm.enemyNumSetStage: " + enemyNumSetStage.ToString());
        //IOManager.WriteFile("smsd.remainEnemyNum: " + SingleMissionStaticData.remainEnemyNum.ToString());
        //IOManager.WriteFile("enemyName: " + enemyName);
        for (int i = 0; i < enemyNumSetStage; i++)
        {
            //IOManager.WriteFile("ssm内にて、");
            try{
                if (enemyPrefabSetStage[i].name == enemyName)
                {
                    SingleMissionStaticData.enemyIsDeath[i] = true;
                    SingleMissionStaticData.remainEnemyNum--;
                    if (SingleMissionStaticData.remainEnemyNum <= 0)
                    {
                        SetBeforeNewStage();
                    }
                    break;
                }
            }catch (Exception)
            {
                //IOManager.WriteFile(e.ToString());
            }
        }
    }

    //ミッションクリアしたときの処理
    public void SetBeforeNewStage()
    {
        SingleMissionStaticData.pauseAble = false;
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
        //Debug.Log("aa");
        SingleMissionStaticData.enemyNumSetStage = this.enemyNumSetStage;
        SingleMissionStaticData.enemyIsDeath = new bool[enemyNumSetStage];
        SingleMissionStaticData.remainEnemyNum = enemyNumSetStage;
        SingleMissionStaticData.loadNewStage = false;
    }
    public void PlayerDestroy()
    {
        SingleMissionStaticData.pauseAble = false;
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
            SingleMissionStaticData.playerLife = 0;
            StartCoroutine(DelayMethod(1f, () =>
            {
                DisplayResult();
            }));
        }
    }

    public void DisplayResult()
    {
        CountPlayNum();
        BGMManager.SetVolume(0.5f);
        resultUIPanel.SetActive(true);
        scoreLabel.SetActive(false);
        bulletNumCanvas.SetActive(false);

        bool isClear = (SingleMissionStaticData.playerLife > 0);

        GameObject titleText = resultUIPanel.transform.Find("TitleText").gameObject;
        GameObject destroyScoreText = resultUIPanel.transform.Find("DestroyScoreText").gameObject;
        GameObject lifeScoreText = resultUIPanel.transform.Find("LifeScoreText").gameObject;
        GameObject timeScoreText = resultUIPanel.transform.Find("TimeScoreText").gameObject;
        GameObject sumScoreText = resultUIPanel.transform.Find("SumScoreText").gameObject;
        GameObject sumScoreValueText = resultUIPanel.transform.Find("SumScoreValueText").gameObject;
        GameObject lineText = resultUIPanel.transform.Find("Line").gameObject;

        int timeScore = (600 - (int)SingleMissionStaticData.countTime) * 10;
        if (timeScore < 0) timeScore = 0;
        if (!isClear)
        {
            timeScore = 0;
        }
        int minute = (int)(SingleMissionStaticData.countTime / 60);
        int second = (int)SingleMissionStaticData.countTime - (minute * 60);

        destroyScoreText.GetComponent<Text>().text = "撃墜点: " + SingleMissionStaticData.playerScore.ToString();
        lifeScoreText.GetComponent<Text>().text = "残機数: " + SingleMissionStaticData.playerLife * 1000 + " (" + SingleMissionStaticData.playerLife + ")";
        timeScoreText.GetComponent<Text>().text = "かかった時間: " + timeScore + " (" + minute + "分" + second + "秒)";

        playerScore = SingleMissionStaticData.playerScore + (SingleMissionStaticData.playerLife * 100) + timeScore;
        CheckReleaseScore(playerScore);
        sumScoreValueText.GetComponent<Text>().text = playerScore.ToString();


        StartCoroutine(DelayMethod(2f, () =>
        {
            titleText.SetActive(false);
        }));
        StartCoroutine(DelayMethod(3f, () =>
        {
            destroyScoreText.SetActive(true);
            lifeScoreText.SetActive(true);
            timeScoreText.SetActive(true);
            SEManager.PlaySound(SEManager.resultSound0);
        }));
        StartCoroutine(DelayMethod(4f, () =>
        {
            lineText.SetActive(true);
            sumScoreText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(5f, () =>
        {
            sumScoreValueText.SetActive(true);
            SEManager.PlaySound(SEManager.resultSound1);
        }));
        StartCoroutine(DelayMethod(5.1f, () =>
        {
            SEManager.PlaySound(SEManager.resultSound1);
        }));

        StartCoroutine(DelayMethod(8f, () =>
        {
            destroyScoreText.SetActive(false);
            lifeScoreText.SetActive(false);
            timeScoreText.SetActive(false);
            lineText.SetActive(false);
            sumScoreText.SetActive(false);
            sumScoreValueText.SetActive(false);

            if (PlayerPrefs.GetInt("SingleMissionThirdScore") < playerScore || !PlayerPrefs.HasKey("SingleMissionThirdScore")) //rankinしたら
            {
                inputPlayerName.SetActive(true);
            }
            else
            {
                SaveHighScore("あなた");
                DisplayRanking();
            }
        }));
    }

    public void SaveHighScore(string name)
    {
        int bestScore = PlayerPrefs.GetInt("SingleMissionBestScore");
        int secondScore = PlayerPrefs.GetInt("SingleMissionSecondScore");
        int thirdScore = PlayerPrefs.GetInt("SingleMissionThirdScore");
        string bestScoreName = PlayerPrefs.GetString("SingleMissionBestScoreName");
        string secondScoreName = PlayerPrefs.GetString("SingleMissionSecondScoreName");
        string thirdScoreName = PlayerPrefs.GetString("SingleMissionThirdScoreName");

        this.isRankin = true;

        if(bestScore < playerScore || !PlayerPrefs.HasKey("SingleMissionBestScore"))
        {
            thirdScore = secondScore;   thirdScoreName = secondScoreName;
            secondScore = bestScore;    secondScoreName = bestScoreName;
            bestScore = playerScore;  bestScoreName = name;
        }else if(secondScore < playerScore || !PlayerPrefs.HasKey("SingleMissionSecondScore"))
        {
            thirdScore = secondScore; thirdScoreName = secondScoreName;
            secondScore = playerScore; secondScoreName = name;
        }else if(thirdScore < playerScore || !PlayerPrefs.HasKey("SingleMissionThirdScore"))
        {
            thirdScore = playerScore; thirdScoreName = name;
        }
        else
        {
            this.isRankin = false;
        }

        PlayerPrefs.SetInt("SingleMissionBestScore", bestScore); PlayerPrefs.SetString("SingleMissionBestScoreName", bestScoreName);
        PlayerPrefs.SetInt("SingleMissionSecondScore", secondScore); PlayerPrefs.SetString("SingleMissionSecondScoreName", secondScoreName);
        PlayerPrefs.SetInt("SingleMissionThirdScore", thirdScore); PlayerPrefs.SetString("SingleMissionThirdScoreName", thirdScoreName);

    }

    public void DisplayRanking()
    {
        rankingPanel.SetActive(true);

        GameObject bestScoreText = rankingPanel.transform.Find("BestScoreText").gameObject;
        GameObject secondScoreText = rankingPanel.transform.Find("SecondScoreText").gameObject;
        GameObject thirdScoreText = rankingPanel.transform.Find("ThirdScoreText").gameObject;
        GameObject playerScoreText = rankingPanel.transform.Find("PlayerScoreText").gameObject;
        GameObject goTitlebutton = rankingPanel.transform.Find("GoTitleButton").gameObject;
        //GameObject continueButton = rankingPanel.transform.Find("ContinueButton").gameObject;
        //GameObject tweetButton = rankingPanel.transform.Find("TweetButton").gameObject;

        bestScoreText.GetComponent<Text>().text = "第1位:  " + PlayerPrefs.GetString("SingleMissionBestScoreName") + "  (" + PlayerPrefs.GetInt("SingleMissionBestScore").ToString() + ")";
        secondScoreText.GetComponent<Text>().text = "第2位:  " + PlayerPrefs.GetString("SingleMissionSecondScoreName") + "  (" + PlayerPrefs.GetInt("SingleMissionSecondScore").ToString() + ")";
        thirdScoreText.GetComponent<Text>().text = "第3位:  " + PlayerPrefs.GetString("SingleMissionThirdScoreName") + "  (" + PlayerPrefs.GetInt("SingleMissionThirdScore").ToString() + ")";
        if (!this.isRankin)
        {
            playerScoreText.GetComponent<Text>().text = "あなた( " + playerScore.ToString() + " )";
        }

        StartCoroutine(DelayMethod(1f, () =>
        {
            bestScoreText.SetActive(true);
            secondScoreText.SetActive(true);
            thirdScoreText.SetActive(true);
        }));
        if (!this.isRankin)
        {
            StartCoroutine(DelayMethod(2f, () =>
            {
                playerScoreText.SetActive(true);
            }));
        }
        StartCoroutine(DelayMethod(4f, () =>
        {
            goTitlebutton.SetActive(true);
            //continueButton.SetActive(true);
            //tweetButton.SetActive(true);
            goTitlebutton.GetComponent<Button>().Select();
            if (this.releaseTankFlag)
            {
                releaseAnnounceText.SetActive(true);
                SEManager.PlaySound(SEManager.correctSound);
            }
        }));
    }

    //プレイヤーが名前入力をしたとき
    public void InputPlayerName()
    {
        SaveHighScore(inputPlayerName.GetComponent<InputField>().text);
        inputPlayerName.SetActive(false);
        StartCoroutine(DelayMethod(1f, () =>
        {
            DisplayRanking();
        }));
    }

    public void OnGoTitleButtonClicked()
    {
        InitAllData.InitData();
        SceneManager.LoadScene("Title");
    }

    public void OnGoPlayerSelectTankButtonClicked()
    {
        SceneManager.LoadScene("PlayerSelectTank");
    }
    public void CountPlayNum()
    {
        int playMissionCount = PlayerPrefs.GetInt("PlayMissionCount", 0) + 1;
        PlayerPrefs.SetInt("PlayMissionCount", playMissionCount);
        if (playMissionCount == 10)
        {
            PlayerPrefs.SetInt("UseableTank21", 1);
            this.releaseTankFlag = true;
        }
    }
    public void CheckReleaseScore(int score)
    {
        if (score >= 500 && PlayerPrefs.GetInt("UseableTank23", 0) == 0)
        {
            this.releaseTankFlag = true;
            PlayerPrefs.SetInt("UseableTank23", 1);
        }
        if (score >= 1000 && PlayerPrefs.GetInt("UseableTank25", 0) == 0)
        {
            this.releaseTankFlag = true;
            PlayerPrefs.SetInt("UseableTank25", 1);
        }
    }
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }

}
