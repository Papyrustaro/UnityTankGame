using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadTitle()
    {
        InitAllData.InitData();
        SceneManager.LoadScene("Title");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void LoadSinglePlay()
    {
        SceneManager.LoadScene("SinglePlay");
    }

    public void LoadSingleMissionSelectTank()
    {
        MainGameController.gameNumber = 1;
        SceneManager.LoadScene("PlayerSelectTank");
    }

    public void LoadSurvivalSelectTank()
    {
        MainGameController.gameNumber = 2;
        SceneManager.LoadScene("PlayerSelectTank");
    }

    public void LoadDescriptionPlay()
    {
        SceneManager.LoadScene("DescriptionPlay");
    }

    public void LoadDescriptionEnemy()
    {
        SceneManager.LoadScene("DescriptionEnemy");
    }
    public void LoadDescriptionMission()
    {
        SceneManager.LoadScene("DescriptionMission");
    }
    public void LoadDescriptionSurvival()
    {
        SceneManager.LoadScene("DescriptionSurvival");
    }
    public void LoadDescriptionBasicRule()
    {
        SceneManager.LoadScene("DescriptionBasicRule");
    }
    public void LoadHowToPlayMenu()
    {
        SceneManager.LoadScene("HowToPlayMenu");
    }
    public void LoadRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
    public void LoadSearchSecretButton()
    {
        SceneManager.LoadScene("SearchSecretButton");
    }
    public void LoadSinglePlayFromPlayerSelect()
    {
        MainGameController.gameNumber = 0;
        SceneManager.LoadScene("SinglePlay");
    }
}
