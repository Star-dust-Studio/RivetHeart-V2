using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptDestroyOthers : MonoBehaviour
{
    private AsyncOperation operation;

    private void Awake()
    {
        

        GameObject[] LowAmObj = GameObject.FindGameObjectsWithTag("LowAm");
        foreach (GameObject LowAm in LowAmObj)
        {
            GameObject.Destroy(LowAm);
        }

        GameObject[] MainAmObj = GameObject.FindGameObjectsWithTag("MainAm");
        foreach (GameObject MainAm in MainAmObj)
        {
            GameObject.Destroy(MainAm);
        }

        GameObject[] CatAmObj = GameObject.FindGameObjectsWithTag("CatAm");
        foreach (GameObject CatAm in CatAmObj)
        {
            GameObject.Destroy(CatAm);
        }

        GameObject[] GreenAmObj = GameObject.FindGameObjectsWithTag("GreenAm");
        foreach (GameObject GreenAm in GreenAmObj)
        {
            GameObject.Destroy(GreenAm);
        }

        GameObject[] HighAmObj = GameObject.FindGameObjectsWithTag("HighAm");
        foreach (GameObject HighAm in HighAmObj)
        {
            GameObject.Destroy(HighAm);
        }
    }
}
