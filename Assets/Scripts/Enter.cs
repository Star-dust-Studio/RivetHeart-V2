using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    public string entrancePassword;
    private void Start()
    {
        if (PlayerManager.instance.scenePassword == entrancePassword) 
        {
            PlayerManager.instance.transform.position = transform.position;
            Debug.Log("ENTER!");
        }
        else 
        {
            Debug.Log("WRONG PASSWORD!");
        }
    }
}
