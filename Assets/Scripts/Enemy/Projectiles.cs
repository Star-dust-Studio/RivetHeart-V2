using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 20f;
    public int projectilesDmg = 1;

    protected virtual void Start()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit player");
            PlayerManager.instance.MinusHP(projectilesDmg);
        }
        Destroy(gameObject);
    }
}
