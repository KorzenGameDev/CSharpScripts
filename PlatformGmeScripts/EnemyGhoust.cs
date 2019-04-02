using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhoust : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 startPosition;
    public float moveSpeed;

    private bool isFacingRight;
    public bool isLive;

    public GameObject particle;
    private EnemyDeteckArea areaDetect;
    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        areaDetect = FindObjectOfType<EnemyDeteckArea>();
        startPosition = transform.position;
        isFacingRight = true;
        isLive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // warunek odebraia zycia warunek kolizji z wrogiem
        if (collision.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevelName);
            //Debug.Log("Dead");
        }

        if(collision.CompareTag("Bullet"))
        {
            name = transform.parent.name;
        }
    }

    public void Update()
    {
        if(isLive)
        {
            if (player.transform.position.x < transform.position.x && isFacingRight)
            {
                isFacingRight = !isFacingRight;
                Flip();
            }
            else if (player.transform.position.x > transform.position.x && !isFacingRight)
            {
                isFacingRight = !isFacingRight;
                Flip();
            }

            if (areaDetect.isAttacked)
            {
                targetPos = player.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
               Debug.Log(transform.position);
            }
            else if (!areaDetect.isAttacked && transform.position.x != startPosition.x && transform.position.y != startPosition.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void Dead()
    {
        particle.transform.position = transform.position;
        Instantiate(particle);
    }
    
}
