using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.InfoVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
