﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    


    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyGhoust enemy= collision.GetComponent<EnemyGhoust>();
        if(enemy!=null)
        {
            enemy.Dead();
        }

        Destroy(gameObject);
    }
}
