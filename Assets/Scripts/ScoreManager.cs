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
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "Score: " + score;
    }

    public void AddScore(EnemyStatus es)
    {
        score += es.scoreValue;
        scoreLabel.text = "Score: " + score;
    }
}
