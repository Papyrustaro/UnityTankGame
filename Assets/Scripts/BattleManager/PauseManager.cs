using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class PauseManager : MonoBehaviour
{
    public Button resumeButton;
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        if ((MainGameController.gameNumber == 1 && SingleMissionStaticData.pauseAble) || (MainGameController.gameNumber == 2 && SingleSurvivalStaticData.pauseAble))
        {
            if (Input.GetButtonDown("Ctrl"))
            {
                this.pausePanel.SetActive(!this.pausePanel.activeSelf);
                if (this.pausePanel.activeSelf)
                {
                    BGMManager.SetVolume(0.5f);
                    resumeButton.Select();
                    Time.timeScale = 0f;
                }
                else
                {
                    BGMManager.SetVolume(1f);
                    Time.timeScale = 1f;
                }
            }
        }
    }
    public void OnResumeButtonClicked()
    {
        BGMManager.SetVolume(1f);
        this.pausePanel.SetActive(false);
        StartCoroutine(DelayMethod(5, () =>
        {
            Time.timeScale = 1f;
        }));
    }
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SingleSample");
    }
    public void OnGoToMenuButtonClicked()
    {
        Time.timeScale = 1f;
        InitAllData.InitData();
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for(int i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
}
