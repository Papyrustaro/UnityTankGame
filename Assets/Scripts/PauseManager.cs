using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public Button resumeButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ctrl"))
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            if (pauseUI.activeSelf)
            {
                resumeButton.Select();
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void OnResumeButtonClicked()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }
    public void OnGoToMenuButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
