using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemyRandom : MonoBehaviour
{
    public int enemyPrefabKindNum;
    public GameObject[] enemyPrefab;
    private GameObject playerPrefab;
    public float generateTime = 10f;
    private bool isHighScore = false; //500点以上で強い敵も出現
    private float countTime = 0f;

    private int[] generatePosition = { -20, 0, 20 };
    private void Start()
    {
        playerPrefab = GameObject.FindWithTag("Player");
        countTime = 0f;
        StartCoroutine(DelayMethod(2f, () =>
        {
            GenerateEnemy();
        }));
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        if(countTime >= generateTime)
        {
            CheckHighScore();
            GenerateEnemy();
            SetGenerateTime();

            countTime = 0f;
        }
    }
    public void GenerateEnemy()
    {
        while (true)
        {
            int x = generatePosition[UnityEngine.Random.Range(0, 3)];
            int z = generatePosition[UnityEngine.Random.Range(0, 3)];
            if (checkGeneratePosition(x, z)){
                //500点以上の場合は全ての敵からランダム
                if (this.isHighScore)
                {
                    Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefabKindNum)], new Vector3(x, 0f, z), Quaternion.identity);
                    break;
                }
                //500点未満の場合はスキルがない敵(0～6)
                else
                {
                    Instantiate(enemyPrefab[UnityEngine.Random.Range(0, 7)], new Vector3(x, 0f, z), Quaternion.identity);
                    break;
                }
            }
        }
    }

    //1000点から500点獲得するごとにgenerateTimeを1秒短くする。(最小5秒)
    public void SetGenerateTime()
    {
        int minusTime = ((SingleSurvivalStaticData.playerScore - 1000) / 500);
        if(minusTime <= 0)
        {
            return;
        }else if(minusTime > 5)
        {
            this.generateTime = 5f;
        }
        else
        {
            this.generateTime = 10f - (float)minusTime;
        }
    }

    public void CheckHighScore()
    {
        if(!this.isHighScore && SingleSurvivalStaticData.playerScore >= 500)
        {
            this.isHighScore = true;
        }
    }

    public bool checkGeneratePosition(int x, int z)
    {
        if(Mathf.Abs(playerPrefab.transform.position.x - x) < 5 || Mathf.Abs(playerPrefab.transform.position.z - z) < 5){
            return false;
        }else
        {
            return true;
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
