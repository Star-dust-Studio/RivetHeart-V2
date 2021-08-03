using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //for typewriter
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";


    //for dialogue pop up
    public GameObject popUpBox;
    public Button CloseButton;
    public Button DialoguePanel;

    //for interaction text
    public GameObject interactionText;
    public GameObject triggerbox;

   
    void Start()
    {
        StartCoroutine(ShowText()); //for typewriter

        interactionText.SetActive(false); //for interaction text
    }


    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    //for pop up
    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
    }

    public void ButtonCloseButton()    //Close dialogue
    {
        HideDialoguePanel();
    }


    public void DisplayDialoguePanel()
    {
        DialoguePanel.gameObject.SetActive(true);
    }

    public void HideDialoguePanel()
    {
        DialoguePanel.gameObject.SetActive(false);
    }


    public void DisplayInteractionText()
    {
        interactionText.SetActive(true);
    }


    //for interaction text
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DisplayInteractionText();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interactionText.SetActive(false);
    }
}
