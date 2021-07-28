using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyType
{
    Shooter shooter;

    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (isFacingRight)
        {
            dir = Vector2.right;
        }
        else
        {
            dir = -Vector2.right;
        }

        //Debug.DrawRay(position, dir * playerCheckRadius, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, dir, playerCheckRadius, player);
        
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Shoot();
            }
        }
        else
        {
            Patrol();
        }
    }
}
