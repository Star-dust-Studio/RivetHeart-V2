using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameControl : MonoBehaviour
{
    private AsyncOperation operation;
    //private Canvas BGameCanvas;

    //public GameObject CreditBgm;


    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }


        GameObject[] MainAmObj = GameObject.FindGameObjectsWithTag("MainAm");
        if (MainAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject[] LowAmObj = GameObject.FindGameObjectsWithTag("LowAm");
        if (LowAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject[] CatAmObj = GameObject.FindGameObjectsWithTag("CatAm");
        if (CatAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject[] GreenAmObj = GameObject.FindGameObjectsWithTag("GreenAm");
        if (GreenAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject[] HighAmObj = GameObject.FindGameObjectsWithTag("HighAm");
        if (HighAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        GameObject[] CaptAmObj = GameObject.FindGameObjectsWithTag("CaptAm");
        if (CaptAmObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        //BGameCanvas = GetComponentInChildren<Canvas>(true);
        DontDestroyOnLoad(gameObject);
    }

}
