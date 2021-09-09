using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IEnemy
{
    EnemySpawner enemySpawner;

    public int health;
    public float moveSpeed;

    public GameObject[] patrolPoint;
    private int currentPoint = 0;
    private float radius = 1f;
    private bool hasPatrolPoints = false;

    public static bool isFacingRight = false;

    public LayerMask player;
    public float playerCheckRadius = 1.0f;

    public Transform detectPlayer;
    public Transform launchPoint;
    public GameObject bombPrefab;
    public GameObject hpDropPrefab;

    Vector2 dir;

    [SerializeField]
    private float attackCooldown;
    private float timeBtwAttack;

    public Animator anim;
    Coroutine coroutine;

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

        RaycastHit2D hit = Physics2D.CircleCast(detectPlayer.position, playerCheckRadius, dir, 0, player);

        if (hit.collider != null)
        {
            anim.SetBool("playerDetected", true);
            if (timeBtwAttack < 0)
            {
                coroutine = StartCoroutine(ChangeAttackAnim());
                timeBtwAttack = attackCooldown;
            }
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

    IEnumerator ChangeAttackAnim()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bombPrefab, launchPoint.position, transform.rotation);
        anim.SetBool("isAttacking", false);
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
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectPlayer.position, playerCheckRadius);
    }

    private void Die()
    {
        int roll = Random.Range(0, 5);
        if (roll < 2)
        {
            Instantiate(hpDropPrefab, transform.position, Quaternion.identity);
        }
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
