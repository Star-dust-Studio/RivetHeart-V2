using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.isNewGame == true)
        {
            PlayerManager.instance.gameObject.SetActive(true);
            PlayerManager.instance.gameObject.transform.position = spawnpoint.position;
        }
        GameManager.instance.isNewGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
