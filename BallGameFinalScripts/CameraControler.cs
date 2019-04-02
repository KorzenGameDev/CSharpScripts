using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform sphere;

	void Update ()
    {

        Rigidbody rigidbody = sphere.GetComponent<Rigidbody>();

        Vector3 vector = new Vector3(0f, 3f, -5f);
        float velocity = rigidbody.velocity.sqrMagnitude;
        vector = vector*(1f + velocity / 25);

        Vector3 newPosition = sphere.position + vector;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 2f);
        transform.LookAt(sphere);
	}
}
