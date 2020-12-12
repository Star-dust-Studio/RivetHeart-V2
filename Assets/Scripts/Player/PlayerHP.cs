using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject[] hpSprite;

    private int maxHealth;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
    }

    private void MinusHP(int value)
    {
        currentHealth -= value;
        if (value >= 2)
        {
            for (int i = currentHealth; i < maxHealth; i++)
            {
                hpSprite[i + 1].SetActive(false);
            }
        }
        else
        {
            hpSprite[currentHealth + 1].SetActive(false);
        }
    }

    private void FullHeal()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            hpSprite[i].SetActive(true);
        }
    }
}
