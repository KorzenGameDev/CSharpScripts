using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovment : MonoBehaviour {

    public float movmentSpeed;
    public int verPosition = 1;
    public float timeEffect;
    public Transform[] movePoint;
    public GameObject jumpEffect;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.right * movmentSpeed * Time.deltaTime;
        movmentSpeed += (Time.deltaTime * 5);

        if(Input.GetKeyDown(KeyCode.UpArrow) && verPosition != 2)
        {
            verPosition++;
            GameObject effect = Instantiate(jumpEffect, transform.position, Quaternion.identity);
            transform.position = new Vector2(transform.position.x, movePoint[verPosition].position.y);
            Destroy(effect,timeEffect);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && verPosition != 0)
        {
            verPosition--;
            GameObject effect = Instantiate(jumpEffect, transform.position, Quaternion.identity);
            transform.position = new Vector2(transform.position.x, movePoint[verPosition].position.y);
            Destroy(effect, timeEffect);
        }
    }

}
