﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Invoke("GameClear", 0.5f);
        }
    }

    private void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
}
