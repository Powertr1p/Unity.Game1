using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public Canvas creditsPopup;

    private void Start()
    {
        creditsPopup.enabled = false;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreditsButtonClick()
    {
        creditsPopup.enabled = true;
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnClosePopupButton()
    {
        creditsPopup.enabled = false;
    }

}
