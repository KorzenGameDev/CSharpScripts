using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControler : MonoBehaviour
{
    
	void Update ()
    {
        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            direction = -Vector3.left;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            direction = Vector3.forward;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            direction = -Vector3.forward;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevelName == "Menu")
                Application.CancelQuit();
            else
                Application.LoadLevel("Menu");
        }

        rigidbody.AddTorque(direction * 100f);
    }
}
