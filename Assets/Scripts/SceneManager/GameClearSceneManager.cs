using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearSceneManager : MonoBehaviour
{
    public Button continueButton;
    public Button moveMenuSceneButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.Select();
    }

    // Update is called once per frame
    public void OnContinueButtonClicked()
    {
        SceneManager.LoadScene("PlayerSelectTank");
    }
    public void OnMoveMenuSceneButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
}
