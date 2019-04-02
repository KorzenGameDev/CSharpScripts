using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos=null;
    [SerializeField] float followSpeed = 1f;


    private void LateUpdate()
    {
        //podajemy obecna pozycje gracza dla kamery
        FollowPosition(playerPos.position);
    }


    //sledzi podana pozycje gracza
    void FollowPosition(Vector3 target)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.x, target.y, transform.position.z), followSpeed);
    }
}
