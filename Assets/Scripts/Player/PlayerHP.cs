using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject[] hpSprite;

    private int maxHealth;
    private int currentHealth;

    // Spaghetti respawn point
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 4;
        currentHealth = maxHealth;
    }

    public void MinusPlayerHP(int value)
    {
        currentHealth -= value;
        //if (value >= 2)
        //{
            for (int i = currentHealth; i < maxHealth; i++)
            {
                hpSprite[i].SetActive(false);
            }
        //}
        //else
        //{
            //hpSprite[currentHealth + 1].SetActive(false);
        //}
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            //GetComponent<PlayerMovement>().playerState = 2;
            GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.5f);
        transform.position = respawnPoint.position; // Spaghetti code
        GetComponent<SpriteRenderer>().enabled = true;
        FullHeal();
        //GetComponent<PlayerMovement>().playerState = 0;
    }

    private void FullHeal()
    {
        currentHealth = maxHealth;
        for (int i = 0; i < maxHealth; i++)
        {
            hpSprite[i].SetActive(true);
        }
    }
}
