using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTips : MonoBehaviour
{
    public Controls controls;
    public GameObject text;
    private bool checker;
    
    private void Start()
    {
        checker = GameManager.instance.CheckTutorial(controls);

        if (!checker)
        {
            gameObject.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
        }

        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (controls == Controls.Move)
            {
                StartCoroutine(SlowShow());
            }
            else
            {
                text.SetActive(true);
                Destroy(gameObject);
            }            
        }
    }

    IEnumerator SlowShow()
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(true);
        Destroy(gameObject);
    }
}
