using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    private Vector3 playerPosY;
    private Vector3 playerPosX;

    [SerializeField] private float speedCamera=2f;
    [SerializeField] private float lastPosY;
    [SerializeField] private float lastPosX;

    void Start () {
        player = FindObjectOfType<PlayerController>();
        lastPosY = player.transform.position.y;
        lastPosX = player.transform.position.x;
        InvokeRepeating("LastPosY", 0f, 0.5f);
        InvokeRepeating("LastPosX", 0f, 0.5f);
    }

    private void LastPosY()
    {
        lastPosY = player.transform.position.y;
    }
    private void LastPosX()
    {
        lastPosX = player.transform.position.x;
    }

    private void Update()
    {

        if (player != null && (!player.GetIsGrounded() || Mathf.Abs(player.transform.position.y-lastPosY)>1f))
        {
            playerPosY = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosY, speedCamera);
        }

        if (player != null && (player.GetIsGrounded() || Mathf.Abs(player.transform.position.x-lastPosX) > 1f))
        {
            playerPosX = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosX, speedCamera);
        }
            
    }

}
