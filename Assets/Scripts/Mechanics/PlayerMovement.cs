using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Rigidbody2D rBody;
    private Animator animator;

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
    private int playerState;

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //jumpInput = Input.GetAxis("Jump");
        horizontalInput = Input.GetAxis("Horizontal");
        //var halfHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        //groundCheck = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - halfHeight - 0.04f), Vector2.down, 0.025f);
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        //horizontalInput = Input.GetAxis("Horizontal");


        if (IsGrounded())
        {
            animator.SetFloat("Velocity", Mathf.Abs(horizontalInput));
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            //animator.SetTrigger("Jump");
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontalInput * speed, rBody.velocity.y);

        if (horizontalInput < 0f || horizontalInput > 0f)
        {
            playerSprite.flipX = horizontalInput < 0f;
        }

        //if (horizontalInput < 0f || horizontalInput > 0f)
        //{
        //animator.SetFloat("Velocity", Mathf.Abs(horizontalInput));

        //if (isSwinging)
        //    {
        //        //animator.SetBool("IsSwinging", true);

        //        // Get normalized direction vector from player to the hook point
        //        var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

        //        // Inverse the direction to get a perpendicular direction
        //        Vector2 perpendicularDirection;
        //        if (horizontalInput < 0)
        //        {
        //            perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
        //            var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
        //            Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
        //        }
        //        else
        //        {
        //            perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
        //            var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
        //            Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
        //        }

        //        var force = perpendicularDirection * swingForce;
        //        rBody.AddForce(force, ForceMode2D.Force);
        //    }
        //    else
        //    {
        //        //animator.SetBool("IsSwinging", false);
        //        if (groundCheck)
        //        //if (isJumping)
        //        {
        //        //rBody.AddForce(new Vector2(0f, jumpSpeed));
        //        //isJumping = false;

        //        var groundForce = speed * 2f;
        //        rBody.AddForce(new Vector2((horizontalInput * groundForce - rBody.velocity.x) * groundForce, 0));
        //        rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y);
        //        //isJumping = false;
        //        }
        //    }

        //}
        //else
        //{
        //    //animator.SetBool("IsSwinging", false);
        //    animator.SetFloat("Velocity", 0f);
        //}

        if (!isSwinging)
        {
            //if (!groundCheck) return;

            //isJumping = jumpInput > 0f;
            if (isJumping)
            {
                //isGrounded = false;
                rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
                //rBody.AddForce(new Vector2(0f, jumpSpeed));
                isJumping = false;
            }
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 dir = Vector2.down;

        Debug.DrawRay(position, dir, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, dir, groundCheckRadius, ground);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
