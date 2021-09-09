using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
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
            anim.SetBool("doorOpen", true);
            GameManager.instance.doorOpened[doorID] = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance.unlockedEnding == true)
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
