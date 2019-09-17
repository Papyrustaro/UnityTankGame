using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int scoreValue;
    private ScoreManager sm;

    private void Start()
    {
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public int GetScoreValue()
    {
        return this.scoreValue;
    }


}
