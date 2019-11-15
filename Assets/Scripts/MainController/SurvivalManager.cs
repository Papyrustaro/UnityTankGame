using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SurvivalManager : MonoBehaviour
{
    public GameObject resultUIPanel;
    public GameObject rankingPanel;
    public GameObject inputPlayerNamePanel;
    public GameObject scoreLabel;
    public GameObject inputPlayerName;

    private bool isRankin;
    private int playerScore;

    private void Awake()
    {
        Debug.Log("colled survivalmanager.cs");
    }

    public void PlayerDestroy()
    {
        Time.timeScale = 0f;
        UpdateScoreByTankEffect();
        StartCoroutine(DelayMethod(1f, () =>
        {
            DisplayResult();
        }));
    }

    public void DisplayResult()
    {
        resultUIPanel.SetActive(true);
        scoreLabel.SetActive(false);

        GameObject titleText = resultUIPanel.transform.Find("Title").gameObject;
        GameObject scoreAnnounceText = resultUIPanel.transform.Find("ScoreAnnounceText").gameObject;
        GameObject scoreText = resultUIPanel.transform.Find("ScoreText").gameObject;

        playerScore = SingleSurvivalStaticData.playerScore;
        scoreText.GetComponent<Text>().text = playerScore.ToString();

        StartCoroutine(DelayMethod(1f, () =>
        {
            titleText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(2f, () =>
        {
            scoreAnnounceText.SetActive(true);
        }));
        StartCoroutine(DelayMethod(3f, () =>
        {
            scoreText.SetActive(true);
        }));

        StartCoroutine(DelayMethod(11f, () =>
        {

            if (PlayerPrefs.GetInt("SingleSurvivalThirdScore") < playerScore || !PlayerPrefs.HasKey("SingleSurvivalThirdScore")) //rankinしたら
            {
                inputPlayerNamePanel.SetActive(true);
            }
            else
            {
                StartCoroutine(DelayMethod(1f, () =>
                {
                    SaveHighScore("あなた");
                    DisplayRanking();
                }));
            }
        }));
    }

    public void InputPlayerName()
    {
        SaveHighScore(inputPlayerName.GetComponent<InputField>().text);
        inputPlayerName.SetActive(false);
        StartCoroutine(DelayMethod(1f, () =>
        {
            DisplayRanking();
        }));
    }

    public void SaveHighScore(string name)
    {
        int bestScore = PlayerPrefs.GetInt("SingleSurvivalBestScore");
        int secondScore = PlayerPrefs.GetInt("SingleSurvivalSecondScore");
        int thirdScore = PlayerPrefs.GetInt("SingleSurvivalThirdScore");
        string bestScoreName = PlayerPrefs.GetString("SingleSurvivalBestScoreName");
        string secondScoreName = PlayerPrefs.GetString("SingleSurvivalSecondScoreName");
        string thirdScoreName = PlayerPrefs.GetString("SingleSurvivalThirdScoreName");

        this.isRankin = true;

        if (bestScore < playerScore || !PlayerPrefs.HasKey("SingleSurvivalBestScore"))
        {
            thirdScore = secondScore; thirdScoreName = secondScoreName;
            secondScore = bestScore; secondScoreName = bestScoreName;
            bestScore = playerScore; bestScoreName = name;
        }
        else if (secondScore < playerScore || !PlayerPrefs.HasKey("SingleSurvivalSecondScore"))
        {
            thirdScore = secondScore; thirdScoreName = secondScoreName;
            secondScore = playerScore; secondScoreName = name;
        }
        else if (thirdScore < playerScore || !PlayerPrefs.HasKey("SingleSurvivalThirdScore"))
        {
            thirdScore = playerScore; thirdScoreName = name;
        }
        else
        {
            this.isRankin = false;
        }

        PlayerPrefs.SetInt("SingleSurvivalBestScore", bestScore); PlayerPrefs.SetString("SingleSurvivalBestScoreName", bestScoreName);
        PlayerPrefs.SetInt("SingleSurvivalSecondScore", secondScore); PlayerPrefs.SetString("SingleSurvivalSecondScoreName", secondScoreName);
        PlayerPrefs.SetInt("SingleSurvivalThirdScore", thirdScore); PlayerPrefs.SetString("SingleSurvivalThirdScoreName", thirdScoreName);

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

        bestScoreText.GetComponent<Text>().text = "第1位:  " + PlayerPrefs.GetString("SingleSurvivalBestScoreName") + "  (" + PlayerPrefs.GetInt("SingleSurvivalBestScore").ToString() + ")";
        secondScoreText.GetComponent<Text>().text = "第2位:  " + PlayerPrefs.GetString("SingleSurvivalSecondScoreName") + "  (" + PlayerPrefs.GetInt("SingleSurvivalSecondScore").ToString() + ")";
        thirdScoreText.GetComponent<Text>().text = "第3位:  " + PlayerPrefs.GetString("SingleSurvivalThirdScoreName") + "  (" + PlayerPrefs.GetInt("SingleSurvivalThirdScore").ToString() + ")";
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
        }));
    }

    public void OnGoTitleButtonClicked()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnGoPlayerSelectTankButtonClicked()
    {
        SceneManager.LoadScene("PlayerSelectTank");
    }

    public void UpdateScoreByTankEffect()
    {
        Debug.Log(SingleSurvivalStaticData.selectTankNumber);
        Debug.Log(MainGameController.GetPlayerSelectTankNumber());
        int tankNumber = SingleSurvivalStaticData.selectTankNumber;
        if(tankNumber == 1)
        {
            this.playerScore += 200;
        }else if(tankNumber == 26)
        {
            this.playerScore += 1000;
        }else if(tankNumber >= 21)
        {
            this.playerScore -= 2000;
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
