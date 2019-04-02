using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=20f;
    public float jumpForce=20f;
    public float moveInput;

    private Rigidbody2D myRigidbody2D;
    private Animator animator;
    public GameObject dirtParticle;

    private bool isFacingRight = true;
    public bool isDirtParticle = false;


    // Skakanie
    public bool isGrounded=false;
    public Transform groundCheck;
    public float checkRadius=1f;
    public LayerMask whatIsGround;

    private int extraJumpsValue=2;
    public int extraJumps;

    private void Start()
    {
        extraJumps = extraJumpsValue;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("valueRun", Mathf.Abs(moveInput));
        animator.SetBool("isJump", !isGrounded);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        //Debug.Log(moveInput);
        myRigidbody2D.velocity = new Vector2(moveInput * moveSpeed, myRigidbody2D.velocity.y);

        if(isFacingRight==false && moveInput>0)
        {
            Flip();
        }
        else if(isFacingRight==true && moveInput<0)
        {
            Flip();
        }

        
        
    }

    private void Update()
    {
        if(isGrounded)
        {
            if(isDirtParticle)
            {
                dirtParticle.transform.position = groundCheck.transform.position;
                Instantiate(dirtParticle);
                isDirtParticle = false;
            }
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps>0)
        {
            myRigidbody2D.velocity = Vector2.up * jumpForce;
            extraJumps-=1;

            StartCoroutine(Wait());
        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f); 
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
       isDirtParticle = true;
    }



}
