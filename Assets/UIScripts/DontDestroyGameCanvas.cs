using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameCanvas : MonoBehaviour
{
    private AsyncOperation operation;
    private Canvas BGameCanvas;

    //public GameObject CreditBgm;


    private void Awake()
    {
        BGameCanvas = GetComponentInChildren<Canvas>(true);
        DontDestroyOnLoad(gameObject);
        GameObject[] gameCanvas = GameObject.FindGameObjectsWithTag("GameCanvas");
        if (gameCanvas.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

}
