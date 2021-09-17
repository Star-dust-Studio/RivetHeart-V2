using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [Header("Panels")]
    public List<GameObject> panels;
    public GameObject pausePanel;

    private bool paused;
    private bool openInventory;

    [Header("Buttons")]
    public Button continueButton;
    public Button optionsButton;
    public Button backToMenuButton;
    public Button btmYesButton;
    public Button btmNoButton;
    public Button audioButton;
    public Button videoButton;
    public Button controlsButton;
    public Button backToPauseMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        HideAllPanels();
        paused = false;
        openInventory = false;
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
                ShowPausePanel(true);
            }
            else
            {
                PlayerManager.instance.SetPlayerState(PlayerState.ALIVE);
                PlayerManager.instance.InfoVisibility(true);
                paused = false;
                HideAllPanels();
            }
        }

        if (PlayerManager.instance.playerState == PlayerState.ALIVE)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!openInventory)
                {
                    PlayerManager.instance.InfoVisibility(false);
                    openInventory = true;
                    ShowInventoryPanel(true);
                }
                else
                {
                    PlayerManager.instance.InfoVisibility(true);
                    openInventory = false;
                    HideAllPanels();
                }
            }
        }
    }

    private void HideAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }

    private void ShowInventoryPanel(bool state)
    {
        panels[0].SetActive(state);
    }

    private void ShowPausePanel(bool state)
    {
        panels[1].SetActive(state);
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
    }

    public void ShowOptions(bool state)
    {
        panels[2].SetActive(state);
    }

    public void OpenBTMConfirmation()
    {
        panels[3].SetActive(true);
    }

    public void BTMYes()
    {
        HideAllPanels();
        SceneManager.LoadScene("BMenu");
    }

    public void BTMNo()
    {
        panels[3].SetActive(false);
    }

    public void ShowAudio(bool state)
    {
        panels[4].SetActive(state);
    }

    public void ShowVideo(bool state)
    {
        panels[5].SetActive(state);
    }

    public void ShowControls(bool state)
    {
        panels[6].SetActive(state);
    }   
}
