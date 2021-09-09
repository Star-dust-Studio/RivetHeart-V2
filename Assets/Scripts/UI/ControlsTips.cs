using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlsTips : MonoBehaviour
{
    public Controls controls;
    private TextMeshProUGUI tipsText;
    public float timeToHide = 2f;
    public float fadeSpeed = 1.5f;
    private float autoHideTime = 7f;
    Coroutine coroutine;

    private void Start()
    {
        tipsText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (controls)
        {
            case Controls.Move:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    GameManager.instance.doneMove = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Jump:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.instance.doneJump = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Interact:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.instance.doneInteract = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Inventory:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    GameManager.instance.doneInventory = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Map:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.M))
                {
                    GameManager.instance.doneMap = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Shoot:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.instance.doneShoot = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            case Controls.Grapple:
                coroutine = StartCoroutine(AutoHideText());
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    GameManager.instance.doneGrapple = true;
                    coroutine = StartCoroutine(HideText());
                }
                break;
            default:
                break;
        }
    }

    IEnumerator HideText()
    {
        tipsText.CrossFadeAlpha(0, fadeSpeed, false);
        yield return new WaitForSeconds(timeToHide);
        tipsText.gameObject.SetActive(false);
    }

    IEnumerator AutoHideText()
    {
        yield return new WaitForSeconds(autoHideTime);
        tipsText.CrossFadeAlpha(0, fadeSpeed, false);
        yield return new WaitForSeconds(timeToHide);
        tipsText.gameObject.SetActive(false);
    }
}
