using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject anchor;
    public GrapplingHook1 hook1;
    public PlayerMovement1 player;
    public GameObject hookOrigin;
    public float climbSpeed = 5f;
    public float ropeMaxCastDistance = 10f;
    private bool ropeAttached;

    private DistanceJoint2D joint2D;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint2D = GetComponent<DistanceJoint2D>();
        joint2D.enabled = false;
        ropeAttached = false;
    }

    private void Update()
    {
        HandleRope();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("ground");
            rb.velocity = Vector2.zero;
            ropeAttached = true;
            anchor.transform.position = transform.position;
            joint2D.distance = Vector2.Distance(hookOrigin.transform.position, anchor.transform.position);
            ropeMaxCastDistance = joint2D.distance;
            joint2D.enabled = true;
            player.isSwinging = true;
            player.ropeHook = transform.position;
            

            hook1.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
            //hook1.ropeJoint.enabled = true;
            //hook1.ropeHingeAnchorRb.transform.position = transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            ropeAttached = false;
            player.isSwinging = false;
        }
    }

    void HandleRope()
    {
        if (Input.GetAxis("Vertical") >= 1f && ropeAttached)
        {
            Debug.Log("pull up");
            joint2D.distance -= Time.deltaTime * climbSpeed;
        }
        else if (Input.GetAxis("Vertical") < 0f && ropeAttached)
        {
            Debug.Log("let down");
            if (joint2D.distance <= ropeMaxCastDistance)
            {
                joint2D.distance += Time.deltaTime * climbSpeed;
            }
        }
    }
}
