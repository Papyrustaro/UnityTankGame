﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RankingManager : MonoBehaviour
{
    public GameObject missionBestScoreText;
    public GameObject missionSecondScoreText;
    public GameObject missionThirdScoreText;
    public GameObject survivalBestScoreText;
    public GameObject survivalSecondScoreText;
    public GameObject survivalThirdScoreText;

    
    private void Start()
    {
        missionBestScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleMissionBestScoreName") + "(" + PlayerPrefs.GetInt("SingleMissionBestScore").ToString() + ")";
        missionSecondScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleMissionSecondScoreName") + "(" + PlayerPrefs.GetInt("SingleMissionSecondScore").ToString() + ")";
        missionThirdScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleMissionThirdScoreName") + "(" + PlayerPrefs.GetInt("SingleMissionThirdScore").ToString() + ")";
        survivalBestScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleSurvivalBestScoreName") + "(" + PlayerPrefs.GetInt("SingleSurvivalBestScore").ToString() + ")";
        survivalSecondScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleSurvivalSecondScoreName") + "(" + PlayerPrefs.GetInt("SingleSurvivalSecondScore").ToString() + ")";
        survivalThirdScoreText.GetComponent<Text>().text = PlayerPrefs.GetString("SingleSurvivalThirdScoreName") + "(" + PlayerPrefs.GetInt("SingleSurvivalThirdScore").ToString() + ")";
    }
}
