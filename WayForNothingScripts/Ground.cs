using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    PlayerMovment player;
    public float width = 128f;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovment>();
    }

    private void Update()
    {
        if(transform.position.x-player.transform.position.x < -50f )
        {
            transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
        }
    }
}
