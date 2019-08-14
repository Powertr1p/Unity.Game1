using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public Canvas creditsPopup;
    protected Animator creditsShowAnimator;

    private void Start()
    {
        creditsShowAnimator = creditsPopup.GetComponent<Animator>();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreditsButtonClick()
    {
        creditsShowAnimator.SetBool("Show", true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnClosePopupButton()
    {
        creditsShowAnimator.SetBool("Show", false);
    }

}
