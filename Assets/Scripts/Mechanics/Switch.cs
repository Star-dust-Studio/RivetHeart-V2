using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public SwitchDoor switchDoor;
    private bool isOpened = false;
    private bool canInteract = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (GameManager.instance.doorOpened[switchDoor.doorID] == true)
        {
            anim.SetBool("stayActivated", true);
            isOpened = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpened && canInteract && Input.GetKeyDown(KeyCode.E))
        {
            switchDoor.OpenDoor();
            anim.SetBool("isActivated", true);
            isOpened = true;
            GameManager.instance.doorOpened[switchDoor.doorID] = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
