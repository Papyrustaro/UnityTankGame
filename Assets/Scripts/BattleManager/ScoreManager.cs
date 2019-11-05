using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        score = SingleMissionStaticData.playerScore;
        scoreLabel = GameObject.Find("ScoreLabel/ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "Score: " + score;
    }

    public void AddScore(EnemyStatus es)
    {
        if(MainGameController.gameNumber == 1)
        {
            SingleMissionStaticData.playerScore += es.GetScoreValue();
            scoreLabel.text = "Score: " + SingleMissionStaticData.playerScore;
        }else if(MainGameController.gameNumber == 2)
        {
            SingleSurvivalStaticData.playerScore += es.GetScoreValue();
            scoreLabel.text = "Score: " + SingleSurvivalStaticData.playerScore;
        }
    }
    public void AddScore(int scoreValue)
    {
        if(MainGameController.gameNumber == 1)
        {
            SingleMissionStaticData.playerScore += scoreValue;
            scoreLabel.text = "Score: " + SingleMissionStaticData.playerScore;
        }
        else if(MainGameController.gameNumber == 2)
        {
            SingleSurvivalStaticData.playerScore += scoreValue;
            scoreLabel.text = "Score: " + SingleSurvivalStaticData.playerScore;
        }
    }
    public  static int GetScore()
    {
        return SingleMissionStaticData.playerScore;
    }
}
