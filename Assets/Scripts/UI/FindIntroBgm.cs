using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindIntroBgm : MonoBehaviour
{
    public GameObject introBgm;

    // Start is called before the first frame update
    void Start()
    {
        introBgm = GameObject.Find("IntroBgm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
