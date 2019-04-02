using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 delta;
    Vector3 startPosition;


	void Start ()
    {
        startPosition = transform.position;	
	}

	void Update ()
    {
        float velocity = 50f / delta.sqrMagnitude;
        float change = (Mathf.Sin(Time.timeSinceLevelLoad * velocity) + 1f) / 2f;

        Rigidbody rigidbody = transform.GetComponent<Rigidbody>();
        rigidbody.position = Vector3.Lerp(startPosition, startPosition + delta, change);
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        if(Selection.activeTransform == transform)
        {
            Gizmos.color = Color.red;
        }

        Vector3 ghostPosition = transform.position + delta;
        Vector3 platformScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y / 2f, transform.localScale.z * 2f);
        Vector3 ghostSize = transform.rotation * platformScale;
        Gizmos.DrawWireCube(ghostPosition, ghostSize);
       
    }
}
