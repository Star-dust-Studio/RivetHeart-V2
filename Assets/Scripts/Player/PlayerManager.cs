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
    public bool grappleObtained = false;
    public GameObject slingGun;
    public SlingGun slingGunScript;
    public SlingRope slingRopeScript;
    public SpringJoint2D springJoint2D;

    [Header("Info Tracker")]
    public int maxHP = 4;
    private int currentHP;
    public Transform playerPosition;
    public PlayerState playerState;
    public PlayerMovement playerMovement;
    private float storedSpeed;
    public float hurtSlowSpeed;
    public float invincibility = 3f;
    private float storedInvincibleValue;
    private bool isVulnerable = true;

    [Header("UI")]
    public GameObject info;
    public GameObject hookUISprite;
    public GameObject[] hpBulb;
    public GameObject dieOverlay;
    Animator dieOverlayAnim;
    Animator anim;

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
        StartCoroutine(SlowStart());
        playerPosition = GetComponent<Transform>();
        SetToolType(Tool.GRAPPLINGHOOK);
        storedSpeed = playerMovement.speed;
        currentHP = maxHP;
        storedInvincibleValue = invincibility;
        if (grappleObtained)
        {
            hookUISprite.SetActive(true);
        }
        else
        {
            hookUISprite.SetActive(false);
        }
        anim = GetComponent<Animator>();
        dieOverlayAnim = dieOverlay.GetComponent<Animator>();
        dieOverlay.SetActive(false);
    }

    IEnumerator SlowStart()
    {
        InfoVisibility(false);
        SetPlayerState(PlayerState.DEAD);
        yield return new WaitForSeconds(2);
        SetPlayerState(PlayerState.ALIVE);
        yield return new WaitForSeconds(1);
        InfoVisibility(true);
    }

    private void Update()
    {
        if (!isVulnerable)
        {
            if (invincibility > 0)
            {
                invincibility -= Time.deltaTime;
            }
            else
            {
                isVulnerable = true;
                invincibility = storedInvincibleValue;
            }
        }
    }

    public void UnlockGrapple()
    {
        grappleObtained = true;
        hookUISprite.SetActive(true);
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

    public void AddHP(int healpoint)
    {
        if (currentHP > 0 && currentHP < maxHP)
        {
            currentHP += healpoint;
            Debug.Log("Player HP: " + currentHP);
            hpBulb[currentHP - 1].SetActive(true);
        }
    }

    public void MinusHP(int damage)
    {       
        if (isVulnerable)
        {
            if (currentHP > 1)
            {
                isVulnerable = false;
                currentHP -= damage;
                StartCoroutine(ChangeSpeed());
                Debug.Log("Player HP: " + currentHP);
                hpBulb[currentHP].SetActive(false);
            }
            else
            {
                isVulnerable = false;
                currentHP -= damage;
                hpBulb[currentHP].SetActive(false);
                //die
                SetPlayerState(PlayerState.DEAD);
                anim.SetBool("dead", true);
                dieOverlay.SetActive(true);                
                StartCoroutine(PlayerRespawn());
            }
        }        
    }

    IEnumerator ChangeSpeed()
    {
        playerMovement.speed = hurtSlowSpeed;
        yield return new WaitForSeconds(1);
        playerMovement.speed = storedSpeed;
    }

    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(2f);
        dieOverlayAnim.SetBool("died", true);
        anim.SetBool("dead", false);
        isVulnerable = false;
        yield return new WaitForSeconds(3f);
        dieOverlayAnim.SetBool("died", false);
        SetPlayerState(PlayerState.ALIVE);
        RestoreHealth();
        dieOverlay.SetActive(false);
        yield return new WaitForSeconds(1f);
        isVulnerable = true;
    }

    void RestoreHealth()
    {
        currentHP = maxHP;
        for (int i = 0; i < hpBulb.Length; i++)
        {
            hpBulb[i].SetActive(true);
        }
    }

    public void InfoVisibility(bool state)
    {
        info.SetActive(state);
    }
}
