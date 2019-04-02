using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public PlayerController player;
    public Rigidbody2D rb;

    public GameObject enemyDieParticle;

    public LiveMenager live;

    private bool isDetect;
    private bool isFacingRight=true;
    private bool isAttack;

    public Vector3 targetPos;
    public Vector3 startPos;
    [SerializeField]private float speedMove = 300f;
    [SerializeField] private float timeWaitBeetwenAtack = 3f;


    public float diffX;
    public float diffY;
    public float valueDiff=20f;

    [SerializeField] private float health = 100f;



    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        live = FindObjectOfType<LiveMenager>();

        startPos = transform.position;
    }

    private void FixedUpdate()
    {

        // obracanie przeciwnika twarza do gracza
        // gdy gracz jest po naszej lewej a patrzymy w prawo obroc
        if(transform.position.x > player.transform.position.x && isFacingRight)
        {
            Flip();
        }
        // gdy gracz jest po nszej praej a patrzymy w prawo obroc
        else if(transform.position.x < player.transform.position.x && !isFacingRight)
        {
            Flip();
        }

        // szukanie gracza przez wroga w okreslonej strefie
        Detect();

        //ruch wroga w grze
        if(isDetect)
        {
            Move();
        }
        else
        {
            Back();
        }
    }

    // Funkcja ktora podaje czy player jest w zasiegu widzenia enemy
    public void Detect()
    {
        diffX = transform.position.x - player.transform.position.x;
        diffY = transform.position.y - player.transform.position.y;

        if(Mathf.Abs(diffX) < valueDiff && Mathf.Abs(diffY) < valueDiff)
        {
            isDetect = true;
        }
        else if(isDetect)
        {
            isDetect = false;
        }
    }

    // ruch wroga w kierunku gracza
    void Move()
    {
        targetPos = player.transform.position;
        //transform.position = Vector3.Lerp(transform.position, targetPos, speedMove*Time.deltaTime);

        // sterowanie na podstawie pozycji wroga i gracza
        if (diffX < 0f && diffY<0f)
            rb.velocity = new Vector2(speedMove * Time.deltaTime, speedMove*Time.deltaTime);
        else if (diffX > 0f && diffY<0f)
            rb.velocity = new Vector2(-speedMove * Time.deltaTime, speedMove*Time.deltaTime);
        else if (diffX > 0f && diffY > 0f)
            rb.velocity = new Vector2(-speedMove * Time.deltaTime, -speedMove * Time.deltaTime);
        else if (diffX < 0f && diffY > 0f)
            rb.velocity = new Vector2(speedMove * Time.deltaTime, -speedMove * Time.deltaTime);
    }

    // ruch wroga w kierunku gracza
    void Back()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, speedMove * 2f);
    }

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0f)
            Die();
    }

    //funkcja odpowidzialna za usuwanie przeciwnika i na jego miejscu kreowanie particla
    //użyta w skrypcie Bullet.cs
    void Die()
    {
        Instantiate(enemyDieParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // obracanie przeciwnika do nas twarza
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isAttack)
        {
            StartCoroutine(WaitBetweenAttack());
            live.ChangeLive();
        }
    }

    IEnumerator WaitBetweenAttack()
    {
        isAttack = true;
        yield return new WaitForSeconds(timeWaitBeetwenAtack);
        isAttack = false;
    }
}
