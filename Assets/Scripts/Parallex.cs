using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private float length, startposition;
    public GameObject cam;    //which camera
    public float parallexEffect; // How much parallex effect want to apply

    // find start position and length
    void Start()
    {
        startposition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * parallexEffect);

        transform.position = new Vector3(startposition + dist, transform.position.y, transform.position.z);
    }
}
