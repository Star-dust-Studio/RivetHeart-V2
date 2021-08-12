using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderProjectiles : Projectiles
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }
}
