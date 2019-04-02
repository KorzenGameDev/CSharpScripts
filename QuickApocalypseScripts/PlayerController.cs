using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int live = 3;
    public int health = 100;

    public float speed = 100f;

    private float x;

    private Vector3 mousePos;
    private Vector3 screePos;
    

    private void Start()
    {
        x = transform.localScale.x;
    }

    private void Update()
    {
        transform.position += Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right;  
        transform.position += Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.up;

        mousePos = Input.mousePosition;
        screePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z-Camera.main.transform.position.z));

        float angle = Mathf.Atan2((screePos.y - transform.position.y), screePos.x - transform.position.x) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle = 360 + angle;
        }

        if(angle >=90 && angle <270)
        {
            transform.localScale = new Vector3(-x, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }
    }

    public void SetLive(int _live)
    {
        live += _live;
        if(live<0)
        {
            Debug.Log("Lose");
        }

    }
    public void SetHealth(int demage)
    {
        health += demage;
        if(health<=0f)
        {
            SetLive(-1);
            health = 100;
        }
    }
}
