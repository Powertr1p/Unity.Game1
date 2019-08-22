using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Canvas CreditsPopup;
    protected Animator _creditsShowAnimator;

    private void Start()
    {
        _creditsShowAnimator = CreditsPopup.GetComponent<Animator>();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreditsButtonClick()
    {
        _creditsShowAnimator.SetBool("Show", true);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    public void OnClosePopupButton()
    {
        _creditsShowAnimator.SetBool("Show", false);
    }

}
