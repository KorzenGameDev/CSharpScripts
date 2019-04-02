using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    new private Rigidbody2D rigidbody2D;
    public float velocity;

    //obiekty pomiedzy ktorymi wrog sie porusza
    public Transform up;
    public Transform down;
    public Transform right;
    public Transform left;
    
    public bool horizontally; //true jesli enemy ma sie poruszac prawo lewo
    public bool isRed;
    public bool isRigidbody2D;
    public bool isAttaced;

    //odwolania sie do skryptow
    public Energy energy;   
    public PlayerControler player;
    public AudioSource audioSource;
    public AudioClip audioClip;


	// Use this for initialization
	void Start ()
    {
        //pobieranie komponentów
        if(isRigidbody2D)
            rigidbody2D = GetComponent<Rigidbody2D>();
        isRed = true;
        energy = FindObjectOfType<Energy>();
        player = FindObjectOfType<PlayerControler>();
        isAttaced = true;
        audioSource = player.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isRigidbody2D)
            MoveEnemy();
    }

    void MoveEnemy()
    {
        if (horizontally)
        {
            if (rigidbody2D.position.x > right.position.x)
            {
                isRed = true;
            }

            if (rigidbody2D.position.x < left.position.x)
            {
                isRed = false;
            }
            if (isRed)
                rigidbody2D.velocity = new Vector2(-velocity, rigidbody2D.velocity.y);
            else
                rigidbody2D.velocity = new Vector2(velocity, rigidbody2D.velocity.y);
        }
        else
        {
            if (rigidbody2D.position.y > up.position.y)
            {
                isRed = true;
            }

            if (rigidbody2D.position.y < down.position.y)
            {
                isRed = false;
            }
            if (isRed)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -velocity);
            else
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocity);
        }
    }
    IEnumerator FreeTime(float t)
    {
        yield return new WaitForSeconds(t);
        isAttaced = true;
    }

    void OnTriggerEnter2D(Collider2D collision) //funkcja kolizji z wrogiem
    {
        if (collision.name == "Player" && isAttaced)
        {
            audioSource.PlayOneShot(audioClip);
            energy.energy--; //odejmuje zycie z skryptu Energy
            player.DirectionBounce(transform.parent.name); //wysyła nazwe wroga do skryptu player do podanej funkcji 
            isAttaced = false;
            player.ContactWithEnemy();
            StartCoroutine(FreeTime(player.time));
        }
    }
    
}
