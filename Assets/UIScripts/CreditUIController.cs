using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditUIController : MonoBehaviour
{
    public Button BackToMenuButton;
    public Button Yes;
    public Button No;
    public Button ConfirmationPanel;

    ///[SerializeField]
    private bool backtomenu;
    private bool OpenConfirmationPanel;

    // Start is called before the first frame update
    void Start()
    {
        backtomenu = false;
        OpenConfirmationPanel = false; 
    }
    
    public void DisplayConfirmationPanel()
    {
        ConfirmationPanel.gameObject.SetActive(true);
        BackToMenuButton.gameObject.SetActive(false);
    }

    public void HideConfirmationPanel()
    {
        ConfirmationPanel.gameObject.SetActive(false);
        BackToMenuButton.gameObject.SetActive(true);
    }

    public void ButtonYes()    //quit to menu
    {
        SceneManager.LoadScene(0); //load the scene, the scene(1) is manage from unity.
    }

    public void ButtonNo()    //quit to menu
    {
        ConfirmationPanel.gameObject.SetActive(false);
        BackToMenuButton.gameObject.SetActive(true);
    }
}
