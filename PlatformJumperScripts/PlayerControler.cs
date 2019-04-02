using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour
{
    new private Rigidbody2D rigidbody2D;    //zmienna fizyki
    public float velocity;  //predkosc poruszania sie
    public float jump;  //skok

    public Transform onGround;  //kulka onGround obiekt w grze sprawdzaja czy player dotyka podloza
    public float radius;    //promien kulka onGround
    public LayerMask layerMask; //maska
    public bool isGround;   //sprawdza czy postac dotyka podloza jesli tak zwraca wartosc true
    public bool doubleJump; //podwojny skok gdy dotyka podloza jest true ustawia sie na false po skoku kiedy isGround jest false
    

    public float beforeMove;    //zmienna do ktorej przypisywana jest nasza pozycja co kilka klatek 
    public float difference;    //roznica na podsawie ktorej wylicza sie czy jestesmy w ruchy czy nie 
    private Animator animator;  // obiek animatora
    public float beforeJump;    //zmienna przechowujaca nasz stan przed skokiem 
    public float jumping;   //zmienna wysyłajaca różnice wysokosci dla animacji 

    public GameObject enemy;    //szuka wroga
    public float velocityBounce;    //predkosc odbicia sie od wroga
    public bool blockControl;   //true jesli blokowana jest kontrola klawiatury na chwile
    public float timeBlockControl;  //czas blokady klawiatury

    public GameObject staticThings;
    public Renderer disableEnablePlayer;
    public float time;


    // Use this for initialization
    void Start ()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  //pobranie komponentu fizyki
        disableEnablePlayer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();    //pobranie komponentu animacji
        staticThings = GameObject.Find("StaticThings");
        time = 3f;
	}


    // Update is called once per frame
    void Update ()
    {
        isGround = Physics2D.OverlapCircle(onGround.position, radius, layerMask); // ustawia wartosc zmiennej isGround w zaleznosci od tego czy dotyka czy nie dotyka podloza
        if (!blockControl)   //jesli true blokuje nam chwilowo funkcje Control()
            Control();
        Escape();
    }

    void FixedUpdate()  //wykonuje sie co kilka klatek 
    {
        beforeMove = rigidbody2D.position.x;    //przypisanie pozycji x
        beforeJump = rigidbody2D.position.y;    //przypisanie pozycji y
       
    }

    void Control()  //funkcja odpowiedzialna za sterowanie
    {
        difference = Mathf.Abs(beforeMove - rigidbody2D.position.x); //obliczenie roznicy jesli jest jakas watrosc to wykonujemy animacje ruchu
        if(isGround) //sprawdza czy jest na ziemi
            animator.SetFloat("valueRun", difference);  //wpisanie tej wartosci do zmiennej animacji ruchy
        animator.SetBool("noJump", isGround);   //wpisanie wartosci do zmiennej animacji skoku true/false
        if (isGround)
        {
            doubleJump = true;
            jumping = 0f;
            beforeJump = 0f;
        }
        else
        {
            jumping = Mathf.Abs(rigidbody2D.position.y) - Mathf.Abs(beforeJump);    //wyliczenie czy obiekt skacze czy spada
            animator.SetFloat("valueJump", jumping);    //wpisanie wartosci do animacji skoku
        }

        //sterowanie postacia
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGround)
                rigidbody2D.velocity = new Vector2(0, jump);
            else if (doubleJump) //podwojny skok
            {
                doubleJump = false;
                rigidbody2D.velocity = new Vector2(0, jump);
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-velocity, rigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(velocity, rigidbody2D.velocity.y);
        }
        //koniec sterowania postacia
       
        if (rigidbody2D.velocity.x > 0)    //zostawia animacje ruchu w normalej skali
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            staticThings.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (rigidbody2D.velocity.x < 0) //odwraca animacje ruchu w druga strone
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            staticThings.transform.localScale = new Vector3(-1f, 1f, 1f);

        }
    }

    public void DirectionBounce(string name)    //funkcja odpowiedzialna za odbicie nas od wroga pobiera nazwe wroga odniesienie do skrypty EnemyCharacter
    {
        StartCoroutine(BlockControl(timeBlockControl)); //funkcja blokujaca klawiature
        enemy = GameObject.Find(name + "/EnemyCharacter");  //szukanie konkretnie naszego wroga
        if (enemy.transform.position.x < transform.position.x)  // sprawdzanie z ktorej strony podchodzimy do niego
            rigidbody2D.velocity = new Vector2(velocityBounce, velocityBounce); //kierunek odbicia z prawej strony
        else
            rigidbody2D.velocity = new Vector2(-velocityBounce, velocityBounce);    //kierunek odbicia z lewej strony
    }

    public void ContactWithEnemy()
    {
        StartCoroutine(DisableEnablePlayer());
    }

    IEnumerator DisableEnablePlayer()
    {
        for(int i=0; i< time*2f; i++ )
        {
            disableEnablePlayer.enabled = false;
            yield return new WaitForSeconds(0.25f);
            disableEnablePlayer.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }

    IEnumerator BlockControl(float time) //funkcja blokujaca controle
    {
        blockControl = true;
        yield return new WaitForSeconds(time);  //odczekaj chwile przed nastepna czynnoscia
        blockControl = false;
    }

    private void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }
}
