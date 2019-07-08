using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemyRandom : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public int minX, maxX, minZ, maxZ;
    public int notMinX, notMaxX, notMinZ, notMaxZ;
    public GameObject playerPrefab;
    public float generateTime;
    private float countTime = 0f;

    private void Start()
    {
        countTime = 0f;
        StartCoroutine(DelayMethod(2f, () =>
        {
            GenerateEnemy();
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
        int enemyNum = UnityEngine.Random.Range(0, 8);
        while (true)
        {
            int x = UnityEngine.Random.Range(minX, maxX);
            int z = UnityEngine.Random.Range(minZ, maxZ);
            if(checkGeneratePosition(x, z)){
                Instantiate(enemyPrefab[enemyNum], new Vector3(x, 0f, z), Quaternion.identity);
                break;
            }
        }
    }

    public bool checkGeneratePosition(int x, int z)
    {
        if(((x > notMinX && x < notMaxX) && (z > notMinZ && z < notMaxZ)) ||
            Mathf.Abs(playerPrefab.transform.position.x - x) < 5 || Mathf.Abs(playerPrefab.transform.position.z - z) < 5){
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
