using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour, IEnemy
{
    EnemySpawner enemySpawner;

    public int health;
    public float moveSpeed;
    private float storedSpeed;

    public GameObject[] patrolPoint;
    private int currentPoint = 0;
    private float radius = 1f;
    private bool hasPatrolPoints = false;

    public static bool isFacingRight = false;

    public LayerMask player;
    public float playerCheckRadius = 1.0f;
    private bool isPlayer;

    [SerializeField]
    private float attackCooldown;
    private float timeBtwAttack;
    [SerializeField]
    private int attackDamage = 1;
    public float attackRadius = 1f;

    [SerializeField]
    private Transform attackPos;

    Vector2 dir;
    Transform playerPos;
    bool canCast = true;
    public Animator anim;

    public GameObject hpDropPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        storedSpeed = moveSpeed;
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        timeBtwAttack = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (canCast)
        {
            RaycastHit2D[] playerHits = Physics2D.CircleCastAll(position, 0.5f, dir, playerCheckRadius, player);

            foreach (RaycastHit2D playerHit in playerHits)
            {
                isPlayer = true;
            }
        }

        RaycastHit2D hit = Physics2D.CircleCast(attackPos.position, attackRadius, dir, 0, player);

        if (hit.collider != null)
        {
            //attack
            if (timeBtwAttack < 0)
            {
                anim.SetBool("isAttacking", true);
                StartCoroutine(CastStatus());
                PlayerManager.instance.MinusHP(attackDamage);
                timeBtwAttack = attackCooldown;
            }
        }
        else
        {
            if (isPlayer)
            {
                float step = moveSpeed + 1f;
                transform.position = Vector2.MoveTowards(position, playerPos.position, step * Time.deltaTime);
            }
            else
            {
                if (hasPatrolPoints)
                {
                    Patrol();
                }
            }
        }

        if (timeBtwAttack >= 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    IEnumerator CastStatus()
    {
        canCast = false;
        yield return new WaitForSeconds(0.5f);
        isPlayer = false;
        moveSpeed = 0;
        yield return new WaitForSeconds(attackCooldown + 1f);
        moveSpeed = storedSpeed;
        canCast = true;
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
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
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
