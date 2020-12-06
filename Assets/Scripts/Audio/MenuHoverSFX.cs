using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHoverSFX : MonoBehaviour
{
    public AudioSource Selecting;

    public void PlaySelecting()
    {
        Selecting.Play();
    }
}
