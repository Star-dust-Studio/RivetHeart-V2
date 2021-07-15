using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [Header("Weapon & Tool")]
    public GrapplingHook GrapplingHookScript;
    public bool SlingGunObtained = false;
    public GameObject SlingGun;
    public SlingGun SlingGunScript;
    public SlingRope SlingRopeScript;
    public SpringJoint2D SpringJoint2D;

    [Header("Info Tracker")]
    public int HP = 5;

    public enum Tool
    {
        GRAPPLINGHOOK,
        SLINGGUN
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetToolType(Tool.GRAPPLINGHOOK);
    }

    private void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.L))
        {
            UnlockSlingshot();
            SetToolType(Tool.SLINGGUN);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetToolType(Tool.GRAPPLINGHOOK);
        }
    }

    public void UnlockSlingshot()
    {
        SlingGunObtained = true;
    }

    public void SetToolType(Tool toolType)
    {
        switch (toolType)
        {
            case Tool.GRAPPLINGHOOK:
                {
                    GrapplingHookScript.enabled = true;
                    GrapplingHookScript.ResetRope();
                    SlingGun.SetActive(false);
                    SlingGunScript.enabled = false;
                    SlingRopeScript.enabled = false;
                    SpringJoint2D.enabled = false;
                    break;
                }
            case Tool.SLINGGUN:
                {
                    GrapplingHookScript.enabled = false;
                    GrapplingHookScript.ResetRope();
                    SlingGun.SetActive(true);
                    SlingGunScript.enabled = true;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
