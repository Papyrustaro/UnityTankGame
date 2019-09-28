using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayUserRanking : MonoBehaviour
{
    /*public void DisplayRanking()
    {
        rankingPanel.SetActive(true);

        GameObject bestScoreText = rankingPanel.transform.Find("BestScoreText").gameObject;
        GameObject secondScoreText = rankingPanel.transform.Find("SecondScoreText").gameObject;
        GameObject thirdScoreText = rankingPanel.transform.Find("ThirdScoreText").gameObject;
        GameObject playerScoreText = rankingPanel.transform.Find("PlayerScoreText").gameObject;
        GameObject goTitlebutton = rankingPanel.transform.Find("GoTitleButton").gameObject;

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
            goTitlebutton.GetComponent<Button>().Select();
        }));
    }*/

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
