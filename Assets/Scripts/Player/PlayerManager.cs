using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    ALIVE,
    DEAD,
    PAUSED
}

public class PlayerManager : MonoBehaviour
{


    public enum Tool
    {
        GRAPPLINGHOOK,
        SLINGGUN
    }

    public static PlayerManager instance { get; private set; }

    [Header("Weapon & Tool")]
    public GrapplingHook grapplingHookScript;
    public bool slingGunObtained = false;
    public GameObject slingGun;
    public SlingGun slingGunScript;
    public SlingRope slingRopeScript;
    public SpringJoint2D springJoint2D;

    [Header("Info Tracker")]
    public int hp = 5;
    public Transform playerPosition;
    public PlayerState playerState;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        playerPosition = GetComponent<Transform>();

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
        slingGunObtained = true;
    }

    public void SetToolType(Tool toolType)
    {
        switch (toolType)
        {
            case Tool.GRAPPLINGHOOK:
                {
                    grapplingHookScript.enabled = true;
                    grapplingHookScript.ResetRope();
                    slingGun.SetActive(false);
                    slingGunScript.enabled = false;
                    slingRopeScript.enabled = false;
                    springJoint2D.enabled = false;
                    break;
                }
            case Tool.SLINGGUN:
                {
                    grapplingHookScript.enabled = false;
                    grapplingHookScript.ResetRope();
                    slingGun.SetActive(true);
                    slingGunScript.enabled = true;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    /// <summary>
    /// Mouse cursor visibility according to player state
    /// </summary>
    /// <param name="state"></param>
    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
        switch (state)
        {
            case PlayerState.ALIVE:
                {
                    Time.timeScale = 1;
                    Cursor.visible = true;
                    break;
                }
            case PlayerState.DEAD:
                {
                    Cursor.visible = true;
                    break;
                }
            case PlayerState.PAUSED:
                {
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    break;
                }
            default:
                {
                    break;
                }
        }

    }

    public void MinusHP(int damage)
    {
        hp -= damage;
    }
}
