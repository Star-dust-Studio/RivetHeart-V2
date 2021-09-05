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

    
    public Button CloseButton;
    public Button DialoguePanel;
    public Button InteractionText;

    //for interaction text
    public GameObject interactionText;
    public GameObject triggerbox;

    ///[SerializeField]
    private bool openDialogue;
    private bool interactTextAppear;


    void Start()
    {
        StartCoroutine(ShowText()); //for typewriter

        //interactionText.SetActive(false); //for interaction text


        openDialogue = false;
        interactTextAppear = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!interactTextAppear)
            {
                interactTextAppear = true;
                openDialogue = true;
                DisplayDialoguePanel();
            }
            else
            {
                interactTextAppear = false;
                openDialogue = false;
                HideDialoguePanel();
            }
        }
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

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            interactionText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            DialoguePanel.gameObject.SetActive(false);
        }

    }
}
