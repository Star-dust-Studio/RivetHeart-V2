using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playSoundC : MonoBehaviour
{
    public AudioClip mysfx;
    AudioSource mySource;

    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

    void OnMouseUp()
    {
        mySource.PlayOneShot(mysfx);
    }
}
