using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    public Button OnePlayButton;
    public Button EveryonePlayButton;
    public Button UserDataButton;
    public Button OptionButton;

    private void Start()
    {
        OnePlayButton.Select();
    }
    public void OnOnePlayButtonClicked()
    {
        SEManager.PlaySubmitSound();
        SceneManager.LoadScene("PlayerSelectTank");
    }
}
