using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public SlingGun slingGun;
    public GrapplingHook grapplingHook;
    public GameObject slingGunObject;
    public GameObject grappleGunObject;

    // Start is called before the first frame update
    void Start()
    {
        slingGun.enabled = false;
        grapplingHook.enabled = false;
        slingGunObject.SetActive(false);
        grappleGunObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            slingGun.enabled = false;
            grapplingHook.enabled = true;
            slingGunObject.SetActive(false);
            grappleGunObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            slingGun.enabled = true;
            grapplingHook.enabled = false;
            slingGunObject.SetActive(true);
            grappleGunObject.SetActive(false);
        }
    }
}
