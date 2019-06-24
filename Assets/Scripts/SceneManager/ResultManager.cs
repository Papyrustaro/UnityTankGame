using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private int resultScore;
    private Text scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        resultScore = ScoreManager.GetScore();
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "Score: " + resultScore;
    }
}
