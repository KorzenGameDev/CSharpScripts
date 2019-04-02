using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //move
    public float speed=400f;
    public float jump=100f;
    public int startExtraJump;
    private int extraJump;
    private float moveDirection;
    public bool isGrounded;
    float radius = 0.2f;
    public LayerMask whatIsGround;
    public Transform onGround;
    public Transform onLeft;
    public Transform onRight;

    public GameObject spritePlayer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJump = startExtraJump;
    }

    void Update()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        Flip();

        isGrounded = Physics2D.OverlapCircle(onGround.position, radius, whatIsGround);
        if(isGrounded)
        {
            spritePlayer.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            extraJump = startExtraJump;
        }
        rb.velocity = Vector2.right * moveDirection * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = Vector2.up * jump;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jump;
            extraJump--;
        }
    }

    public void Flip()
    {
        if(moveDirection > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(moveDirection < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
