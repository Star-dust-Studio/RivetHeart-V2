using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuUIController : MonoBehaviour
{
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
    public Button pausePanel;
    public GameObject InventoryPanel;
    public Button ExitToMenuButton;
    public Button ContinueButton;

    ///[SerializeField]
    private bool paused;
    private bool openInventory;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        openInventory = false;
        pausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PlayerManager.instance.SetPlayerState(PlayerState.PAUSED);
                PlayerManager.instance.InfoVisibility(false);
                paused = true;
                DisplaypausePanel();
            }
            else
            {
                PlayerManager.instance.SetPlayerState(PlayerState.ALIVE);
                PlayerManager.instance.InfoVisibility(true);
                paused = false;
                HidepausePanel();
            }
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!openInventory)
            {
                PlayerManager.instance.InfoVisibility(false);
                openInventory = true;
                DisplayInventoryPanel();
            }
            else
            {
                PlayerManager.instance.InfoVisibility(true);
                openInventory = false;
                HideInventoryPanel();
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
        ConfirmationPanel.gameObject.SetActive(false);
        AudioPanel.gameObject.SetActive(false);
        ControlsPanel.gameObject.SetActive(false);
        PlayerManager.instance.InfoVisibility(true);
        PlayerManager.instance.SetPlayerState(PlayerState.ALIVE);
    }

    public void DisplayInventoryPanel()
    {
        InventoryPanel.gameObject.SetActive(true);
    }

    public void HideInventoryPanel()
    {
        InventoryPanel.gameObject.SetActive(false);
    }

    public void DisplayOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(true);
        ExitToMenuButton.gameObject.SetActive(false);
    }

    public void HideOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(false);
        ExitToMenuButton.gameObject.SetActive(true);
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
        OptionsButton.gameObject.SetActive(false);
        ExitToMenuButton.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
    }

    public void HideConfirmationPanel()
    {
        ConfirmationPanel.gameObject.SetActive(false);
        OptionsButton.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(true);
        ExitToMenuButton.gameObject.SetActive(true);
    }


    public void DisplayControlsPanel()
    {
        ControlsPanel.gameObject.SetActive(true);
    }

    public void HideControlsPanel()
    {
        ControlsPanel.gameObject.SetActive(false);
    }

    public void ButtonYesButtonforPause()    //Back to Menu
    {
        PlayerManager.instance.gameObject.SetActive(false);
        PlayerManager.instance.InfoVisibility(false);
        HideConfirmationPanel();
        HidepausePanel();
        SceneManager.LoadScene("BMenu");

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