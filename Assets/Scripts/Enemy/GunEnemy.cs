using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour, IEnemy
{
    EnemySpawner enemySpawner;

    public int health;
    public float moveSpeed;

    public GameObject[] patrolPoint;
    private int currentPoint = 0;
    private float radius = 1f;
    private bool hasPatrolPoints = false;

    public bool isFacingRight = false;
    private bool isShooting = false;

    public LayerMask player;
    public float playerCheckRadius = 1.0f;

    public GameObject bulletPrefab;
    public Transform firepoint;
    [SerializeField]
    private float attackCooldown;
    private float timeBtwAttack;

    Vector2 dir;

    public Animator anim;
    Coroutine coroutine;

    public GameObject hpDropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        timeBtwAttack = -1;
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

        RaycastHit2D[] hits = Physics2D.CircleCastAll(position, 1f, dir, playerCheckRadius, player);

        foreach(RaycastHit2D hit in hits)
        {
            isShooting = true; 
        }

        if (isShooting)
        {
            anim.SetBool("playerDetected", true);
            Shoot();
        }
        else
        {
            anim.SetBool("playerDetected", false);

            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            if (hasPatrolPoints)
            {
                Patrol();
            }
        }

        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        if (timeBtwAttack < 0)
        {
            coroutine = StartCoroutine(ChangeAttackAnim());
            timeBtwAttack = attackCooldown;
        }
    }

    IEnumerator ChangeAttackAnim()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.6f);
        Instantiate(bulletPrefab, firepoint.position, transform.localRotation);
        anim.SetBool("isAttacking", false);
        isShooting = false;
    }

    private void Patrol()
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
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    private void Die()
    {
        Instantiate(hpDropPrefab, transform.position, Quaternion.identity);
        enemySpawner.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public void MinusEnemyHP(int value)
    {
        health -= value;
        Debug.Log("enemy hp: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void InitializePatrolSize(int size)
    {
        patrolPoint = new GameObject[size];
    }

    public void AssignPatrolPoints(GameObject point, int i)
    {
        patrolPoint[i] = point;

        if (i == patrolPoint.Length - 1)
        {
            hasPatrolPoints = true;
        }
    }
}
