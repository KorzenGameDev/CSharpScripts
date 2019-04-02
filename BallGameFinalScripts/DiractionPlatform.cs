using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiractionPlatform : MonoBehaviour
{
    public bool rightDirection = true;

    private void OnTriggerStay(Collider other)
    {
        GameObject thing = other.gameObject;
        Rigidbody rigidbody = thing.GetComponent<Rigidbody>();
        Vector3 velocity = rigidbody.velocity;
        velocity.x = 5f;

        if (rightDirection)
            velocity.x = 5f;
        else
            velocity.x = -5f;

        rigidbody.velocity = velocity;
    }

}
