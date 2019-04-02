using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Update()
    {
        if(PlayerController.instance!=null)
        {
            if (PlayerController.instance.isAlive)
            {
                CameraFollowPosition();
            }
        }
    }

    void CameraFollowPosition()
    {
            Vector3 temp = gameObject.transform.position;
            temp.x = PlayerController.instance.transform.position.x;
            gameObject.transform.position = temp;
    }

    
}
