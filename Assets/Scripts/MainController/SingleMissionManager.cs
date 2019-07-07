using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleMissionManager : MonoBehaviour
{
    public int enemyNumSetStage;
    public GameObject[] enemyPrefabSetStage;
    public int playerLife = 3;
    private bool[] enemyIsDeath;
    private int remainEnemyNum;
    public int missionNumber;

    public GameObject missionTitlePanel;
    public GameObject missionClearFlagPanel;
    public GameObject missionFailFlagPanel;
    private Text missionNumberText;
    private Text enemyCounterText;
    private Text playerLifeText;


    private void Awake()
    {
        enemyPrefabSetStage = new GameObject[enemyNumSetStage];
        enemyIsDeath = new bool[enemyNumSetStage];
        missionNumberText = missionTitlePanel.transform.Find("MissionNumberText").gameObject.GetComponent<Text>();
        enemyCounterText = missionTitlePanel.transform.Find("EnemyCounterText").gameObject.GetComponent<Text>();
        playerLifeText = missionTitlePanel.transform.Find("PlayerLifeText").gameObject.GetComponent<Text>();
    }

    public void DisplayMissionTitle()
    {
        missionNumberText.text = "ミッション " + missionNumber;
        enemyCounterText.text = "敵戦車 あと" + remainEnemyNum + "体";
        playerLifeText.text = "残機 " + playerLife;
        missionTitlePanel.SetActive(true);
    }
    public void DisplayMissionClearFlag()
    {
        missionClearFlagPanel.SetActive(true);
    }
    public void DisplayMissionFailFlag()
    {
        missionFailFlagPanel.SetActive(true);
    }

    public void EnemyDestroy(string enemyName)
    {
        remainEnemyNum--;
        for(int i = 0; i < enemyNumSetStage; i++)
        {
            if(enemyPrefabSetStage[i].name == enemyName)
            {
                enemyIsDeath[i] = true;
                break;
            }
        }
    }
    public void PlayerDestroy()
    {
        playerLife--;
    }
    
}
