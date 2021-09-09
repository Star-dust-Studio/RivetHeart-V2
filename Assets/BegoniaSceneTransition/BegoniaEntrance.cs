using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegoniaEntrance : MonoBehaviour
{
    public string entrancePassword;

    // Start is called before the first frame update
    private void Start()
    {
        if (BegoniaPlayerMovement.instance != null)
        {
            if (BegoniaPlayerMovement.instance.scenePassword == entrancePassword)
            {
                BegoniaPlayerMovement.instance.transform.position = transform.position; //transform.position is the entrance position
                Debug.Log("ENTER!");
            }
            else
            {
                Debug.Log("WRONG PW!");
            }
        }       
    }
}
