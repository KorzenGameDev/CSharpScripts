using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField]private float moveSpeed = 500f;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private int extraJump = 2;
    [SerializeField] private float radiusGround = 0.5f;
    [SerializeField] private float timeDirt = 1f;

    private float horizontalMove=0f;
    private int valueExtraJump = 0;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private bool isDirtParticle = false;

    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    public Transform checkGround;
    public GameObject firePoint;
    public Animator animator;
    public GameObject dirtParticle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        valueExtraJump = extraJump;
    }

    private void Update()
    {
        // ustawianie wartosci animatora dla podanych animacji
        if(animator!=null)
        {
            animator.SetFloat("ValueMove", Mathf.Abs(horizontalMove));
            animator.SetBool("IsJump", !isGrounded);
        }

        // Obracanie postci zgodnie z jej kierunkiem ruchu
        if(horizontalMove>0f && !isFacingRight)
        {
            Flip();
        }
        else if(horizontalMove<0f && isFacingRight)
        {
            Flip();
        }

        // skakanie
        if(checkGround!=null)
        {
            // pojedynczy skok
            if(isGrounded && Input.GetButtonDown("Vertical"))
            {
                extraJump = valueExtraJump;
                Jump();
                StartCoroutine(DirtWait());
            }
            //skaknie zadana ilosc razy
            else if(!isGrounded && Input.GetButtonDown("Vertical") && extraJump-->0)
            {
                Jump();
            }
            // system partyklii kurzu
            else if(isGrounded && isDirtParticle && dirtParticle!=null)
            {
                GameObject effectDirt=(GameObject) Instantiate(dirtParticle, checkGround.position, transform.rotation);
                Destroy(effectDirt, timeDirt);
                isDirtParticle = false;
            }
        }

        // pobieranie kierunku ruchu (1)-prawo (-1)-lewo
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        //sprawdanie czy postac dotyka podłoza
        if (checkGround != null)
            isGrounded = Physics2D.OverlapCircle(checkGround.position, radiusGround, whatIsGround);

        // ruch postaci w odpowiednim kierunku
        rb.velocity = new Vector2(horizontalMove*moveSpeed*Time.deltaTime, rb.velocity.y);


    }

    IEnumerator DirtWait()
    {
        yield return new WaitForSeconds(0.1f);
        isDirtParticle = true;
    }

    //Funkcja skakania
    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    // funkcja odwracajaca postac w zaleznosci od jej wartosci ruchu i kierunku zwrocenia twarzy
    void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void Dead()
    {
        SceneManager.LoadScene(Application.loadedLevel);
        Destroy(gameObject);
    }
}
