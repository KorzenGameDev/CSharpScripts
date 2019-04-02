using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject fallowTarget;
    private Vector3 targetPosition;
    public float moveSpeed;
    float z;

	void Start ()
    {
        fallowTarget = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
        // Ustawianie pozycji kamery na pozycje gracza i płynne przejscie za pomocą funkcji Lerp
        targetPosition = new Vector3(fallowTarget.transform.position.x, fallowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
