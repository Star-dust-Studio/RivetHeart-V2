using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDrops : MonoBehaviour
{
    public int healpoint = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.AddHP(healpoint);
            Destroy(gameObject);
        }
    }
}
