using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHandler : MonoBehaviour
{
    public bool hideHPInfo = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.alwaysHideHP = hideHPInfo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
