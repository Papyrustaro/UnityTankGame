using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemyRandom : MonoBehaviour
{
    public int enemyPrefabKindNum;
    public GameObject[] enemyPrefab;
    //public int minX, maxX, minZ, maxZ;
    //public int notMinX, notMaxX, notMinZ, notMaxZ;
    private GameObject playerPrefab;
    public float generateTime;
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
            GenerateEnemy();
            countTime = 0f;
        }
    }
    public void GenerateEnemy()
    {
        int enemyNum = UnityEngine.Random.Range(0, enemyPrefabKindNum);
        while (true)
        {
            int x = generatePosition[UnityEngine.Random.Range(0, 3)];
            int z = generatePosition[UnityEngine.Random.Range(0, 3)];
            if (checkGeneratePosition(x, z)){
                Instantiate(enemyPrefab[enemyNum], new Vector3(x, 0f, z), Quaternion.identity);
                break;
            }
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
