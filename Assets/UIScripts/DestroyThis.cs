using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    private AsyncOperation operation;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        foreach (GameObject MusicBgm in musicObj)
        {
            GameObject.Destroy(MusicBgm);
        }

    }
}
