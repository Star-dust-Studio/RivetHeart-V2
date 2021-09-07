using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public Button StartButton;
    public Button QuitGame;
    public Button OptionsButton;
    public Button OptionsPanel;
    public Button BackToOption;
    public Button AudioPanel;
    public Button AudioButton;
    public Button VideoPanel;
    public Button VideoButton;
    public Button BackToMenuButton;
    public Button ConfirmationPanel;
    public Button YesButton;
    public Button NoButton;
    public Button ControlsButton;
    public Button ControlsPanel;
    public Button pausePanel;

    ///[SerializeField]
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
                DisplaypausePanel();
            }
            else
            {
                paused = false;
                HidepausePanel();
            }
        }
    }

    public void DisplaypausePanel()
    {
        pausePanel.gameObject.SetActive(true);
    }

    public void HidepausePanel()
    {
        pausePanel.gameObject.SetActive(false);
    }




    public void DisplayOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(true);
    }

    public void HideOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(false);
    }




    public void DisplayAudioPanel()
    {
        AudioPanel.gameObject.SetActive(true);
    }

    public void HideAudioPanel()
    {
       AudioPanel.gameObject.SetActive(false);
    }




    public void DisplayVideoPanel()
    {
        VideoPanel.gameObject.SetActive(true);
    }

    public void HideVideoPanel()
    {
       VideoPanel.gameObject.SetActive(false);
    }




    public void DisplayConfirmationPanel()
    {
        ConfirmationPanel.gameObject.SetActive(true);
    }

    public void HideConfirmationPanel()
    {
        ConfirmationPanel.gameObject.SetActive(false);
    }



    public void DisplayControlsPanel()
    {
        ControlsPanel.gameObject.SetActive(true);
    }

    public void HideControlsPanel()
    {
        ControlsPanel.gameObject.SetActive(false);
    }






    public void ButtonQuitGame()    //quit game
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }





    public void ButtonYesButton()    //quit to menu
    {
        HideConfirmationPanel();
    }

    public void ButtonNoButton()    //stay at options menu
    {
        HideConfirmationPanel();
        DisplayOptionsPanel();
    }

    public void ButtonNoButtonforPause()    //stay at pause menu
    {
        HideConfirmationPanel();
        DisplaypausePanel();
    }

    public void ButtonBackToMenuButton()    //back to menu
    {
        DisplayConfirmationPanel();
        HideOptionsPanel();
    }


    public void ButtonAudioButton()    //open audio panel
    {
        DisplayAudioPanel();
        HideOptionsPanel();
    }



    public void ButtonVideoButton()    //open video panel
    {
        DisplayVideoPanel();
        HideOptionsPanel();
    }



    public void ButtonBackToOptions()    //back to options menu
    {
        DisplayOptionsPanel();
        HideAudioPanel();
        HideVideoPanel();
        HideControlsPanel();
    }



    public void ButtonOptionsButton()    //open options menu
    {
        DisplayOptionsPanel();
    }



    public void ButtonControlsButton()    //open controls menu
    {
        DisplayControlsPanel();
        HideOptionsPanel();
    }
}