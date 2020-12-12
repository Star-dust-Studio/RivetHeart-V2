using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorSwitch : MonoBehaviour
{
    public Elevator elevator;
    public GameObject interactSprite;
    [SerializeField] private int floorInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                elevator.ChangeFloor(floorInput);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(false);
        }
    }
}
