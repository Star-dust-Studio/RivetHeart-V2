using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Shooter playerShooter;

    private SpriteRenderer playerSprite;
    private Rigidbody2D rBody;
    private Animator animator;

    private bool isFacingRight = true;
    private float horizontalInput;
    public float speed = 1f;
    private float jumpInput;
    public float jumpSpeed = 3f;
    private bool isJumping;

    public float swingForce = 4f;
    public Vector2 ropeHook;
    public bool isSwinging;

    //public bool isGrounded;
    //public Transform groundCheck;
    //public bool groundCheck;
    public float groundCheckRadius = 1.0f;
    public LayerMask ground;

    /// <summary>
    /// 0 = allow all movements, 1 = restrict hook, 2 = restrict all movements
    /// </summary>
    public int playerState;

    void Awake()
    {
        Time.timeScale = 1; // spaghetti
        playerSprite = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerShooter = GetComponent<Shooter>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (IsGrounded())
        {
            animator.SetFloat("Velocity", Mathf.Abs(horizontalInput));
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     //animator.SetTrigger("Shoot");
        //     playerShooter.Shoot();
        // }
    }

    void FixedUpdate()
    {
        if (horizontalInput < 0f || horizontalInput > 0f)
        {
            if (isFacingRight == false && horizontalInput > 0)
            {
                FlipCharacter();
            }
            else if (isFacingRight == true && horizontalInput < 0)
            {
                FlipCharacter();
            }

            if (isSwinging)
            {
                //animator.SetBool("IsSwinging", true);

                // Get normalized direction vector from player to the hook point
                var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

                // Inverse the direction to get a perpendicular direction
                Vector2 perpendicularDirection;
                if (horizontalInput < 0)
                {
                    perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                    var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
                    Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
                }
                else
                {
                    perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                    var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
                    Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
                }

                var force = perpendicularDirection * swingForce;
                rBody.AddForce(force, ForceMode2D.Force);
            }
        }

        if (!isSwinging)
        {
            rBody.velocity = new Vector2(horizontalInput * speed, rBody.velocity.y);

            if (isJumping)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
                isJumping = false;
            }
        }
    }

    private bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 dir = Vector2.down;

        Debug.DrawRay(position, dir * groundCheckRadius, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, dir, groundCheckRadius, ground);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
