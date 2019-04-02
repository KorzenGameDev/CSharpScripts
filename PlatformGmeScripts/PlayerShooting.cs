using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed=2f;
    public bool isShoot;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isShoot = true;
            animator.SetBool("isShoot", isShoot);
            ShootBullet();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isShoot = false;
            animator.SetBool("isShoot", isShoot);
        }
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
