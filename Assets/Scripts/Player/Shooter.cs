using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireRate = 0.4f;
    private float bulletInterval;

    public Transform crosshair;
    float aimAngle;

    private void Update()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
        var facingDirection = worldMousePosition - transform.position;
        aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
        
        SetCrosshairPosition(aimAngle);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletInterval < Time.time)
        {
            Instantiate(bulletPrefab, firepoint.position, Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg));
            bulletInterval = Time.time + fireRate;
        }
    }

    private void SetCrosshairPosition(float aimAngle)
    {
        var x = transform.position.x + 1f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 1f * Mathf.Sin(aimAngle);

        var crossHairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crossHairPosition;
    }
}
