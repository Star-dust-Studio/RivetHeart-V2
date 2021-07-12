using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrapTest2 : MonoBehaviour
{
    [Header("Script References")]
    public PlayerMovement1 player;

    [Header("Crosshair")]
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    private Vector2 playerPos;

    [Header("Hook")]
    public GameObject hook;
    public GameObject hookOrigin;
    private Vector2 hookOriginPosition;
    private SpriteRenderer hookSprite;
    private bool hookAttached;
    private Rigidbody2D rbHook;
    public float hookSpeed = 5f;
    private bool shotHook;

    [Header("Rope")]
    public DistanceJoint2D ropeJoint;
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    private float ropeMaxCastDist = 10f;
    private Vector2 ropePosition;
    private bool distanceSet;

    private void Awake()
    {
        ropeJoint.enabled = false;
        playerPos = transform.position;
        hookOriginPosition = new Vector2(hook.transform.position.x, hook.transform.position.y);
        rbHook = hook.GetComponent<Rigidbody2D>();
        hookSprite = hook.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Mouse.z = distance from camera
        var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
        var facingDirection = worldMousePos - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }

        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;

        playerPos = transform.position;

        if (!hookAttached)
        {
            SetCrosshairPosition(aimAngle);
            player.isSwinging = false;
        }
        else
        {
            player.isSwinging = true;
            crosshairSprite.enabled = false;
        }
        HandleInput(aimDirection);
        UpdateRopePosition();
        HandleRopeLength();
        if (!shotHook)
        {
            RetractRope();
        }
    }

    private void SetCrosshairPosition(float aimAngle)
    {
        if (!crosshairSprite.enabled)
        {
            crosshairSprite.enabled = true;
        }

        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        var crosshairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crosshairPosition;
    }

    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButtonDown(1))
        {
            shotHook = true;
            if (hookAttached)
            {
                return;
            }
            ropeRenderer.enabled = true;

            rbHook.velocity = aimDirection * hookSpeed;
        }
        if (Input.GetMouseButtonUp(1))
        {
            shotHook = false;
        }
    }

    private void UpdateRopePosition()
    {

    }

    private void HandleRopeLength()
    {

    }

    private void RetractRope()
    {
        rbHook.velocity = hookOriginPosition * hookSpeed;
        Vector2 hookCurrentPosition = new Vector2(hook.transform.position.x, hook.transform.position.y);
        if (Vector2.Distance(hookOriginPosition, hookCurrentPosition) < 0.1f)
        {
            rbHook.velocity = Vector2.zero;
            hook.transform.position = hookOriginPosition;
        }
    }
}
