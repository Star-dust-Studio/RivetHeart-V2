using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorSwitch : MonoBehaviour, IInteractable
{
    public Elevator elevator;
    public GameObject interactSprite;

    private void Start()
    {
        interactSprite.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(false);
        }
    }

    public void Execute()
    {
        elevator.EngageElevator();
    }
}
