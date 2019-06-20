using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void OnOnePlayButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
}
