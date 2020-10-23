using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the rate of fire and bullet speed of a gun.
/// </summary>
public class GunController : MonoBehaviour
{
    public bool isFiring;

    // public BulletController bullet;
    // public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public GameObject bullet;

    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
        }
    }
}

