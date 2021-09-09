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
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                {
                    GameManager.instance.doneMove = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Jump:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.instance.doneJump = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Interact:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.instance.doneInteract = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Inventory:
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    GameManager.instance.doneInventory = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Map:
                if (Input.GetKeyDown(KeyCode.M))
                {
                    GameManager.instance.doneMap = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Shoot:
                if (Input.GetMouseButtonDown(0))
                {
                    GameManager.instance.doneShoot = true;
                    StartCoroutine(HideText());
                }
                break;
            case Controls.Grapple:
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    GameManager.instance.doneGrapple = true;
                    StartCoroutine(HideText());
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
}
