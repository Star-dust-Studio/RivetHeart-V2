using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public int health;
    public float moveSpeed;

    public Transform spawnPoint;
    public Transform[] patrolPoint;
    private int currentPoint = 0;
    private float radius = 1f;

    public static bool isFacingRight = true;

    public LayerMask player;
    public float playerCheckRadius = 1.0f;

    private void Start()
    {
        transform.position = spawnPoint.position;
    }

    public virtual void Patrol()
    {
        if (Vector2.Distance(patrolPoint[currentPoint].transform.position, transform.position) < radius)
        {
            currentPoint++;
            if (currentPoint >= patrolPoint.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, patrolPoint[currentPoint].transform.position, Time.deltaTime * moveSpeed);

        if (isFacingRight == false && transform.position.x < patrolPoint[currentPoint].transform.position.x)
        {
            FlipCharacter();
        }
        else if (isFacingRight == true && transform.position.x > patrolPoint[currentPoint].transform.position.x)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void MinusEnemyHP(int value)
    {
        health -= value;
        Debug.Log("enemy hp: " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
