using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
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
}
