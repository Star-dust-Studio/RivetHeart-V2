using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    Animator anim;
    private bool canInteract = false;
    public int doorID;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (GameManager.instance.doorOpened[doorID] == true)
        {
            anim.SetBool("doorGone", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.instance.UseKey();
            anim.SetBool("doorOpen", true);
            GameManager.instance.doorOpened[doorID] = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (InventoryManager.instance.keyNumber > 0)
            {
                canInteract = true;
            }
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
