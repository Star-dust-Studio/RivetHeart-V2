using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorSwitch : MonoBehaviour
{
    public Elevator elevator;
    public GameObject interactSprite;
    //[SerializeField] private int floorInput;

    private void Start()
    {
        interactSprite.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactSprite.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("change floorrrr");
                elevator.ChangeFloor(1);
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
