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
    public Button BackToMenuButton;
    public Button ConfirmationPanel;
    public Button YesButton;
    public Button NoButton;
    public Button ControlsButton;
    public Button ControlsPanel;
   
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

    public void ButtonBackToOptions()    //back to options menu
    {
        DisplayOptionsPanel();
        HideAudioPanel();
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