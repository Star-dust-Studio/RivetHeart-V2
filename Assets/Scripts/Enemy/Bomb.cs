using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;

    public float speed = 1;
    public Vector3 launchOffset;

    // Start is called before the first frame update
    void Start()
    {
        var direction = -transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);

        transform.Translate(launchOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
