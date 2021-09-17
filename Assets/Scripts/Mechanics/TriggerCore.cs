using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCore : MonoBehaviour
{
    private bool canInteract = false;
    public GameObject interactText;

    private void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            PlayerManager.instance.InfoVisibility(false);
            PlayerManager.instance.SetPlayerState(PlayerState.DEAD);
            SceneManager.LoadScene("Ending 1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactText.SetActive(true);

            if (GameManager.instance.totalComponentCollected == 6)
            {
                canInteract = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactText.SetActive(false);
            canInteract = false;
        }
    }
}
