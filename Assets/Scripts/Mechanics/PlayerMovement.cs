using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private Rigidbody2D rb;
    //private Animator anim;

    //private bool isFacingRight = true;
    //private bool isJumping = false;
    //private bool isGrounded = false;
    //public bool isSwinging = false;

    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask ground;
    //public float moveInput;
    //public float speed;
    //public float jumpForce;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    anim = GetComponent<Animator>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
    //    moveInput = Input.GetAxis("Horizontal");

    //    if (isGrounded)
    //    {
    //        anim.SetFloat("Velocity", Mathf.Abs(moveInput));
    //    }

    //    if (Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        isJumping = true;
    //        anim.SetTrigger("Jump");
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    //    if (isFacingRight == false && moveInput > 0)
    //    {
    //        FlipCharacter();
    //    }
    //    else if (isFacingRight == true && moveInput < 0)
    //    {
    //        FlipCharacter();
    //    }

    //    if (isJumping)
    //    {
    //        rb.AddForce(new Vector2(0f, jumpForce));
    //        isJumping = false;
    //    }
    //}

    //private void FlipCharacter()
    //{
    //    isFacingRight = !isFacingRight;

    //    Vector3 scale = transform.localScale;
    //    scale.x *= -1;

    //    transform.localScale = scale;
    //}

    public float swingForce = 4f;
    public float speed = 1f;
    public float jumpSpeed = 3f;
    public Vector2 ropeHook;
    public bool isSwinging;
    public bool groundCheck;
    private SpriteRenderer playerSprite;
    private Rigidbody2D rBody;
    private bool isJumping;
    private Animator animator;
    private float jumpInput;
    private float horizontalInput;

    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        jumpInput = Input.GetAxis("Jump");
        horizontalInput = Input.GetAxis("Horizontal");
        var halfHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        groundCheck = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - halfHeight - 0.04f), Vector2.down, 0.025f);
    }

    void FixedUpdate()
    {
        if (horizontalInput < 0f || horizontalInput > 0f)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            rBody.velocity = new Vector2(horizontalInput * speed, rBody.velocity.y);

            playerSprite.flipX = horizontalInput < 0f;
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
            else
            {
                //animator.SetBool("IsSwinging", false);
                if (groundCheck)
                {
                    var groundForce = speed * 2f;
                    rBody.AddForce(new Vector2((horizontalInput * groundForce - rBody.velocity.x) * groundForce, 0));
                    rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y);
                }
            }
        }
        else
        {
            //animator.SetBool("IsSwinging", false);
            animator.SetFloat("Speed", 0f);
        }

        if (!isSwinging)
        {
            if (!groundCheck) return;

            isJumping = jumpInput > 0f;
            if (isJumping)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
            }
        }
    }
}
