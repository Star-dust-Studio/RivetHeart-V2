using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed = 20f;
    public int projectilesDmg = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit player");
            collision.GetComponent<PlayerHP>().MinusPlayerHP(projectilesDmg);
        }
        Destroy(gameObject);
    }
}
