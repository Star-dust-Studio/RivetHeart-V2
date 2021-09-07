using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameControl : MonoBehaviour
{
    private AsyncOperation operation;
    private Canvas BGameCanvas;

    private void Awake()
    {
        BGameCanvas = GetComponentInChildren<Canvas>(true);
        DontDestroyOnLoad(gameObject);
    }
}
