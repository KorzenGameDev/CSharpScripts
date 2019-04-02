using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] float speedMove = 3f;
    [SerializeField] float bounceJump = 4f;
    [SerializeField] SpriteRenderer plane;
    [SerializeField] Sprite[] playerSprite;
    [SerializeField] Transform player;
    [SerializeField] AudioClip tapClip;
    [SerializeField] AudioClip collisionClip;
    [SerializeField] GameObject startCanvas;
    public bool isAlive;
    bool wasFlip;
    Rigidbody2D rb;
    Animator anim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }


    private void Start()
    {
        switch (GameController.instance.GetPlayer())
        {
            case 0:
                plane.sprite = playerSprite[0];
                anim.SetTrigger("red");
                break;
            case 1:
                plane.sprite = playerSprite[1];
                anim.SetTrigger("yellow");

                break;
            case 2:
                plane.sprite = playerSprite[2];
                anim.SetTrigger("blue");

                break;
            case 3:
                plane.sprite = playerSprite[3];
                anim.SetTrigger("green");

                break;
        }

        StartCoroutine(Starting());
    }

    IEnumerator Starting()
    {
        yield return new WaitForEndOfFrame();
        startCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    private void FixedUpdate()
    {
        PlayerMovment();
    }

    void PlayerMovment()
    {
        if (isAlive)
        {

            Vector3 temp = player.transform.position;
            temp.x += speedMove * Time.deltaTime;
            player.transform.position = temp;

            if (Input.GetKeyDown(KeyCode.Space) || wasFlip)
            {
                wasFlip = false;
                GameController.instance.PlayAnyClip(tapClip);
                rb.velocity = new Vector2(0, bounceJump);
            }

            if (rb.velocity.y >= 0)
            {
                float angle = 0;
                angle = Mathf.Lerp(0, 90, rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -90, -rb.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

        }
    }
    public void ButtonFlipController()
    {
        wasFlip = true;
    }
    public void ButtonStart()
    {
        GameController.instance.PlayAnyClip(tapClip);
        startCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.ROCK) || collision.gameObject.CompareTag(GameController.DOWN_GROUND))
        {
            GameController.instance.PlayAnyClip(collisionClip);
            
            if(GameController.instance.GetHighScore(SceneManager.GetActiveScene().name) < GameplayMenager.instance.GetScore())
            {
                GameController.instance.SetHighScore(SceneManager.GetActiveScene().name, GameplayMenager.instance.GetScore());
            }

            GameplayMenager.instance.EndLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameController.STAR))
        {
            GameplayMenager.instance.AddScore(collision.gameObject.GetComponent<Star>().value);
            collision.gameObject.GetComponent<Star>().Boom();
        }
    }


}
