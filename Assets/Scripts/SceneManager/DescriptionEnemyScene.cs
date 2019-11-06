using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionEnemyScene : MonoBehaviour
{
    public GameObject descriptionText0;
    public GameObject descriptionText1;
    public GameObject previousPageButton;
    public GameObject nextPageButton;

    public void OnPressPreviousPageButton()
    {
        this.descriptionText0.SetActive(true);
        this.descriptionText1.SetActive(false);
        this.previousPageButton.SetActive(false);
        this.nextPageButton.SetActive(true);

        nextPageButton.GetComponent<Button>().Select();
    }
    public void OnPressNextPageButton()
    {
        this.descriptionText0.SetActive(false);
        this.descriptionText1.SetActive(true);
        this.previousPageButton.SetActive(true);
        this.nextPageButton.SetActive(false);

        previousPageButton.GetComponent<Button>().Select();
    }
}
