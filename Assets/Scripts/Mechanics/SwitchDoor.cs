using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    Animator anim;
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

    public void OpenDoor()
    {
        anim.SetBool("doorOpen", true);
    }
}
