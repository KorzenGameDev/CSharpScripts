using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    PlayerMovment player;
    public float cameraSpeed = 10f;
    public float offset = 10f;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovment>();
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x+offset, transform.position.y, transform.position.z), cameraSpeed);
	}
}
