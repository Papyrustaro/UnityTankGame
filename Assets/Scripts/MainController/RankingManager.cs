using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankingManager : MonoBehaviour
{
    public GameObject rankingPanel;
    private GameObject titleText;
    private GameObject bestScoreText;
    private GameObject secondScoreText;
    private GameObject thirdScoreText;
    private GameObject inputAnnounceText;
    private GameObject goToMenuButton;
    private GameObject goToPlayerSelectTankButton;
    private GameObject inputPlayerNameField;

    private void Awake()
    {
        titleText = rankingPanel.transform.Find("TitleText").gameObject;
        bestScoreText = rankingPanel.transform.Find("BestScoreText").gameObject;
        secondScoreText = rankingPanel.transform.Find("SecondScoreText").gameObject;
        thirdScoreText = rankingPanel.transform.Find("ThirdScoreText").gameObject;
        inputAnnounceText = rankingPanel.transform.Find("InputAnnounceText").gameObject;
        goToMenuButton = rankingPanel.transform.Find("GoToMenuButton").gameObject;
        goToPlayerSelectTankButton = rankingPanel.transform.Find("GoToPlayerSelectTankButton").gameObject;

        
    }
    private void Start()
    {

        StartCoroutine(DelayMethod(1f, () =>
        {
            
        }));
    }

    private void SetRanking()
    {

    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        action();
    }
}
