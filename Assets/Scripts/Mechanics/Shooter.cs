using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public float fireRate = 0.4f;
    private float bulletInterval;

    public void Shoot()
    {
        if (bulletInterval < Time.time)
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            bulletInterval = Time.time + fireRate;
        }
    }
}
