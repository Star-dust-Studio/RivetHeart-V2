using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorSwitch : MonoBehaviour
{
    public Elevator elevator;
    private bool canInteract;
    public GameObject interactSprite;

    private void Start()
    {
        interactSprite.SetActive(false);
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            elevator.EngageElevator();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(false);
            canInteract = false;
        }
    }
}
