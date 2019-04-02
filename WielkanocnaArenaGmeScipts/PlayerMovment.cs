using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovment : MonoBehaviour
{

    [Header("Move")]
    [SerializeField] float speed = 400f;
    [SerializeField] Animator anim = null;
    float moveRightLeft = 0f;
    float moveUpDown = 0f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveRightLeft = Input.GetAxisRaw("Horizontal");
        moveUpDown = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveRightLeft * speed * Time.deltaTime, moveUpDown * speed * Time.deltaTime);

        if (anim != null)
        {
            if (moveRightLeft != 0 || moveUpDown != 0) anim.SetBool("walk", true);
            else anim.SetBool("walk", false);
        }
    }
}
